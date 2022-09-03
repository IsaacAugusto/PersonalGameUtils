using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton {
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour {
        public static MonoBehaviourSingleton<T> Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(this);
        }
    }
}