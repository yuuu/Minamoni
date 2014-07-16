using Minamoni.Target;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace MinamoniTest.Target
{
    [TestFixture]
    class TestNxt
    {
        const int MES_NUM = 2;

        private Nxt nxt_;
        private MRecvMessage mes1_;
        private MRecvMessage mes2_;

        private bool connectNotified_;
        private bool disconnectNotified_;
        private bool errorNotified_;

        [SetUp]
        public void SetUp()
        {
            connectNotified_ = false;
            disconnectNotified_ = false;
            errorNotified_ = false;

            MRecvMessage[] mesList = new MRecvMessage[MES_NUM];

            mes1_ = new MRecvMessage();
            mes2_ = new MRecvMessage();
            mesList[0] = mes1_;
            mesList[1] = mes2_;

            nxt_ = new Nxt(mesList);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void コンストラクタ()
        {
            Assert.IsNull(nxt_.comm);
            Assert.AreEqual(CommStatus.INITIALIZED, nxt_.commStatus);
        }

        [Test]
        public void 接続する()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.Connect(comm);

            Assert.AreEqual(comm, nxt_.comm);
            Assert.AreEqual(CommStatus.CONNECTED, nxt_.commStatus);
        }

        [Test]
        public void 接続後に接続する()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.Connect(comm);
            nxt_.Connect(comm);

            Assert.AreEqual(comm, nxt_.comm);
            Assert.AreEqual(CommStatus.CONNECTED, nxt_.commStatus);
        }

        [Test]
        public void 初期化後に切断する()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.Disconnect();

            Assert.AreEqual(CommStatus.INITIALIZED, nxt_.commStatus);
        }

        [Test]
        public void 接続中に切断する()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.Connect(comm);
            nxt_.Disconnect();

            Assert.AreEqual(CommStatus.DISCONNECTED, nxt_.commStatus);
        }

        [Test]
        public void 受信する()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.Connect(comm);
            comm.Received();

            Assert.True(comm.Readed);
            Assert.True(mes1_.Received);
            Assert.True(mes2_.Received);
        }

        [Test]
        public void 接続通知できる()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.connectHandler += new ConnectEventHandler(接続通知先);
            nxt_.Connect(comm);

            Assert.True(connectNotified_);
        }

        [Test]
        public void 切断通知できる()
        {
            MSerialPort comm = new MSerialPort();
            nxt_.disconnectHandler += new DisconnectEventHandler(切断通知先);
            nxt_.Connect(comm);
            nxt_.Disconnect();

            Assert.True(disconnectNotified_);
        }

        [Test]
        public void 異常通知できる()
        {
            MSerialPort comm = new MSerialPort();
            comm.Error = true;
            nxt_.errorHandler += new CommErrorEventHandler(異常通知先);
            nxt_.Connect(comm);

            Assert.True(errorNotified_);
        }


        private void 接続通知先()
        {
            connectNotified_ = true;
        }

        private void 切断通知先()
        {
            disconnectNotified_ = true;
        }

        private void 異常通知先()
        {
            errorNotified_ = true;
        }
    }
}
