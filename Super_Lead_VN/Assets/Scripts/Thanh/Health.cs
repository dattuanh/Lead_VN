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

    DataManager dataManager;

    //AudioSource audioSource;
    AudioLead audioManager;

    private void Awake()
    {
        //currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //audioSource = GetComponent<AudioSource>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioLead>();
        dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
        if (PlayerData.Instance != null)
        {
            currentHealth = PlayerData.Instance.currentHealth;
            Debug.Log("Health loaded from PlayerData: " + currentHealth);
        }
        else
        {
            currentHealth = startingHealth;
            Debug.Log("Starting Health: " + currentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
            PlayerData.Instance.currentHealth = currentHealth;
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
                Time.timeScale = 0;
                dataManager.showEndPanel();
            }
        }
    }
    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, startingHealth);
        //PlayerData.Instance.currentHealth = currentHealth;
        Debug.Log("Health after heal: " + currentHealth);
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
