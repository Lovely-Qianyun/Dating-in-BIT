using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private Transform MainPanel;
    private Button[] MainPanels;
    private Transform ContentsPanel;
    private GameObject[] ContentPanels = new GameObject[4];
    private Sprite[] MainImages;

    private void Awake()
    {
        MainImages = new Sprite[8];
        MainImages[0] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Message1") as Texture2D);
        MainImages[1] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Message2") as Texture2D);
        MainImages[2] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Mate1") as Texture2D);
        MainImages[3] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Mate2") as Texture2D);
        MainImages[4] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Activity1") as Texture2D);
        MainImages[5] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Activity2") as Texture2D);
        MainImages[6] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Own1") as Texture2D);
        MainImages[7] = TEXtoSprite(Resources.Load("Pictures/Menu_Bar/Own2") as Texture2D);

        MainPanel = this.transform.GetChild(0);
        ContentsPanel = this.transform.GetChild(1);
        MainPanels = new Button[4];
        for(int i = 0;i < 4; ++i)
        {
            MainPanels[i] = MainPanel.GetChild(i).GetComponent<Button>();
            ContentPanels[i] = ContentsPanel.GetChild(i).gameObject;
            
        }
        ContentPanels[0].AddComponent<MessageManager>();
        MainPanels[0].onClick.AddListener(delegate ()
        {
            MainSkip(0);
        });
        ContentPanels[1].AddComponent<MateManager>();
        MainPanels[1].onClick.AddListener(delegate ()
        {
            MainSkip(1);
        });
        ContentPanels[2].AddComponent<ActivityManager>();
        MainPanels[2].onClick.AddListener(delegate ()
        {
            MainSkip(2);
        });
        ContentPanels[3].AddComponent<OwnManager>();
        MainPanels[3].onClick.AddListener(delegate ()
        {
            MainSkip(3);
        });

    }

    private void MainSkip(int T)
    {
        //等于T的，显示ContentPanels对应页面，并高亮显示MainPanels对应按钮
        ContentPanels[T].SetActive(true);
        MainPanels[T].GetComponent<Image>().sprite = MainImages[2*T];
        //不等于T的，隐藏页面，暗显示
        for(int i = 0;i < 4; ++i)
        {
            if (i == T)
                continue;
            ContentPanels[i].SetActive(false);
            MainPanels[i].GetComponent<Image>().sprite = MainImages[2*i+1];
        }

    }

    private Sprite TEXtoSprite(Texture2D tex)
    {
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }

}

