using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject prefab;
    private int poolSize = 10;

    public float IntervalMin = 1.5f;
    public float IntervalMax = 2f;

    public float yMin = -1f;
    public float yMax = 1f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private float interval;
    private float timer = 0;

    private GameManager gameManager;

    private void Awake()
    {
        platforms = new GameObject[poolSize];

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i] = Instantiate(prefab);
            platforms[i].SetActive(false);
        }
    }

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        Spawn();
    }

    private void Update()
    {
        if (gameManager.IsGameOver)
            return;

        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        var position = transform.position;

        position.y = Random.Range(yMin, yMax);

        platforms[currentIndex].transform.position = position;
        platforms[currentIndex].SetActive(true);
        currentIndex = (currentIndex + 1) % platforms.Length;

        interval = Random.Range(IntervalMin, IntervalMax);
    }














    //public GameObject platform;
    //public Transform createPoint;

    //public GameManager gameManager;

    //float spawnRateMin = 2f;
    //float spawnRateMax = 3f;

    //float SpawnRangeY = 2f;

    //float randomTime;

    //bool startTime;

    //float timer = 0;

    //private void Start()
    //{
    //    randomTime = Random.Range(spawnRateMin, spawnRateMax);
    //    startTime = true;
    //}

    //private void Update()
    //{
    //    timer += Time.deltaTime;

    //    if ((startTime || timer > randomTime) && !gameManager.IsGameOver)
    //    {
    //        Vector3 spawnPos = createPoint.position + new Vector3(20, Random.Range(-SpawnRangeY, SpawnRangeY), 0);

    //        Instantiate(platform, spawnPos, Quaternion.identity);

    //        timer = 0f;
    //        randomTime = Random.Range(spawnRateMin, spawnRateMax);
    //        startTime = false;
    //    }

    //}




}
