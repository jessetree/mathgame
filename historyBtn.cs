using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class historyBtn : MonoBehaviour
{
    public void OnLoginBtnClick()
    {
        SceneManager.LoadScene(2);
    }
}
