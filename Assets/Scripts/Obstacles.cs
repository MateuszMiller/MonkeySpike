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
    public int difficultyIncrement;
    public GameObject[] leftSpawnerList;

    public GameObject[] rightSpawnerList;

    public GameObject banana;

    public Difficulty[] difficulties;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SpawnObstacle()
    {
        if (Movement.facingRight)
        {
            foreach (GameObject spike in leftSpawnerList)
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
                int randomSpikeIndex = Random.Range(0, leftSpawnerList.Length);
                while (activeSpikes.Contains(randomSpikeIndex))
                {
                    randomSpikeIndex = Random.Range(0, leftSpawnerList.Length);
                }
                activeSpikes.Add(randomSpikeIndex);

                rightSpawnerList[randomSpikeIndex].SetActive(true);
            }
        }
        else
        {
            foreach (GameObject spike in rightSpawnerList)
            {
                spike.SetActive(false);
            }

            if (gameManager == null)
                gameManager = GameManager.Instance;

            int difficultyLevel = (gameManager.points + 1) / difficultyIncrement;
            if (difficultyLevel > difficulties.Length - 1)
                difficultyLevel = difficulties.Length - 1;

            List<int> activeSpikes = new List<int>();
            for (int i = 0; i < difficulties[difficultyLevel].spikesCount; i++)
            {
                int randomSpikeIndex = Random.Range(0, leftSpawnerList.Length);
                while (activeSpikes.Contains(randomSpikeIndex))
                {
                    randomSpikeIndex = Random.Range(0, leftSpawnerList.Length);
                }
                activeSpikes.Add(randomSpikeIndex);

                leftSpawnerList[randomSpikeIndex].SetActive(true);
            }
        }
        
    }
}

