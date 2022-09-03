using System.IO;
using UnityEngine;

namespace GameData {
    public static class GameData {
        
        private static string _gamePath => Path.Combine(Application.persistentDataPath, "GameData");
        private static BinaryWriter _writer => new BinaryWriter(File.Open(_gamePath, FileMode.Create));
        private static BinaryReader _reader => new BinaryReader(File.Open(_gamePath, FileMode.Open));
        private static bool _checkFile => File.Exists(_gamePath);
            
        #region Write

        public static void WriteInt(int value)
        {
            using var writer = _writer;
            new GameDataWriter(writer).Write(value);
        }
        
        public static void WriteFloat(float value)
        {
            using var writer = _writer;
            new GameDataWriter(writer).Write(value);
        }
        
        public static void WriteVector2(Vector2 value)
        {
            using var writer = _writer;
            new GameDataWriter(writer).Write(value);
        }
        
        public static void WriteVector3(Vector3 value)
        {
            using var writer = _writer;
            new GameDataWriter(writer).Write(value);
        }
        
        public static void WriteQuaternion(Quaternion value)
        {
            using var writer = _writer;
            new GameDataWriter(writer).Write(value);
        }

        #endregion

        #region Read

        public static int ReadInt()
        {
            if (!_checkFile)
                return default;

            using var reader = _reader;
            return new GameDataReader(reader).ReadInt();
        }
        
        public static float ReadFloat()
        {
            if (!_checkFile)
                return default;

            using var reader = _reader;
            return new GameDataReader(reader).ReadFloat();
        }
        
        public static Vector2 ReadVector2()
        {
            if (!_checkFile)
                return default;

            using var reader = _reader;
            return new GameDataReader(reader).ReadVector2();
        }
        
        public static Vector3 ReadVector3()
        {
            if (!_checkFile)
                return default;

            using var reader = _reader;
            return new GameDataReader(reader).ReadVector3();
        }
        
        public static Quaternion ReadQuaternion()
        {
            if (!_checkFile)
                return default;

            using var reader = _reader;
            return new GameDataReader(reader).ReadQuaternion();
        }

        #endregion
    }
}
