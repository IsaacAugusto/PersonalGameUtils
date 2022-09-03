using System.IO;
using UnityEngine;

namespace GameData {
    public class GameDataWriter {
        private BinaryWriter _writer;
        
        public GameDataWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(int value)
        {
            _writer.Write(value);
        }
        
        public void Write(float value)
        {
            _writer.Write(value);
        }
        
        public void Write(Vector3 value)
        {
            _writer.Write(value.x);
            _writer.Write(value.y);
            _writer.Write(value.z);
        }
        
        public void Write(Vector2 value)
        {
            _writer.Write(value.x);
            _writer.Write(value.y);
        }
        
        public void Write(Quaternion value)
        {
            _writer.Write(value.x);
            _writer.Write(value.y);
            _writer.Write(value.z);
            _writer.Write(value.w);
        }
    }
}

