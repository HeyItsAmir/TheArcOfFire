using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
   public void LoadScene(string Main)
    {
       SceneManager.LoadScene(Main);
    }
}
