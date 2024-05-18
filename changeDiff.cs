using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeDiff : MonoBehaviour
{
    public UnityEngine.UI.Dropdown difficultChange;
    public UnityEngine.UI.Dropdown operationChange;
    public UnityEngine.UI.InputField numberInput;

    public static int difficulty = 0;
    public static int numberCount = 0;
    public static int operation;

    // Start is called before the first frame update
    void Start()
    {
        difficultChange.onValueChanged.AddListener(ChangeDifficult);
        operationChange.onValueChanged.AddListener(ChangeOperation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClick()
    {
        int num;
        if (int.TryParse(numberInput.text,out num)&&num>=1&&num<=100)
        {
            numberCount = num;
        }
        else
        {
            numberCount = 10;
        }
    }

    public void ChangeDifficult(int index)
    {
        switch (index)
        {
            case 0:
                difficulty = 0;
                Debug.Log("你选择了 Easy");
                break;
            case 1:
                difficulty = 1;
                Debug.Log("你选择了 Medium");
                break;
            case 2:
                difficulty = 2;
                Debug.Log("你选择了 Hard");
                break;
        }
    }

    public void ChangeOperation(int index)
    {
        switch (index)
        {
            case 0:
                operation=0;
                Debug.Log("你选择了 +");
                break;
            case 1:
                operation =1;
                Debug.Log("你选择了 -");
                break;
            case 2:
                operation =2;
                Debug.Log("你选择了 *");
                break;
            case 3:
                operation =3;
                Debug.Log("你选择了 /");
                break;
            case 4:
                operation = 4;
                Debug.Log("你选择了 Random");
                break;
        }
    }
}
