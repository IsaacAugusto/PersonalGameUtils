using System.IO;
using UnityEngine;

namespace GameData {
    public class GameDataReader {
        private BinaryReader _reader;

        public GameDataReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public float ReadFloat()
        {
            return _reader.ReadSingle();
        }
        
        public int ReadInt()
        {
            return _reader.ReadInt32();
        }

        public Vector2 ReadVector2()
        {
            var vector = new Vector2();
            vector.Set(_reader.ReadSingle(), _reader.ReadSingle());
            return vector;
        }

        public Vector3 ReadVector3()
        {
            var vector = new Vector3();
            vector.Set(_reader.ReadSingle(), _reader.ReadSingle(), _reader.ReadSingle());
            return vector;
        }

        public Quaternion ReadQuaternion()
        {
            var quaternion = new Quaternion();
            quaternion.Set(_reader.ReadSingle(), _reader.ReadSingle(), _reader.ReadSingle(), _reader.ReadSingle());
            return quaternion;
        }
    }
}
