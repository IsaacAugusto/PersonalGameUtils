using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameEvents {
    
    public class ObjectGameEventListener : MonoBehaviour {
        [SerializeField] private ObjectGameEvent _gameEvent;
        [SerializeField] private UnityEvent<Object> _response;

        public void OnEventRaised(Object data)
        {
            _response.Invoke(data);
        }

        private void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }
    }
    
}

