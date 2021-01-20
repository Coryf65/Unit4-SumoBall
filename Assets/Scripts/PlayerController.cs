using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.SumoBall
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public GameObject powerupIndicator = null;

        private bool hasPowerup = false;
        private Rigidbody playerRb = null;
        private GameObject focalPoint = null;
        private float powerupStrength = 20f;

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        // Update is called once per frame
        void Update()
        {
            // get players input
            float forwardInput = Input.GetAxis("Vertical");

            // move the player object
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                powerupIndicator.gameObject.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        // using a countdown timer to expire the powerup
        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7); // wait 7 seconds
            powerupIndicator.gameObject.SetActive(false);
            hasPowerup = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                // add double force!
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

                // apply push
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

                Debug.Log($"Collided with: {collision.gameObject.name} with powerup set to: {hasPowerup}");
            }
        }
    }
}
