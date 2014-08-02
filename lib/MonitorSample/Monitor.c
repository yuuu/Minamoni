#include "kernel.h"
#include "kernel_id.h"
#include "ecrobot_interface.h"

/* Port number Define */
#define STEER	NXT_PORT_C
#define DRIVE_L	NXT_PORT_A
#define DRIVE_R	NXT_PORT_B
#define GYRO	NXT_PORT_S1
#define IR		NXT_PORT_S3
#define TOUCH	NXT_PORT_S2
#define SONAR	NXT_PORT_S4

/* Bluetooth Configuration */
#define BLUETOOTH_PASSKEY		"1234"
#define BLUETOOTH_NAME			"SAMPLE"
#define BLUETOOTH_WAIT_PERIOD	10
#define BLUETOOTH_SEND_PERIOD	10

/* ログ構造体 */
typedef struct {
	unsigned long command;
	unsigned long size;
	unsigned long index;
	unsigned long time;
	unsigned long vattery;
	unsigned long r_motor_enc;
	unsigned long l_moror_enc;
	unsigned long s_motor_enc;
	unsigned long light_sensor;
	unsigned long gyro_sensor;
	unsigned long sonar_sensor;
	unsigned long r_motor_pwm;
	unsigned long l_motor_pwm;
	unsigned long s_motor_pwm;
	char reserve[8];
}LOG;
static LOG send_log;

/* OSEK declarations */
DeclareCounter(SysTimerCnt);
DeclareTask(Monitor);
DeclareTask(SonarMonitor);

void ecrobot_device_initialize()
{
	ecrobot_init_bt_slave(BLUETOOTH_PASSKEY);
	ecrobot_set_light_sensor_active(IR);
	ecrobot_init_sonar_sensor(SONAR);
	nxt_motor_set_speed(DRIVE_R, 0, 0);
	nxt_motor_set_speed(DRIVE_L, 0, 0);
	nxt_motor_set_speed(STEER, 0, 0);
}

void ecrobot_device_terminate()
{
	ecrobot_term_bt_connection();
	ecrobot_term_sonar_sensor(SONAR);
}

void user_1ms_isr_type2(void)
{
	SignalCounter(SysTimerCnt);
}

void logInit()
{
	send_log.command = 0;
	send_log.size = sizeof(LOG);
	send_log.index = (unsigned long)0;
	send_log.time = (unsigned long)0;
	send_log.vattery = (unsigned long)0;
	send_log.r_motor_enc = (unsigned long)0;
	send_log.l_moror_enc = (unsigned long)0;
	send_log.s_motor_enc = (unsigned long)0;
	send_log.light_sensor = (unsigned long)0;
	send_log.gyro_sensor = (unsigned long)0;
	send_log.sonar_sensor = (unsigned long)0;
	send_log.r_motor_pwm = (unsigned long)0;
	send_log.l_motor_pwm = (unsigned long)0;
	send_log.s_motor_pwm = (unsigned long)0;
}

void waitBuluetoothConnect()
{
	ecrobot_set_bt_device_name(BLUETOOTH_NAME);

	while(ecrobot_get_bt_status() != BT_STREAM)
	{
		systick_wait_ms(BLUETOOTH_WAIT_PERIOD);
	}
}

TASK(Monitor)
{
	logInit();

	waitBuluetoothConnect();

	while(1)
	{
		/* ログを生成する */
		send_log.index++;
		send_log.time = (unsigned long)systick_get_ms();
		send_log.vattery = (unsigned long)ecrobot_get_battery_voltage();
		send_log.r_motor_enc = (unsigned long)nxt_motor_get_count(DRIVE_R);
		send_log.l_moror_enc = (unsigned long)nxt_motor_get_count(DRIVE_L);
		send_log.s_motor_enc = (unsigned long)nxt_motor_get_count(STEER);
		send_log.light_sensor = (unsigned long)ecrobot_get_light_sensor(IR);
		send_log.gyro_sensor = (unsigned long)ecrobot_get_gyro_sensor(GYRO);
		send_log.r_motor_pwm = (unsigned long)0;
		send_log.l_motor_pwm = (unsigned long)0;
		send_log.s_motor_pwm = (unsigned long)0;

		/* ログを送信する */
		ecrobot_send_bt((void*)&send_log, 0, sizeof(LOG));

		systick_wait_ms(BLUETOOTH_SEND_PERIOD);
	}

	TerminateTask();
}

TASK(SonarMonitor)
{
	send_log.sonar_sensor = (unsigned long)ecrobot_get_sonar_sensor(SONAR);
	TerminateTask();
}

