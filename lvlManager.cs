using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlManager : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void lvl_1()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void lvl_2()
    {
        SceneManager.LoadScene("lvl_2");
    }
}
