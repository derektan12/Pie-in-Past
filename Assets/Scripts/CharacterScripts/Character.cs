using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxHealth = 100;
    public int maxHP;
    public float health;
    [SerializeField] private Material flashMaterial;


    [SerializeField] private float duration;


    // The SpriteRenderer that should flash.
    public SpriteRenderer spRend;

    // The material that was in use, when the script started.
    public Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flashRoutine;

    

    void Start()
    {
        originalMaterial = spRend.material;
        
    }

    

    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        spRend.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        // After the pause, swap back to the original material.
        spRend.material = originalMaterial;

        // Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }


    

    
    public virtual void Attack()
    {

    }
    public virtual void TakeDamage(float damage) 
    {
        Flash();
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
