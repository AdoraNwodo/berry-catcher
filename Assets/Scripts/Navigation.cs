using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
