using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backBtn : MonoBehaviour
{
    public void OnLoginBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
