using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Combat {
    public class DestroyBullets : MonoBehaviour {

        [SerializeField] private float destroyInSeconds = 5f;

        private void Start() {
            Destroy(gameObject, destroyInSeconds);
        }
    }
}
