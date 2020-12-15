using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Combat {
    public class Firing : MonoBehaviour {
        [SerializeField] private GameObject bulletPrefab = null;
        [SerializeField] private Transform bulletSpawnPoint = null;
        [SerializeField] private float bulletSpeed = 90f;

        private bool isFiring;


        private void Update() {
            if (isFiring) {
                Shoot();
            }
        }


        public void onPointerDown() {
            isFiring = true;
        } 


        public void onPointerUp() {
            isFiring = false;
        }

        private void Shoot() {            
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse) ;

            Destroy(bulletInstance, 5f);
        }


    }
}

