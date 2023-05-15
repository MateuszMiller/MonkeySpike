using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] leftSpawnerList;

    public GameObject[] rightSpawnerList;

    public GameObject banana;

    public void SpawnObstacle(int numberOfSpikes)
    {
        if (Movement.facingRight)
        {
            foreach (GameObject spike in leftSpawnerList)
            {
                spike.SetActive(false);
            }
            
            List<int> activeSpikes = new List<int>();
            for (int i = 0; i < numberOfSpikes; i++)
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
            
            List<int> activeSpikes = new List<int>();
            for (int i = 0; i < numberOfSpikes; i++)
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

