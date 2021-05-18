using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    private List<Transform> Informations = new List<Transform>();
    private void Awake()
    {
        Transform m_transform = this.transform;
        m_transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //返回Own初始页面状态
        });
        m_transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SaveInformation();
        });
        //Informations
        Transform tmp = m_transform.GetChild(3);
        for (int i = 0; i < 9; ++i)
            Informations.Add(tmp.GetChild(i));
        //Informations[5].GetChild(0/1),数据/是否公开
        ShowInformation();
    }
    //显示资料
    private void ShowInformation()
    {

    }
    //保存资料，存入数据库
    private void SaveInformation()
    {
        //转为WWWForm
        //上传
    }
    //Informations
    private WWWForm ConvertInforInput(List<InputField> RInput)
    {
        WWWForm form = new WWWForm();
        //添加用户名
        form.AddField("username", RInput[(int)RegisterInputNum.UserName].text);
        //添加姓名
        form.AddField("name", RInput[(int)RegisterInputNum.Name].text);
        //添加学号
        form.AddField("schoolnumber", RInput[(int)RegisterInputNum.SchoolNumber].text);
        //添加性别
        form.AddField("gender", RInput[(int)RegisterInputNum.Gender].text);
        //添加书院
        form.AddField("college", RInput[(int)RegisterInputNum.College].text);
        //添加专业
        form.AddField("profession", RInput[(int)RegisterInputNum.Profession].text);
        //添加生日
        form.AddField("birthday", RInput[(int)RegisterInputNum.Birthday].text);
        //添加兴趣爱好
        form.AddField("hobby", RInput[(int)RegisterInputNum.Hobby].text);
        //添加备注
        form.AddField("remarks", RInput[(int)RegisterInputNum.Remarks].text);
        return form;
    }
}
