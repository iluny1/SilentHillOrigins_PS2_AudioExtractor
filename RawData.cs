using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentHillOrigins_PS2_RWSAudioExtract
{
    internal class RawData(int frequency, uint size, string name, byte[] data)
    {
        public int Frequency { get; } = frequency;
        public uint Size { get; } = size;
        public string Name { get; } = name;
        public byte[] Data { get; } = data;
    }

    static class RawData_Array
    {
        private static readonly List<RawData> rawDatas = new List<RawData>();

        public static void AddData(RawData data)
        {
            if (!CheckExist(data.Name, data.Frequency, data.Size))
                rawDatas.Add(data);
        }

        public static List<RawData> GetAllData()
        {
            return rawDatas;
        }

        public static string[] GetListOfData()
        {
            if (!HasData()) return [ "NO DATA" ];

            string[] dataStrings = new string[rawDatas.Count];
            int i = 0;

            foreach (RawData data in rawDatas)
            {
                dataStrings[i] = $"{data.Name}";
                i++;
            }

            return dataStrings;
        }

        public static bool HasData()
        {
            if (rawDatas.Count > 0) return true;
            else return false;
        }

        public static void ClearData()
        {
            rawDatas.Clear();
        }

        public static RawData GetDataForFile(int index)
        {
            if (index >= rawDatas.Count || index < 0)
                return new RawData(0, 0, "Error. Wrong index", null);

            return rawDatas[index];
        }

        public static bool CheckExist(string name, int freq, uint size)
        {
            foreach(RawData data in rawDatas)
            {
                if (data.Name == name && data.Size == size && data.Frequency == freq)
                    return true;
            }

            return false;
        }

    }
}
