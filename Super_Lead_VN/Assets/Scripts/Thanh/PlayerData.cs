using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public float currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("PlayerData created. Current Health: " + currentHealth);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
