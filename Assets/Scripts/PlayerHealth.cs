using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text levelOverText;

    public AudioClip loseSound;
    public bool isPlayerDead;

    int ticks = 0;


    // Start is called before the first frame update
    void Start()
    {
        isPlayerDead = false;
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }


    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0 && !isPlayerDead)
        {
            healthSlider.value = currentHealth;
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        transform.Rotate(-90f, 0f, 0f, Space.Self);
        isPlayerDead = true;
        levelOverText.text = "Game Over";
        levelOverText.enabled = true;
        Invoke("levelReload", 2);
        AudioSource.PlayClipAtPoint(loseSound, this.gameObject.transform.position);
    }
    void levelReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
