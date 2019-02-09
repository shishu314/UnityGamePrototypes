using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Sides == 10)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
        if(player.Sides < 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}
