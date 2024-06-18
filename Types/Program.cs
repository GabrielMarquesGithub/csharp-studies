using System;

namespace Types
{
    class Program {
        static void Main(string[] args) { 
            sbyte x1 = 127; // 1 byte -128 to 127
            short x2 = 32767; // 2 bytes -32,768 to 32,767
            int x3 = 2147483647; // 4 bytes -2^31 to 2^31 - 1
            long x4 = 9223372036854775807; // 8 bytes -2^63 to 2^63 - 1
            byte x5 = 255; // 1 byte 0 to 255
            ushort x6 = 65535; // 2 bytes 0 to 65,535
            uint x7 = 4294967295; // 4 bytes 0 to 2^32 - 1
            ulong x8 = 18446744073709551615; // 8 bytes 0 to 2^64 - 1
            float x9 = 3.402823e38f; // 4 bytes -3.402823e38 to 3.402823e38
            double x10 = 1.7976931348623157e308; // 8 bytes -1.7976931348623157e308 to 1.7976931348623157e308
            decimal x11 = 79228162514264337593543950335m; // 16 bytes (-7.9 x 10^28 to 7.9 x 10^28) / 10^0 to 28
            char x12 = 'A'; // 2 bytes Any Unicode character (16 bit)
            bool x13 = true; // 1 byte True or False
            string x14 = "Hello World"; // Any number of characters
            object x15 = null; // Any type can be stored


            Console.WriteLine(x1);
            Console.WriteLine(x14.ToUpper());
        }
    } }
