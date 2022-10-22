using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEvents {
    /// <summary>
    /// Don't use it frequently, boxing to Object is expensive.
    /// </summary>
    
    [CreateAssetMenu(menuName = "GameEvent/Object")]
    public class ObjectGameEvent : ScriptableObject {
        private List<ObjectGameEventListener> _listeners;

        public void Raise(Object data)
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised(data);
            }
        }

        public void RegisterListener(ObjectGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnregisterListener(ObjectGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

}
