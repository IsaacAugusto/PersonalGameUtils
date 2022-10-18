using UnityEngine;
using UnityEngine.Events;

namespace GameEvents {

    public class IntGameEventListener : MonoBehaviour {
        [SerializeField] private IntGameEvent _gameEvent;
        [SerializeField] private UnityEvent<int> _response;

        public void OnEventRaised(int data)
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
