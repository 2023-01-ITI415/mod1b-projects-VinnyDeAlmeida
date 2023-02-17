using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prototype1 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Block"))
        {
            SceneManager.LoadScene("Main-Prototype1");
        }
    }
}
