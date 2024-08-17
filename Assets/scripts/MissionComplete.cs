using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionComplete : MonoBehaviour
{
    public void home(){
        SceneManager.LoadScene("Home");
    }
}
