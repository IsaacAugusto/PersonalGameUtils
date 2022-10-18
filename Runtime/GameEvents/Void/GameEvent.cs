using System.Collections.Generic;
using UnityEngine;

namespace GameEvents {

    [CreateAssetMenu(menuName = "GameEvent/Void")]
    public class GameEvent : ScriptableObject {
        private List<GameEventListener> _listeners;

        public void Raise()
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (_listeners.Contains(listener))
                return;

            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
