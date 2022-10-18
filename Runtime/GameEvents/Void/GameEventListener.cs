using UnityEngine;
using UnityEngine.Events;

namespace GameEvents {

    public class GameEventListener : MonoBehaviour {

        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _response;

        public void OnEventRaised()
        {
            _response.Invoke();
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
