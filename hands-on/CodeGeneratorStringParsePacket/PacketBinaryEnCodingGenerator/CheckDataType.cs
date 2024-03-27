using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBinaryEnCodingGenerator
{
    class CheckDataType
    {
        public static bool Is_CppBasicType(string typeName)
        {
            if (IsCppNumberType(typeName) || IsCppUnicodeCharacterType(typeName))
            {
                return true;
            }

            return false;
        }

        public static bool IsCppNumberType(string typeName)
        {
            if (Is_char(typeName) || Is_uchar(typeName) ||
                Is_short(typeName) || Is_ushort(typeName) ||
                Is_int(typeName) || Is_uint(typeName) ||
                Is_int64(typeName) || Is_uint64(typeName) ||
                Is_float(typeName) || Is_double(typeName) 
                )
            {
                return true;
            }

            return false;
        }

        public static bool Is_char(string typeName) 
        { 
            if(typeName == "char")
            {
                return true;
            }
            
            return false; 
        }
        
        public static bool Is_uchar(string typeName) 
        {
            if (typeName == "unsigned char")
            {
                return true;
            }

            return false;
        }
        
        public static bool Is_short(string typeName) 
        {
            if (typeName == "short" || typeName == "INT16")
            {
                return true;
            }

            return false;
        }

        public static bool Is_ushort(string typeName)
        {
            if (typeName == "unsigned short" || typeName == "UINT16")
            {
                return true;
            }

            return false;
        }

        public static bool Is_int(string typeName)
        {
            if (typeName == "int" || typeName == "INT32")
            {
                return true;
            }

            return false;
        }

        public static bool Is_uint(string typeName)
        {
            if (typeName == "unsigned int" || typeName == "UINT32")
            {
                return true;
            }

            return false;
        }

        public static bool Is_int64(string typeName)
        {
            if (typeName == "__int64" || typeName == "INT64")
            {
                return true;
            }

            return false;
        }

        public static bool Is_uint64(string typeName)
        {
            if (typeName == "unsigned __int64" || typeName == "UINT64")
            {
                return true;
            }

            return false;
        }

        public static bool Is_float(string typeName)
        {
            if (typeName == "float")
            {
                return true;
            }

            return false;
        }

        public static bool Is_double(string typeName)
        {
            if (typeName == "double")
            {
                return true;
            }

            return false;
        }

        public static bool IsCppUnicodeCharacterType(string typeName)
        {
            if (typeName == "wchar_t")
            {
                return true;
            }

            return false;
        }



        public static short CSharpTypeSize(string typeName)
        {
            short size = 0;

            if (typeName == "byte" || typeName == "sbyte" || 
                typeName == "Int8" || typeName == "UInt8" ||
                typeName == "System.Int8" || typeName == "System.UInt8")
            {
                size = 1;
            }

            if (typeName == "short" || typeName == "unsigned short" || 
                typeName == "Int16" || typeName == "UInt16" ||
                typeName == "System.Int16" || typeName == "System.UInt16")
            {
                size = 2;
            }

            if (typeName == "int" || typeName == "unsigned int" || 
                typeName == "Int32" || typeName == "UInt32" ||
                typeName == "System.Int32" || typeName == "System.UInt32" ||
                typeName == "float" || typeName == "System.Single")
            {
                size = 4;
            }

            if (typeName == "double" || typeName == "System.Double" || 
                typeName == "Int64" || typeName == "UInt64" ||
                typeName == "System.Int64" || typeName == "System.UInt64" || 
                typeName == "long" || typeName == "ulong")
            {
                size = 8;
            }

            if (typeName == "String" || typeName == "System.String" || typeName == "string")
            {
                size = 1024;
            }
                        
            return size;
        }

        public static bool IsCSharpNumberType(string typeName)
        {
            if (typeName == "byte" || typeName == "sbyte" ||
                typeName == "Int8" || typeName == "UInt8" ||
                typeName == "System.Int8" || typeName == "System.UInt8" || 
               typeName == "short" || typeName == "unsigned short" || 
               typeName == "Int16" || typeName == "UInt16" ||
               typeName == "System.Int16" || typeName == "System.UInt16" || 
               typeName == "int" || typeName == "unsigned int" || 
               typeName == "Int32"  || typeName == "UInt32" ||
               typeName == "System.Int32" || typeName == "System.UInt32" || 
               typeName == "float"  || typeName == "double" ||
               typeName == "System.Single" || typeName == "System.Double" || 
               typeName == "Int64"  || typeName == "UInt64" ||
               typeName == "System.Int64" || typeName == "System.UInt64" || 
               typeName == "long"   || typeName == "ulong"
                )
            {
                return true;
            }
            
            return false;
        }

        public static bool IsCSharpCharacterType(string typeName)
        {
            if (typeName == "System.String" || typeName == "String" || typeName == "string")
            {
                return true;
            }

            return false;
        }
    }
}
