using System;
using UnityEngine;
using UnityEngine.AI;

namespace GhostCharacter_Free.Scripts
{
    public class GhostMove : MonoBehaviour
    {
        public NavMeshAgent agent;
        public float speed;
        public Animator animator;

        // Update is called once per frame
        void Update()
        {
            GameObject target = FindClosestOrb();
            if (target != null && agent.enabled)
            {
                agent.SetDestination(target.transform.position);
                agent.speed = speed;
            }
        }

        private GameObject FindClosestOrb()
        {
            GameObject [] orbs = GameObject.FindGameObjectsWithTag("Orb");
            GameObject closestOrb = null;
            float minDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (GameObject orb in orbs)
            {
                float distance = Vector3.Distance(currentPosition, orb.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestOrb = orb;
                }
            }
            
            return closestOrb;
        }
        
        public void Kill()
        {
            agent.enabled = false;
            animator.SetTrigger("Death");
            // GameManager.Instance.CheckGameStatus();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Orb")
            {
                Destroy(other.gameObject);
                // GameManager.Instance.CheckGameStatus();
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
