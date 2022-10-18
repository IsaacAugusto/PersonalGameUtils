using UnityEngine;
using UnityEngine.Events;

namespace GameEvents {

    public class FloatGameEventListener : MonoBehaviour {
        [SerializeField] private FloatGameEvent _gameEvent;
        [SerializeField] private UnityEvent<float> _response;

        public void OnEventRaised(float data)
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
