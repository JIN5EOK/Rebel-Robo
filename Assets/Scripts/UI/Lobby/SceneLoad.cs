using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    [SerializeField] private Scenes scene;
    
    public enum Scenes
    {
        Intro,
        GameLobby,
        DesingDevelop
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
