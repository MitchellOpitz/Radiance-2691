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

    public GameObject redHelper;
    public GameObject orangeHelper;
    public GameObject yellowHelper;
    public GameObject greenHelper;
    public GameObject tealHelper;
    public GameObject blueHelper;
    public GameObject purpleHelper;
    public GameObject pinkHelper;

    // Private variables
    private int maxHealth;
    private int currentHealth;
    private bool isInvulnerable = false;
    private float invulnerabilityDuration = 1.5f;
    private GameObject enemySpawner;
    private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        enemySpawner = GameObject.Find("Enemy Spawner");
        cam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
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

            if(currentHealth <= 0)
            {
                cam.enabled = false;
                enemySpawner.SetActive(false);
                redHelper.SetActive(false);
                orangeHelper.SetActive(false);
                yellowHelper.SetActive(false);
                greenHelper.SetActive(false);
                tealHelper.SetActive(false);
                blueHelper.SetActive(false);
                purpleHelper.SetActive(false);
                pinkHelper.SetActive(false);
                Destroy(gameObject);
            }

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
