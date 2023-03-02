using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    private AudioClip test;

    public void MoveToSceneById(int id)
    {
        if (sound != null && !sound.isPlaying)
            sound.Play();

        StartCoroutine(ChangeScene(id));
    }

    IEnumerator ChangeScene(int id)
    {
        yield return new WaitForSeconds(sound != null ? sound.clip.length : 0f);
        SceneManager.LoadScene(id);
    }
}