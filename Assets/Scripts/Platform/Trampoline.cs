using System;
using UnityEngine;

namespace Platform
{
    public class Trampoline : MonoBehaviour
    {
        public float bounceForce = 6f;
        public float bounceTime = 0.5f;
        public Animator animator;
        
        private float _bounceTimer;
        
        private void Update()
        {
            if (_bounceTimer > 0)
            {
                _bounceTimer -= Time.deltaTime;
                if (_bounceTimer <= 0)
                {
                    animator.SetBool("bounced", false);
                }
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("NPCPlayer"))
            {
                animator.SetBool("bounced", true);
                _bounceTimer = bounceTime;
                other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounceForce;
            }
        }
    }
}
