using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitSamplePacket
    {
        [TestMethod]
        public void TestMethod_ReqLoginEnDecode()
        {
            PKTReqLogin loginPacket = new PKTReqLogin
            {
                IDLength = 6,
                ID = "test고고",
                PWLength = 4,
                PW = "1234"
            };

            var packetData = new List<byte>();

            PKTReqLoginEnDecode.Encode(packetData, loginPacket);

            PKTReqLogin loginPacket2 = new PKTReqLogin();
            PKTReqLoginEnDecode.Decode(packetData.ToArray(), ref loginPacket2);

            Assert.AreEqual(loginPacket.IDLength, loginPacket2.IDLength);
            Assert.AreEqual(loginPacket.ID, loginPacket2.ID);
            Assert.AreEqual(loginPacket.PWLength, loginPacket2.PWLength);
            Assert.AreEqual(loginPacket.PW, loginPacket2.PW);
        }


        [TestMethod]
        public void TestMethod_PKTArrayTest1EnDecode()
        {
            var reqPacket = new PKTArrayTest1();
            reqPacket.Count = 3;
            reqPacket.ValueList.AddRange(new int[] { 4,7,2});
            
            var packetData = new List<byte>();

            PKTArrayTest1EnDecode.Encode(packetData, reqPacket);

            var reqPacket2 = new PKTArrayTest1();
            PKTArrayTest1EnDecode.Decode(packetData.ToArray(), ref reqPacket2);

            Assert.AreEqual(reqPacket.Count, reqPacket2.Count);
            Assert.AreEqual(reqPacket.ValueList[0], reqPacket2.ValueList[0]);
            Assert.AreEqual(reqPacket.ValueList[1], reqPacket2.ValueList[1]);
            Assert.AreEqual(reqPacket.ValueList[2], reqPacket2.ValueList[2]);
        }



        [TestMethod]
        public void TestMethod_PKTArrayTest2EnDecode()
        {
            var reqPacket = new PKTArrayTest2();
            reqPacket.Count = 2;
            reqPacket.ItemList.Add(new CharItem { ItemCode = 4, Level = 17, Exp = 201.23f });
            reqPacket.ItemList.Add(new CharItem { ItemCode = 15, Level = 11, Exp = 141.53f });

            var packetData = new List<byte>();

            PKTArrayTest2EnDecode.Encode(packetData, reqPacket);

            var reqPacket2 = new PKTArrayTest2();
            PKTArrayTest2EnDecode.Decode(packetData.ToArray(), ref reqPacket2);

            Assert.AreEqual(reqPacket.Count, reqPacket2.Count);
            Assert.AreEqual(reqPacket.ItemList[0].ItemCode, reqPacket2.ItemList[0].ItemCode);
            Assert.AreEqual(reqPacket.ItemList[0].Level, reqPacket2.ItemList[0].Level);
            Assert.AreEqual(reqPacket.ItemList[0].Exp, reqPacket2.ItemList[0].Exp);
            Assert.AreEqual(reqPacket.ItemList[1].ItemCode, reqPacket2.ItemList[1].ItemCode);
            Assert.AreEqual(reqPacket.ItemList[1].Level, reqPacket2.ItemList[1].Level);
            Assert.AreEqual(reqPacket.ItemList[1].Exp, reqPacket2.ItemList[1].Exp);
        }
    }
}
