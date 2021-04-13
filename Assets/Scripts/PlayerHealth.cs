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

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerDead = false;
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }


    public void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            time = 0;
            TakeDamage(-1);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isPlayerDead)
        {
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
