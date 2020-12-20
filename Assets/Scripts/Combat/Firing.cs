using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Combat {
    public class Firing : MonoBehaviour {
        [SerializeField] private GameObject bulletPrefab = null;
        [SerializeField] private Transform bulletSpawnPoint = null;
        [SerializeField] private float bulletSpeed = 90f;
        [SerializeField] private float fireRate = 1f;

        private float lastFireTime;
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
            if(Time.time > (1 / fireRate) + lastFireTime) {
                GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

                lastFireTime = Time.time;
            }
        }


    }
}

