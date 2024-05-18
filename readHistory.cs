using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class readHistory : MonoBehaviour
{
    public UnityEngine.UI.Text historyText;

    // Start is called before the first frame update
    void Start()
    {
        if (mathGame.current.histories.Count == 0)
        {
            historyText.text = "No History.";
        }
        else
        {
            string historyDate = mathGame.current.ReadHistory();
            historyText.text = historyDate;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
