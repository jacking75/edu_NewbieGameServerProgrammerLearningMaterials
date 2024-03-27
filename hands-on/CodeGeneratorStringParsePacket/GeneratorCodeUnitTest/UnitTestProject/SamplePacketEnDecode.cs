using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class PacketEnDecodeUtil
    {
        public static void StringTo(string text, List<byte> packetData)
        {
            byte[] temp = Encoding.Unicode.GetBytes(text);
            packetData.AddRange(BitConverter.GetBytes((short)temp.Length));
            packetData.AddRange(temp);
        }

        // 다양한 타입으로 만든다.
        public static void ArrayTo(List<short> valueList, List<byte> packetData)
        {
            var count = valueList.Count();

            for (int i = 0; i < count; ++i)
            {
                packetData.AddRange(BitConverter.GetBytes(valueList[i]));
            }
        }
        public static void ArrayTo(List<int> valueList, List<byte> packetData)
        {
            var count = valueList.Count();

            for (int i = 0; i < count; ++i)
            {
                packetData.AddRange(BitConverter.GetBytes(valueList[i]));
            }
        }


        public static bool ToString(byte[] packetData, ref int readPos, ref string destString)
        {
            var stringLength = BitConverter.ToInt16(packetData, readPos);
            readPos += 2;
            destString = System.Text.Encoding.Unicode.GetString(packetData, readPos, stringLength);
            readPos += stringLength;

            return true;
        }

        // 다양한 타입으로 만든다.
        public static void ToCollection(byte[] packetData, ref int readPos, int count, List<byte> collection)
        {
            for (short i = 0; i < count; ++i)
            {
                collection.Add(packetData[readPos]);
                readPos += 1;
            }
        }
        public static void ToCollection(byte[] packetData, ref int readPos, int count, List<sbyte> collection)
        {
            for (short i = 0; i < count; ++i)
            {
                collection.Add((sbyte)packetData[readPos]);
                readPos += 1;
            }
        }
        public static void ToCollection(byte[] packetData, ref int readPos, int count, List<short> collection)
        {
            for (short i = 0; i < count; ++i)
            {
                collection.Add(BitConverter.ToInt16(packetData, readPos));
                readPos += 2;
            }
        }
        public static void ToCollection(byte[] packetData, ref int readPos, int count, List<int> collection)
        {
            for (short i = 0; i < count; ++i)
            {
                collection.Add(BitConverter.ToInt32(packetData, readPos));
                readPos += 4;
            }
        }
    }

    public class PKTReqLoginEnDecode
    {
        public static void Encode(List<byte> packetData, PKTReqLogin packet)
        {
            packetData.AddRange(BitConverter.GetBytes(packet.IDLength));
            PacketEnDecodeUtil.StringTo(packet.ID, packetData);
            packetData.AddRange(BitConverter.GetBytes(packet.PWLength));
            PacketEnDecodeUtil.StringTo(packet.PW, packetData);
        }

        public static bool Decode(byte[] packetData, ref PKTReqLogin packet)
        {
            int readPos = 0;
            
            packet.IDLength = BitConverter.ToInt16(packetData, readPos);
            readPos += 2;

            PacketEnDecodeUtil.ToString(packetData, ref readPos, ref packet.ID);
            
            packet.PWLength = BitConverter.ToInt16(packetData, readPos);
            readPos += 2;

            PacketEnDecodeUtil.ToString(packetData, ref readPos, ref packet.PW);
            
            return true;
        }
    }


    public class PKTArrayTest1EnDecode
    {
        public static void Encode(List<byte> packetData, PKTArrayTest1 packet)
        {
            packetData.AddRange(BitConverter.GetBytes(packet.Count));
            PacketEnDecodeUtil.ArrayTo(packet.ValueList, packetData);
        }

        public static bool Decode(byte[] packetData, ref PKTArrayTest1 packet)
        {
            int readPos = 0;

            packet.Count = BitConverter.ToInt16(packetData, readPos);
            readPos += 2;

            PacketEnDecodeUtil.ToCollection(packetData, ref readPos, packet.Count, packet.ValueList);
            
            return true;
        }
    }


    public class PKTArrayTest2EnDecode
    {
        public static void Encode(List<byte> packetData, PKTArrayTest2 packet)
        {
            packetData.AddRange(BitConverter.GetBytes(packet.Count));

            for (int i = 0; i < packet.Count; ++i)
            {
                packetData.AddRange(BitConverter.GetBytes(packet.ItemList[i].ItemCode));
                packetData.AddRange(BitConverter.GetBytes(packet.ItemList[i].Level));
                packetData.AddRange(BitConverter.GetBytes(packet.ItemList[i].Exp));
            }
        }

        public static bool Decode(byte[] packetData, ref PKTArrayTest2 packet)
        {
            int readPos = 0;

            packet.Count = BitConverter.ToInt16(packetData, readPos);
            readPos += 2;

            for (short i = 0; i < packet.Count; ++i)
            {
                var charItem = new CharItem();
                charItem.ItemCode = BitConverter.ToInt32(packetData, readPos);
                readPos += 4;
                charItem.Level = BitConverter.ToInt32(packetData, readPos);
                readPos += 4;
                charItem.Exp = BitConverter.ToSingle(packetData, readPos);
                readPos += 4;

                packet.ItemList.Add(charItem);
            }

            return true;
        }
    }
}
