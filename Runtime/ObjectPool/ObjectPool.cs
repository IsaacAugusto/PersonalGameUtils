using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomObjectPool {

    public class ObjectPool : MonoBehaviour {
        
        private Dictionary<GameObject, Pool> _freeInstances = new Dictionary<GameObject, Pool>();

        public T AdquireInstance<T>(GameObject Obj) where T : Component
        {
            if (!_freeInstances.TryGetValue(Obj, out var _pool))
            {
                _pool = new Pool();
                _freeInstances.Add(Obj, _pool);
            }

            if (_pool.TryGetFromPool(out var poolableObject))
            {
                poolableObject.gameObject.SetActive(true);
                return poolableObject.GetComponent<T>();;
            }

            return InstantiatePoolableObject(Obj, _pool).GetComponent<T>();
        }
        
        private PoolableObject InstantiatePoolableObject(GameObject Obj, Pool pool)
        {
            var instance = Instantiate(Obj);
            
            if (instance.TryGetComponent<PoolableObject>(out var component))
            {
                component.SetPool(pool);
                return component;
            }
            
            component = instance.AddComponent<PoolableObject>();
            component.SetPool(pool);

            return component;
        }
    }
    
}
