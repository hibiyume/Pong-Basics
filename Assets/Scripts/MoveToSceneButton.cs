using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToSceneButton : MonoBehaviour
{
    public void MoveToSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}