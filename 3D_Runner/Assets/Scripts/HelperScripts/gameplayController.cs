using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class gameplayController : MonoBehaviour
{
    public static gameplayController instance;

    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    public Transform [] lanes;
    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundSize;
    private BaseController plyerController;

    private TMP_Text score_Text;
    private int zombieKillCount;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gamweOverPanel;
    [SerializeField] private TMP_Text final_Score;


    void Awake ()
    {
        MakeIntance();
    }

    void Start()
    {
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<GroundBlock>().halfLength;
        plyerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();
        StartCoroutine("GenerateObstacles");

        score_Text = GameObject.Find("Text Sc").GetComponent<TMP_Text>();
    }

    void MakeIntance()
    {
        // important theme of singelton, but its not a singelton, just an instance
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    IEnumerator GenerateObstacles()
    {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay)/plyerController.speed.z;
        yield return new WaitForSeconds(timer);
        CreateObstacles(plyerController.gameObject.transform.position.z+halfGroundSize);//position of player plus offset of half ground track
        StartCoroutine("GenerateObstacles");

    }
     void CreateObstacles(float zPos)
    {
        int r = Random.Range(0, 10);
        if (0 <= r && r<7)
        {
            int obstacleLane = Random.Range(0, lanes.Length);// mean 012
            // 0 1 2

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, 0.1f, zPos),
                Random.Range(0,obstaclePrefabs.Length));

            int zombieLane = 0;

            
            //creating obstacle on line, that not same previos line(0,1,2)
            if (obstacleLane == 0)
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            else if (obstacleLane == 1)
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            else if (obstacleLane == 2)
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 0;

            AddZombies(new Vector3(lanes[zombieLane].transform.position.x, 0f, zPos));
        }

            
    }

    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;
            case 4:
                obstacle.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                break;
            case 5:
                obstacle.transform.position = new Vector3(0f, 0.5f, 0f);
                break;
        }
        obstacle.transform.position = position;
    }

    void AddZombies(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;

        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f) * i);
            Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)],
                pos + shift * i, Quaternion.identity);
        }
    }

    public void IncreaseScore()
    {
        zombieKillCount++;
        score_Text.text = zombieKillCount.ToString();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gamweOverPanel.SetActive(true);
        final_Score.text = "Killed: "+ zombieKillCount.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
