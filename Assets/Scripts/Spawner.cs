using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject BuildingPrefab;
    public float BuildingSpawnInterval;
    public Sprite[] BuildingSprites;
    private float buildingTimer;

	// Use this for initialization
	void Start () {
        buildingTimer = BuildingSpawnInterval;

    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.Instance.IsGameOver)
        {
            if (buildingTimer > 0)
            {
                buildingTimer -= Time.deltaTime;

                if (buildingTimer <= 0)
                {
                    SpawnBuilding();
                    buildingTimer = BuildingSpawnInterval - GameManager.Instance.Level / 3;
                }
            }
        }
	}

    private void SpawnBuilding()
    {
        GameObject building = Instantiate(BuildingPrefab, transform.position + new Vector3(0, UnityEngine.Random.Range(-3.34f, -0.69f), 0), Quaternion.identity, transform);
        Building b = building.GetComponent<Building>();
        b.GetComponent<SpriteRenderer>().sprite = BuildingSprites[UnityEngine.Random.Range(0, BuildingSprites.Length - 1)];
        b.Speed = UnityEngine.Random.Range(0.01f, 0.05f) + GameManager.Instance.Level * 0.002f;
    }
}
