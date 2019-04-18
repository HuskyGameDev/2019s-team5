namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GunReloading : MonoBehaviour {

        public AdvGunShoot shooter;

        public GameObject[] bulletLocations; // holds the bullets in the chambers
        private bool[] filled; // says whether the corresponding chamber was filled since the last eject

        public GameObject casing; // prefab to spawn ejected casings

        public float ejectSpeed = 100f;
        public float casingLife = 5f;
        private int ammoLimit;

        // Use this for initialization
        void Start() {
            foreach (GameObject bullet in bulletLocations)
                bullet.SetActive(true);

            ammoLimit = shooter.ammoLimit;

            filled = new bool[bulletLocations.Length];
            for (int i = 0; i < filled.Length; i++)
                filled[i] = true;
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "SnapBullet")
            {
                if (shooter.ammoCount < shooter.ammoLimit)
                {
                    bulletLocations[shooter.ammoCount].SetActive(true);
                    filled[shooter.ammoCount] = true;
                    shooter.ammoCount++;
                    ammoLimit = shooter.ammoCount;
                }

                Destroy(other.gameObject);
            }
        }

        private void FireBullet(int count)
        {
            bulletLocations[ammoLimit - count].SetActive(false);
        }

        private void EjectCasings()
        {

            // remove the bullets currently in the chamber, then spawn an ejected casing
            for (int i = 0; i < bulletLocations.Length; i++)
            {
                GameObject bullet = bulletLocations[i];
                bullet.SetActive(false);
                if (filled[i])
                {
                    Transform spawn = bullet.transform;
                    GameObject clonedProjectile = Instantiate(casing, spawn.position, spawn.rotation);
                    Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                    Vector3 ejectDirection = clonedProjectile.transform.forward;
                    ejectDirection.y -= 1f;
                    if (projectileRigidbody != null)
                    {
                        projectileRigidbody.AddForce(-ejectDirection.normalized * ejectSpeed);
                    }
                    Destroy(clonedProjectile, casingLife);
                }

                filled[i] = false;

            }

            
            
        }
    }
}
