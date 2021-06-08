using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateManager : MonoBehaviour
{
    Text noResult;

    private void Awake()
    {
        noResult = this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>();
        this.transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            noResult.text = "无结果";
        });
    }
}
