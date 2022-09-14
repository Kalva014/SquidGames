using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedLightToGlassBridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)     //make sure OVR controller has a box collider with isTrigger clicked
    {
        SceneManager.LoadScene(2);
    }
    void Update()
    {
        
    }
}
