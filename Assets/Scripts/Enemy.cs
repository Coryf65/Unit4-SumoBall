using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.SumoBall
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 3f;

        private Rigidbody enemyRb = null;
        private GameObject player = null;

        void Awake()
        {
            enemyRb = GetComponent<Rigidbody>();
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            // a - b = c, Enemies position - Our Position = the direction to go
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed); 
            // using .normalized it will level of the vector
            // bug where the greater the distance the more power
        }
    }
}
