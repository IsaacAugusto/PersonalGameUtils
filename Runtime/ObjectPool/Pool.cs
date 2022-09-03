using System.Collections.Generic;
using UnityEngine;

namespace CustomObjectPool {
    public class Pool {
        private Stack<PoolableObject> _free = new Stack<PoolableObject>();

        public int Count => _free.Count;

        public void AddToPool(PoolableObject obj)
        {
            _free.Push(obj);
        }

        public bool TryGetFromPool(out PoolableObject poolableObject)
        {
            if (_free.TryPop(out var _poolableObject))
            {
                poolableObject = _poolableObject;
                return true;
            }
            
            poolableObject = default;
            return false;
        }

        public void ReleaseInstance(PoolableObject obj)
        {
            _free.Push(obj);
        }
    }
}
