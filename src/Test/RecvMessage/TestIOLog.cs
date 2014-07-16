using Minamoni.RecvMessage.Logfile;
using NUnit.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minamoni.RecvMessage;
using System.Runtime.InteropServices;

namespace MinamoniTest.RecvMessage
{
    [Serializable]
    public struct TestData
    {
        public UInt32 type;
        public UInt32 size;
        public UInt32 index;
        public UInt32 time;
        public UInt32 vattery;
        public Int32 rMotorEnc;
        public Int32 lMotorEnc;
        public Int32 sMotorEnc;
        public UInt32 lightSensor;
        public Int32 gyroSensor;
        public UInt32 sonarSensor;
        public Int32 rMotorPWM;
        public Int32 lMotorPWM;
        public Int32 sMotorPWM;
    };

    [TestFixture]
    class TestIOLog
    {
        String PATH = Directory.GetCurrentDirectory();
        String FILE = @"test.csv";

        private IOLog log_;
        private TestData recvData;

        private BinaryFormatter formatter_;
        private MemoryStream mem_;

        [SetUp]
        public void SetUp()
        {
            formatter_ = new BinaryFormatter();
            mem_ = new MemoryStream();

            recvData = new TestData();
            recvData.type = (UInt32)MessageType.LOG;
            recvData.size = 64;
            recvData.index = 1;
            recvData.time = 2;
            recvData.vattery = 3;
            recvData.rMotorEnc = 4;
            recvData.lMotorEnc = 5;
            recvData.sMotorEnc = 6;
            recvData.lightSensor = 7;
            recvData.gyroSensor = 8;
            recvData.sonarSensor = 9;
            recvData.rMotorPWM = 10;
            recvData.lMotorPWM = 11;
            recvData.sMotorPWM = 12;

            log_ = new IOLog(PATH, FILE);
        }


        [TearDown]
        public void TearDown()
        {
            mem_.Close();
        }

        [Test]
        public void 受信する()
        {
            int size = Marshal.SizeOf(typeof(TestData));
            byte[] binary = new byte[size];
            IntPtr ptr;

            ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(recvData, ptr, false);
            Marshal.Copy(ptr, binary, 0, size);
            Marshal.FreeHGlobal(ptr);

            log_.Receive(binary);
            Record? record = log_.GetRecentRecord();

            Assert.IsNotNull(record);
            Assert.AreEqual(1, record.Value.index);
            Assert.AreEqual(2, record.Value.time);
            Assert.AreEqual(3, record.Value.vattery);
            Assert.AreEqual(4, record.Value.rMotorEnc);
            Assert.AreEqual(5, record.Value.lMotorEnc);
            Assert.AreEqual(6, record.Value.sMotorEnc);
            Assert.AreEqual(7, record.Value.lightSensor);
            Assert.AreEqual(8, record.Value.gyroSensor);
            Assert.AreEqual(9, record.Value.sonarSensor);
            Assert.AreEqual(10, record.Value.rMotorPWM);
            Assert.AreEqual(11, record.Value.lMotorPWM);
            Assert.AreEqual(12, record.Value.sMotorPWM);
        }

        [Test]
        public void 保存する()
        {

        }

        [Test]
        public void 取得する()
        {

        }

        [Test]
        public void 指定したレコード数存在しない時に取得する()
        {

        }

        [Test]
        public void 最新のレコードを取得する()
        {

        }

        [Test]
        public void レコードが空の時に最新のレコードを取得する()
        {

        }
    }
}
