using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class glassBreak : MonoBehaviour
{
    public GameObject glass1, glass2, trigger1, player;
    Transform playerTransform, glass1Transform, glass2Transform;

    private int rand;
    private float distance1, distance2;
    public bool breakGlass1, breakGlass2;
    private float timeLeft = 65;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        glass1Transform = glass1.GetComponent<Transform>();
        glass2Transform = glass2.GetComponent<Transform>();
        rand = Random.Range(0, 10);
        if(rand > 5)
        {
            breakGlass1 = true;        
            breakGlass2 = false;
        }
        else
        {
            breakGlass1 = false;
            breakGlass2 = true;
        }
    }
    private void OnTriggerEnter(Collider other)     //make sure OVR controller has a box collider with isTrigger clicked
    {
        Debug.Log("asdfsdffd");
        if (breakGlass1 && distance1 < 2)
        {
            glass1.SetActive(false);
            Debug.Log("glass 1");
        }
        else if (breakGlass2 && distance2 < 2)
        {
            glass2.SetActive(false);
            Debug.Log("glass 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;
        distance1 = Vector3.Distance(playerTransform.position, glass1Transform.position);
        distance2 = Vector3.Distance(playerTransform.position, glass2Transform.position);
        Debug.Log(playerTransform.position.y);
        if(playerTransform.position.y == 1.01f)
        {
            SceneManager.LoadScene(4);
        }
    }
}
