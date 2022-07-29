using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Public variables
    public GameObject player;
    public GameObject playerGun;
    public Text healthText;
    public GameObject particles;

    public GameObject redHelper;
    public GameObject orangeHelper;
    public GameObject yellowHelper;
    public GameObject greenHelper;
    public GameObject tealHelper;
    public GameObject blueHelper;
    public GameObject purpleHelper;
    public GameObject pinkHelper;

    public AudioClip deathSound;
    public AudioClip damageSound;

    // Private variables
    private int maxHealth;
    private int currentHealth;
    private bool isInvulnerable = false;
    private float invulnerabilityDuration = 1.5f;
    private GameObject enemySpawner;
    private CameraMovement cam;
    private AudioSource audioManager;
    public Score finalScore;

    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        enemySpawner = GameObject.Find("Enemy Spawner");
        cam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInvulnerable)
            return;

        if (collision.transform.tag == "Enemy")
        {
            currentHealth--;
            healthText.text = "HEALTH: " + currentHealth;

            audioManager.clip = damageSound;

            if (currentHealth <= 0)
            {
                audioManager.clip = deathSound;
                cam.enabled = false;
                enemySpawner.SetActive(false);
                redHelper.GetComponent<Helper>().DestroyHelper();
                orangeHelper.GetComponent<Helper>().DestroyHelper();
                yellowHelper.GetComponent<Helper>().DestroyHelper();
                greenHelper.GetComponent<Helper>().DestroyHelper();
                tealHelper.GetComponent<Helper>().DestroyHelper();
                blueHelper.GetComponent<Helper>().DestroyHelper();
                purpleHelper.GetComponent<Helper>().DestroyHelper();
                pinkHelper.GetComponent<Helper>().DestroyHelper();
                ParticleSystem.MainModule main = particles.GetComponent<ParticleSystem>().main;
                main.startColor = color;
                main.duration = 2;
                ParticleSystem.ShapeModule shapes = particles.GetComponent<ParticleSystem>().shape;
                shapes.radius = 2;
                GameObject particleEffects = Instantiate(particles, transform.position, transform.rotation);
                audioManager.Play();
                finalScore.GameOverScore();
                Destroy(gameObject);
            }
            audioManager.Play();
            StartCoroutine(TempInvulnerability());
        }
    }

    private IEnumerator TempInvulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    } 
}
