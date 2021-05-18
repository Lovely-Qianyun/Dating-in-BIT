using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnManager : MonoBehaviour
{
    private static Image UserImage;
    private static Text UserName;
    private static Transform Buttonmanager;
    private static Transform InformationPanel;

    private void Awake()
    {
        Transform ContentPanel = this.transform.GetChild(1);

        UserImage = ContentPanel.GetChild(0).GetComponent<Image>();
        UserName = ContentPanel.GetChild(1).GetComponent<Text>();

        Buttonmanager = ContentPanel.GetChild(2);
        Buttonmanager.gameObject.AddComponent<ButtonManager>();

        InformationPanel = ContentPanel.GetChild(3);
        InformationPanel.gameObject.AddComponent<InformationPanel>();

        ShowUser();
    }

    //加载用户头像图片、用户名
    private void ShowUser()
    {
        
    }

}
