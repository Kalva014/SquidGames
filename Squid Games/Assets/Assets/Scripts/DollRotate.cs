using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DollRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject doll;
    public GameObject player;
    public AudioSource dollSound;

    bool dollDetecting = false;
    private float dollDelay = 3;
    private float randDelay = 5;
    private float headDelay = 2;
    private Vector3 lastPos, currPos;

    Transform dollRotation;
    void Start()
    {
        dollRotation = doll.GetComponent<Transform>();
        dollSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("Stop the timer here");
        }
        //if (dollDetecting)
        //dollSound.Play(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand = 0;

        if (player.GetComponent<Transform>().position.z > -11.97)       //while player is behind the line
        {
            if (randDelay > 0)
            {
                randDelay -= Time.deltaTime;
            }
            else   //when 1 second of delay for getting random int has passed
            {
                if (dollDetecting)
                {
                    if (!dollSound.isPlaying)
                    {
                        dollSound.Play(0);
                    }
                    else
                    {
                        if (dollSound.time < 5.1)
                        {
                            lastPos = player.GetComponent<Transform>().position;
                        }
                        else
                        {
                            currPos = player.GetComponent<Transform>().position;
                            if(lastPos != currPos)
                            {
                                SceneManager.LoadScene(4);
                            }
                            else if (dollSound.time > 8.15)
                            {
                                dollDetecting = false;
                            }
                        }
                        

                    }
                    if (dollSound.time == 0)
                    {
                        /*dollRotation.RotateAround(dollRotation.position, Vector3.up, 180);        //make while loop that runs until doll reaches certain rotation
                        if (headDelay > 0)
                            headDelay -= Time.deltaTime;
                        else
                        {
                            dollRotation.RotateAround(dollRotation.position, Vector3.up, 180);
                            headDelay = 2;
                            randDelay = 3;
                            dollDetecting = false;
                        }*/
                    }
                }
                else
                {
                    rand = Random.Range(1, 10);
                    if (rand >= 3)
                        dollDetecting = true;
                    else
                        dollDetecting = false;
                    int randomDelay = Random.Range(1, 5);
                    Debug.Log(rand);
                    Debug.Log(randomDelay);
                    randDelay = randomDelay;
                }
            }
        }
    }
}
