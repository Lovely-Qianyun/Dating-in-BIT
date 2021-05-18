using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private Transform MainPanel;
    private Button[] MainPanels;
    private Transform ContentsPanel;
    private GameObject[] ContentPanels;

    private void Awake()
    {
        MainPanel = this.transform.GetChild(0);
        ContentsPanel = this.transform.GetChild(1);
        MainPanels = new Button[4];
        for(int i = 0;i < 4; ++i)
        {
            MainPanels[i] = MainPanel.GetChild(i).GetComponent<Button>();
            ContentPanels[i] = ContentsPanel.GetChild(i).gameObject;
            MainPanels[i].onClick.AddListener(delegate ()
            {
                MainSkip(i);
            });
        }
        ContentPanels[0].AddComponent<MessageManager>();
        ContentPanels[1].AddComponent<MateManager>();
        ContentPanels[2].AddComponent<ActivityManager>();
        ContentPanels[3].AddComponent<OwnManager>();

    }

    private void MainSkip(int T)
    {
        //等于T的，显示ContentPanels对应页面，并高亮显示MainPanels对应按钮

        //不等于T的，隐藏页面，暗显示

    }

}

