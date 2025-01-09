using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SilentHillOrigins_PS2_RWSAudioExtract
{
    static class ExtractSonyAdpcmWorker
    {     
        private const int RWS_NAME_OFFSET = 0xA4;
        private const int VAG_HEADER_LENGTH = 0x8C;

        private readonly static byte[] VAG_UUID = [ 0x98, 0x97, 0xEA, 0xD9,
                                                 0xBC, 0xBB, 0x7B, 0x44,
                                                 0x96, 0xB2, 0x65, 0x47,
                                                 0x59, 0x10, 0x2E, 0x16];


        public static void DisplayValues(string filePath, bool multiple)
        {
            if (!multiple && RawData_Array.HasData()) RawData_Array.ClearData();

            if (File.Exists(filePath))
            {
                using (var stream = File.Open(filePath, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        reader.ReadBytes(RWS_NAME_OFFSET);

                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            byte[] checkID = reader.ReadBytes(16);

                            if (checkID.SequenceEqual(VAG_UUID))
                            {
                                int hz = reader.ReadInt32(); //Get Frequency (Some files has FQ = 14000Hz)
                                reader.ReadInt32(); //Dummy
                                uint size = reader.ReadUInt32(); //Get size of audio data
                                reader.ReadBytes(0x34); //Dummy
                                string name = RemoveSpecialCharacters(Encoding.ASCII.GetString(reader.ReadBytes(16))); //File name frow stream.
                                reader.ReadBytes(0x2C); //Some data, don't know what is it. But half of it is common for all files.

                                RawData_Array.AddData(new RawData(hz, size, name, reader.ReadBytes((int)size))); //RAW DATA

                                reader.ReadBytes(0x38); //Some garbage or maybe split data
                            }
                        }
                    }
                }
            }
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static byte[] createVagHeader(RawData data)
        {
            byte[] vh = new byte[64];
            byte[] size = new byte[4];
            byte[] frequency = new byte[4];
            byte[] name = new byte[16];

            Encoding.ASCII.GetBytes("VAGp").CopyTo(vh, 0);
            new byte[] { 0x00, 0x00, 0x00, 0x03,
                         0x00, 0x00, 0x00, 0x00}.CopyTo(vh, 4); //VAG version 3;

            BinaryPrimitives.WriteUInt32BigEndian(size, data.Size);
            BinaryPrimitives.WriteInt32BigEndian(frequency, data.Frequency);            

            size.CopyTo(vh, 12);
            frequency.CopyTo(vh, 16);
            Encoding.ASCII.GetBytes(data.Name).CopyTo(vh, 32);

            return vh;
        }
    }
}
