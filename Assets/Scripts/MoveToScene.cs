using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public void MoveToSceneById(int id)
    {
        SceneManager.LoadScene(id);
    }
}
