﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebblesCubeScript : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject grassPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject dirtPrefab;
    public RestartScript restartScript;
    PlayerScript playerScript;
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "PebblesCube";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.STONE);

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


        if (transform.position.y != -0.8799995f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.8799995f, transform.position.z);
        }

        if (restartScript.loading)
        {
            Destroy(this.gameObject);
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterCube")
        {
            if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "PebblesCube")
        {
            if (other.GetComponent<PebblesCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<PebblesCubeScript>().timeActive += 0.01f;
            }

            if (timeActive > other.GetComponent<PebblesCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
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

        if (other.name == "FireCube")
        {
            if (timeActive < other.GetComponent<FireCubeScript>().timeActive)
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
            if (timeActive < other.GetComponent<PondWaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LavaCube")
        {
            if (timeActive < other.GetComponent<LavaCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "NuclearCube")
        {
            if (timeActive < other.GetComponent<NuclearCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "IceCube")
        {
            if (timeActive < other.GetComponent<IceCubeScript>().timeActive)
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
