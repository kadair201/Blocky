﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public GameObject groundPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject grassPrefab;
    public RestartScript restartScript;
    PlayerScript playerScript;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "NuclearCube";
        gameObject.tag = "Floor";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();

        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.WATER);

        if (playerScript.blankCubeType == CubeType.DIRT)
        {
            groundPrefab = dirtPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.SAND)
        {
            groundPrefab = sandPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.SNOW)
        {
            groundPrefab = snowPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.GRASS)
        {
            groundPrefab = grassPrefab;
        }
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 10)
            {
                Destroy(this.gameObject);
            }
        }

        if (transform.position.y > -0.95f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "NuclearCube")
        {
            if (other.GetComponent<NuclearCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<NuclearCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<NuclearCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "PondWaterCube")
        {
            if (other.GetComponent<PondWaterCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "WaterCube")
        {
            if (other.GetComponent<WaterCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "SandCube")
        {
            if (other.GetComponent<SandCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FireCube" || other.name == "WoodCube" || other.name == "FlowerCube" || other.name == "BurningCube" || other.name == "StoneCube" || other.name == "TreeCube" || other.name == "LongGrassCube" || other.name == "LanternCube")
        {
            Vector3 position = this.transform.position;
            Debug.Log(groundPrefab);
            if (groundPrefab == null)
            {
                Debug.Log(playerScript.blankCubePrefab);
                
            }
            GameObject newCube = Instantiate(groundPrefab, position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.name == "PavingCube")
        {
            if (timeActive < other.GetComponent<PavingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}