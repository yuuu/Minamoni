using Minamoni.Target;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace InamoniTest.Target
{
    [TestFixture]
    class TestNxt
    {
        private Nxt nxt_;

        [SetUp]
        public void SetUp()
        {
            nxt_ = new Nxt(null);
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
    }
}
