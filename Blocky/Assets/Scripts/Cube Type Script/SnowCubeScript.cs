﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public bool isBlackCube;
    public RestartScript restartScript;
    public Material snowMaterial;
    PlayerScript playerScript;




    // Start is called before the first frame update
    void Start()
    {

        if (!isBlackCube)
        {
            gameObject.name = "SnowCube";
            //GetComponent<Renderer>().material = snowMaterial;
        }
        else
        {
            gameObject.name = "BlackFloorCube";
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.4f);
        }
        gameObject.tag = "Floor";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();

        // don't play the audio clip for this cube if this cube is the default cube type
        if (playerScript.blankCubeType != CubeType.SNOW)
        {
            GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.SNOW);
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
        if (!isBlackCube)
        {
            if (other.name == "SnowCube")
            {
                if (other.GetComponent<SnowCubeScript>().timeActive == timeActive)
                {
                    other.GetComponent<SnowCubeScript>().timeActive += 0.01f;
                }

                if (timeActive < other.GetComponent<SnowCubeScript>().timeActive)
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

            if (other.name == "PavingCube")
            {
                if (other.GetComponent<PavingCubeScript>().timeActive > timeActive)
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
                if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
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

            if (other.name == "SandCube")
            {
                if (timeActive < other.GetComponent<SandCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "DirtCube")
            {
                if (timeActive < other.GetComponent<DirtCubeScript>().timeActive)
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
        }
        else if (other.GetComponent<CubeScript>() == null)
        {
            
            Destroy(other.gameObject);
        }


    }
}
