using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public int healAmount = 80; 

    private PlayerHealth playerHealth;
    private PlayerItemCollector itemCollector;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        itemCollector = GetComponent<PlayerItemCollector>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (itemCollector != null && playerHealth != null)
            {
                if (itemCollector.GetCherryCount() > 0)
                {
                    itemCollector.UseCherry();
                    playerHealth.Heal(healAmount); 
                }
            }
        }
    }
}
