using System;
using UnityEngine;

namespace CustomObjectPool {
    public class PoolableObject : MonoBehaviour {
        public bool ReleaseWhenDisable = true;
        private Pool _originPool;
        
        public static implicit operator GameObject(PoolableObject obj) => obj.gameObject;
        public void SetPool(Pool pool) => _originPool = pool;

        private void OnDisable()
        {
            if (ReleaseWhenDisable)
                _originPool.ReleaseInstance(this);
        }
    }
}
