﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    RestartScript restartScript;
    PlayerScript playerScript;
    public GameObject grassPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject dirtPrefab;
    public GameObject waterPrefab;
    GameObject groundPrefab;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "LilypadCube";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.LILYPAD);

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


        if (transform.position.y != -0.85f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.85f, transform.position.z);
        }


        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0, 0.1f, 0));
        foreach (Collider col in colliders)
        {
            if (col.gameObject.name != "WaterCube" && col.gameObject.name != "LilypadCube" && col.gameObject.name != "PondWaterCube" && col.gameObject.name != "NuclearCube")
            {
                GameObject water = Instantiate(waterPrefab, col.gameObject.transform.position, Quaternion.identity);
            }
        }

        if (restartScript.loading)
        {
            Destroy(this.gameObject);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        //if (other.name == "WaterCube" || other.name == "PondWaterCube" || other.name == "NuclearCube")
        //{
            //Vector3 position = other.transform.position;
            //Destroy(other.gameObject);
            //GameObject newCube = Instantiate(groundPrefab, position, Quaternion.identity);
        //}

        // if colliding with another cube 
        if (other.name == "FireCube")
        {
            if (timeActive > other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "WoodCube")
        {
            if (timeActive < other.GetComponent<WoodCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "StoneCube")
        {
            if (timeActive < other.GetComponent<StoneCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FenceCube")
        {
            if (timeActive < other.GetComponent<FenceCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LanternCube")
        {
            if (timeActive < other.GetComponent<LanternCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "TreeCube")
        {
            if (timeActive < other.GetComponent<TreeCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LongGrassCube")
        {
            if (timeActive < other.GetComponent<LongGrassCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LilypadCube")
        {
            if (other.GetComponent<LilypadCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<LilypadCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<LilypadCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "FlowerCube")
        {
            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "BurningCube")
        {
            if (timeActive < other.GetComponent<BurningCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "SaplingCube")
        {
            if (timeActive < other.GetComponent<SaplingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LamppostCube")
        {
            if (timeActive < other.GetComponent<LamppostCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "TorchCube")
        {
            if (timeActive < other.GetComponent<TorchCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FloorLightCube")
        {
            if (timeActive < other.GetComponent<FloorLightCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "RainbowLightCube")
        {
            if (timeActive < other.GetComponent<RainbowLightCubeScript>().timeActive)
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
