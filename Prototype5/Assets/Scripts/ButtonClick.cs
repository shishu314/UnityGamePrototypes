using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{

    public void SelectSlime()
    {
        PlayerClass.ClassChoice = PlayerClass.Class.Slime;
        SceneManager.LoadScene("MainStage", LoadSceneMode.Single);
    }

    public void SelectUndead()
    {
        PlayerClass.ClassChoice = PlayerClass.Class.Undead;
        SceneManager.LoadScene("MainStage", LoadSceneMode.Single);
    }

    public void SelectIronGiant()
    {
        PlayerClass.ClassChoice = PlayerClass.Class.IronGiant;
        SceneManager.LoadScene("MainStage", LoadSceneMode.Single);
    }

    public void SelectHuman()
    {
        PlayerClass.ClassChoice = PlayerClass.Class.Human;
        SceneManager.LoadScene("MainStage", LoadSceneMode.Single);
    }
}
