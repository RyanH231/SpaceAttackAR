using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ShootCore : MonoBehaviour
{

    public int health;
    public float defendTime;
    private float curDefendTime;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI defendText;

    public GameObject winScreen;
    public GameObject loseScreen;
    public bool gameOver;

    private Camera cam;

    public static ShootCore instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Hp : " + health;
        cam = Camera.main;
        curDefendTime = defendTime;
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.transform.rotation = Quaternion.LookRotation(healthText.transform.position - cam.transform.position);
        if(gameOver)
        {
            return;
        }
        defendText.text = "Defend for : " + Mathf.RoundToInt(curDefendTime) + "s";
        curDefendTime -= Time.deltaTime;

        if(curDefendTime<= 0.0f)
        {
            WinGame();
        }
       
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Hp : " + health;
        if (health <= 0)
        {
            GameOver();
        }
    }

    void WinGame()
    {
        gameOver = true;
        winScreen.SetActive(true);
        EnemySpawn.instance.canSpawn = false;
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        gameOver = true;
        loseScreen.SetActive(true);
        EnemySpawn.instance.canSpawn = false;
    }
}
