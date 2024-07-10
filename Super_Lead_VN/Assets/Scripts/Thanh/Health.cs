using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float invincibilityDuration = 1f;
    [SerializeField] private int numberOfFlashes = 3;
    public float currentHealth { get; private set; }
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    //AudioSource audioSource;
    AudioManager audioManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //audioSource = GetComponent<AudioSource>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                // player hurt
                StartCoroutine(InvincibilityFlash());
                audioManager.PlaySFX(audioManager.motorcrash);
            }
            else
            {
                // player died
                Die();
                audioManager.PlaySFX(audioManager.motorexplode);
            }
        }
    }

    private void Die()
    {       
        Destroy(gameObject);       
    }
    private IEnumerator InvincibilityFlash()
    {
        isInvincible = true;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(invincibilityDuration / (numberOfFlashes * 2));
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(invincibilityDuration / (numberOfFlashes * 2));
        }
        isInvincible = false;
    }
}
