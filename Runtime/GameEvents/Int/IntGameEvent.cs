using System.Collections.Generic;
using UnityEngine;

namespace GameEvents {
    
    [CreateAssetMenu(menuName = "GameEvent/Int")]
    public class IntGameEvent : ScriptableObject {
        private List<IntGameEventListener> _listeners;

        public void Raise(int data)
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised(data);
            }
        }

        public void RegisterListener(IntGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnregisterListener(IntGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
