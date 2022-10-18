using System.Collections.Generic;
using UnityEngine;

namespace GameEvents {
    
    [CreateAssetMenu(menuName = "GameEvent/Float")]
    public class FloatGameEvent : ScriptableObject {
        private List<FloatGameEventListener> _listeners;

        public void Raise(float data)
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised(data);
            }
        }

        public void RegisterListener(FloatGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnregisterListener(FloatGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
