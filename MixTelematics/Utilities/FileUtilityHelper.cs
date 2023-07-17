﻿using MixTelematics.Models;
using System.Text;

namespace MixTelematics.Utilities
{
    public class FileUtilityHelper
    {
        public static List<VehiclePosition> ReadBinaryDataFile(string filePath)
        {
            List<VehiclePosition> positions = new();

            using (BinaryReader reader = new(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    VehiclePosition position = new()
                    {
                        PositionId = reader.ReadInt32(),
                        VehicleRegistration = ReadNullTerminatedString(reader),
                        Latitude = reader.ReadSingle(),
                        Longitude = reader.ReadSingle(),
                        RecordedTimeUTC = reader.ReadUInt64()
                    };

                    positions.Add(position);
                }
            }

            return positions;
        }

        public static string ReadNullTerminatedString(BinaryReader reader)
        {
            List<byte> bytes = new();

            byte currentByte = reader.ReadByte();
            while (currentByte != 0)
            {
                bytes.Add(currentByte);
                currentByte = reader.ReadByte();
            }

            return Encoding.ASCII.GetString(bytes.ToArray());
        }
    }
}
