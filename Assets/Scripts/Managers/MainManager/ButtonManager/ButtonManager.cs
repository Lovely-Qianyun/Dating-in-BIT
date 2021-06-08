using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject AboutUsPanel;
    private void Awake()
    {
        
        Transform m_transform = this.transform;
        m_transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            UpdateImage();
        });
        m_transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Mod_Check_Information();
        });
        m_transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            About_Us();
        });
        m_transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            LogOut();
        });
        AboutUsPanel = m_transform.GetChild(4).gameObject;
        AboutUsPanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //隐藏此物体
            AboutUsPanel.SetActive(false);
            //回到初始Own页面状态
        });
    }

    //???待修改
    //更换用户头像，并将该头像上传至数据库保存
    //如何更换我懒得想了，你就把更换后的图片上传就行
    private void UpdateImage()
    {
        Manager.Instance.ShowTipPanel("敬请期待");
        return;
        ////将图片转为WWWForm
        //WWWForm form = new WWWForm();
        ////用户的图片数据
        //Texture2D image = Resources.Load("Pictures/Expression.png") as Texture2D;
        //UserData.UserImage = image;
        //byte[] bs = image.EncodeToPNG();
        //form.AddBinaryData("userimage", bs, "userimage", "image/png");
        //StartCoroutine(Server.Instance.IPostUserImage(form));
    }

    //OwnManager.InformationPanel
    //显示InformationPanel
    private void Mod_Check_Information()
    {
        OwnManager.InformationPanel.gameObject.SetActive(true);
        OwnManager.InformationPanel.GetComponent<InformationPanel>().ShowInformation();
    }
    //显示AboutUsPanel
    private void About_Us()
    {
        AboutUsPanel.SetActive(true);
    }
    //登出，断开服务器连接，返回登录页面
    //具体实现些什么，没想清楚
    private void LogOut()
    {
        UserData.Clear();
        Manager.Instance.SkipToLogIn();
    }

}
