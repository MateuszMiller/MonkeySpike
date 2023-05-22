using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Difficulty
{
    public int spikesCount;
    public float playerSpeed;
}

public class Obstacles : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Difficulty[] difficulties;
    [SerializeField] private int difficultyIncrement;

    [Header("Instances")]
    [SerializeField] private GameObject[] leftSpawnerList;
    [SerializeField] private GameObject[] rightSpawnerList;
    [SerializeField] private GameObject banana;

    private GameManager gameManager;
    private int lastBananaIndex = -9;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SpawnObstacle()
    {
        GameObject[] spawner = Movement.facingRight ? rightSpawnerList : leftSpawnerList;
        GameObject[] otherSpawner = Movement.facingRight ? leftSpawnerList : rightSpawnerList;

        foreach (GameObject spike in otherSpawner)
        {
            spike.SetActive(false);
        }

        if (gameManager == null)
            gameManager = GameManager.Instance;

        int difficultyLevel = (gameManager.points - 1) / difficultyIncrement;
        if (difficultyLevel > difficulties.Length - 1)
            difficultyLevel = difficulties.Length - 1;

        List<int> activeSpikes = new List<int>();
        for (int i = 0; i < difficulties[difficultyLevel].spikesCount; i++)
        {
            int randomSpikeIndex = Random.Range(0, spawner.Length);
            while (activeSpikes.Contains(randomSpikeIndex) && randomSpikeIndex != lastBananaIndex)
            {
                randomSpikeIndex = Random.Range(0, spawner.Length);
            }
            activeSpikes.Add(randomSpikeIndex);

            spawner[randomSpikeIndex].SetActive(true);
        }
        if (!banana.activeSelf)
        {
            int bananaIndex = Random.Range(0, spawner.Length);
            while (activeSpikes.Contains(bananaIndex))
            {
                bananaIndex = Random.Range(0, spawner.Length);
            }
            lastBananaIndex = bananaIndex;
            banana.transform.position = spawner[bananaIndex].transform.position;
            banana.SetActive(true);
        }
    }
}

