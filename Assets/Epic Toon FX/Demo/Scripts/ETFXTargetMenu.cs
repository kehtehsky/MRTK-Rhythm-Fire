using UnityEngine;
using System.Collections;

namespace EpicToonFX
{

    public class ETFXTargetMenu : MonoBehaviour
    {
        

        [Header("Effect shown on target hit")]
	    public GameObject hitParticle;
        [Header("Effect shown on target respawn")]
	    public GameObject respawnParticle;
	    public Renderer targetRenderer;
	    public Collider targetCollider;

        private GameManagerScript gameManager;

      
        void Start()
        {
		    targetRenderer = GetComponent<Renderer>();
		    targetCollider = GetComponent<Collider>();

            //gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
            

            
        }

        private void Update()
        {
            targetRenderer = GetComponent<Renderer>();
            Color c = targetRenderer.material.color;

            
        }

        public void SpawnTarget()
        {
            targetRenderer = GetComponent<Renderer>();
            targetCollider = GetComponent<Collider>();

            
            
            targetRenderer.enabled = true; //Shows the target
		    targetCollider.enabled = true; //Enables the collider
		    GameObject respawnEffect = Instantiate(respawnParticle, transform.position, transform.rotation) as GameObject; //Spawns attached respawn effect
		    Destroy(respawnEffect, 3.5f); //Removes attached respawn effect after x seconds

            

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Missile") // If collider is tagged as missile
            {
                if (hitParticle)
                {
				    //Debug.Log("Target hit!");
				    GameObject destructibleEffect = Instantiate(hitParticle, transform.position, transform.rotation) as GameObject; // Spawns attached hit effect
				    Destroy(destructibleEffect, 2f); // Removes hit effect after x seconds
				    targetRenderer.enabled = false; // Hides the target
				    targetCollider.enabled = false; // Disables target collider
				    StartCoroutine(Respawn()); // Sets timer for respawning the target
                    
                }
            }
        }

       

        IEnumerator Respawn()
        {
            yield return new WaitForSeconds(2);
		    SpawnTarget();
        }

       
    }
}
