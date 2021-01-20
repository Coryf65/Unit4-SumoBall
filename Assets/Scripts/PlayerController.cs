using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.SumoBall
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;

        private Rigidbody playerRb = null;
        private GameObject focalPoint = null;
        private bool hasPowerup = false;

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
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
            }
        }
    }
}
