/*
 * NXTrikeβ2～3(ETR100b2/b3) firmware
 *
 * NXTrikeSample.c for TOPPERS/ATK(OSEK)
 * 2013.11.27 TANAHASHI, Jiro
 */

#include "kernel.h"
#include "kernel_id.h"
#include "ecrobot_interface.h"

#define BLACK 591
#define WHITE 542
#define GRAY ((BLACK + WHITE) / 2)

#define LINETRACE_P_GAIN 1.0
#define LINETRACE_D_GAIN 1.0

#define CYCLE 4

#define MAX_STEERING_ANGLE	540
#define DRIVING_POWER		 60

#define MAX_MOTOR_PWM 100

#define STEER	NXT_PORT_C
#define DRIVE_L	NXT_PORT_A
#define DRIVE_R	NXT_PORT_B
#define IR		NXT_PORT_S3
#define TOUCH	NXT_PORT_S2

int turn();
void drive(int forward, int turn);
int check_maxmin(int value, int max, int min);

/* LEJOS OSEK hooks */
void ecrobot_device_initialize()
{

	nxt_motor_set_speed(STEER, 0, 1);
	nxt_motor_set_speed(DRIVE_L, 0, 1);
	nxt_motor_set_speed(DRIVE_R, 0, 1);
	ecrobot_set_light_sensor_active(IR);
}

void ecrobot_device_terminate()
{
	nxt_motor_set_speed(STEER, 0, 1);
	nxt_motor_set_speed(DRIVE_L, 0, 1);
	nxt_motor_set_speed(DRIVE_L, 0, 1);
	ecrobot_set_light_sensor_inactive(IR);
}


/* nxtOSEK hook to be invoked from an ISR in category 2 */
void user_1ms_isr_type2(void){ /* do nothing */ }

TASK(OSEK_Task_Background)
{
	nxt_motor_set_count(STEER, 1);
	nxt_motor_set_count(DRIVE_L, 0);
	nxt_motor_set_count(DRIVE_R, 0);

	while(!ecrobot_get_touch_sensor(TOUCH));
	systick_wait_ms(100); /* 500msec wait */

	while(1)
	{
		/*駆動する*/
		drive(DRIVING_POWER, turn());

  		ecrobot_status_monitor("NXTrike Sample");
		systick_wait_ms(CYCLE);
	}
}

int turn()
{
	int diff = 0;
	int turn = 0;
	int steering_count = nxt_motor_get_count(STEER);
	static int pre_diff = 0;

	/*ステアリングが上限・下限を超えている場合は駆動しない*/
	if(steering_count > MAX_STEERING_ANGLE)
	{
		turn = 0;
	}
	else if(steering_count < -MAX_STEERING_ANGLE)
	{
		turn = 0;
	}
	/*駆動可能な場合*/
	else
	{
		diff = GRAY - ecrobot_get_light_sensor(IR);
		turn += LINETRACE_P_GAIN * diff;
		turn += LINETRACE_D_GAIN * ((diff - pre_diff) / CYCLE);
		pre_diff = diff;
	}

	turn = check_maxmin(turn, MAX_MOTOR_PWM, -MAX_MOTOR_PWM);
	nxt_motor_set_speed(STEER, turn, 1);

	return turn;
}

void drive(int forward, int turn)
{
	int left_motor_pwm = 0;
	int left_motor_brake = 0;
	int right_motor_pwm = 0;
	int right_motor_brake = 0;

	if(turn > 0)
	{
		/*後輪の駆動方法を決定する*/
		left_motor_pwm = -forward;
		left_motor_brake = 1;
		right_motor_pwm = -forward / 2;
		right_motor_brake = 0;
	}
	else
	{
		/*後輪の駆動方法を決定する*/
		left_motor_pwm = -forward / 2;
		left_motor_brake = 0;
		right_motor_pwm = -forward;
		right_motor_brake = 1;
	}


	/*各モータを駆動する*/
	nxt_motor_set_speed(DRIVE_L, left_motor_pwm, left_motor_brake);
	nxt_motor_set_speed(DRIVE_R, right_motor_pwm, right_motor_brake);
}

int check_maxmin(int value, int max, int min)
{
	if(value > max)
	{
		value = max;
	}
	if(value < min)
	{
		value = min;
	}

	return value;
}
