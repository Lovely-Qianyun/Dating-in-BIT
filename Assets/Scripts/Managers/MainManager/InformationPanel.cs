using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    private List<Transform> Informations = new List<Transform>();
    public static bool isOver = false;
    public static bool result = false;
    private void Awake()
    {
        Transform m_transform = this.transform;
        m_transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //返回Own初始页面状态
            this.gameObject.SetActive(false);
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
    public void ShowInformation()
    {
        Informations[0].GetChild(0).GetComponent<InputField>().text = UserData.UserName;
        Informations[1].GetChild(0).GetComponent<InputField>().text = UserData.Name;
        Informations[2].GetChild(0).GetComponent<InputField>().text = UserData.SchoolNumber;
        Informations[3].GetChild(0).GetComponent<InputField>().text = UserData.Gender;
        Informations[4].GetChild(0).GetComponent<InputField>().text = UserData.College;
        Informations[5].GetChild(0).GetComponent<InputField>().text = UserData.Profession;
        Informations[6].GetChild(0).GetComponent<InputField>().text = UserData.Birthday;
        Informations[7].GetChild(0).GetComponent<InputField>().text = UserData.Hobby;
        Informations[8].GetChild(0).GetComponent<InputField>().text = UserData.Remarks;
    }
    //保存资料，存入数据库
    private void SaveInformation()
    {
        //转为WWWForm
        InputField[] input = new InputField[9];
        for (int i = 0; i < 9; ++i)
        {
            input[i] = Informations[i].GetChild(0).GetComponent<InputField>();
        }
        UserData.UserName = Informations[0].GetChild(0).GetComponent<InputField>().text;
        UserData.Name = Informations[1].GetChild(0).GetComponent<InputField>().text;
        UserData.SchoolNumber = Informations[2].GetChild(0).GetComponent<InputField>().text;
        UserData.Gender = Informations[3].GetChild(0).GetComponent<InputField>().text;
        UserData.College = Informations[4].GetChild(0).GetComponent<InputField>().text;
        UserData.Profession = Informations[5].GetChild(0).GetComponent<InputField>().text;
        UserData.Birthday = Informations[6].GetChild(0).GetComponent<InputField>().text;
        UserData.Hobby = Informations[7].GetChild(0).GetComponent<InputField>().text;
        UserData.Remarks = Informations[8].GetChild(0).GetComponent<InputField>().text;
        //上传
        StartCoroutine(Server.Instance.IPostUserData(ConvertInforInput(input)));
        StartCoroutine(save());
    }
    IEnumerator save()
    {
        Manager.Cover.SetActive(true);
        while (!isOver)
        {
            yield return 0;
        }
        isOver = false;
        Manager.Cover.SetActive(true);
        if (result)
        {
            Manager.Instance.ShowTipPanel("保存成功");
        }
        else
        {
            Manager.Instance.ShowTipPanel("保存失败,请稍后重试");
        }
        Manager.Cover.SetActive(false);
    }
    //Informations
    private WWWForm ConvertInforInput(InputField[] RInput)
    {
        WWWForm form = new WWWForm();
        //添加用户名
        form.AddField("username", RInput[(int)InformationNum.UserName].text);
        //添加姓名
        form.AddField("name", RInput[(int)InformationNum.Name].text);
        //添加学号
        form.AddField("schoolnumber", RInput[(int)InformationNum.SchoolNumber].text);
        //添加性别
        form.AddField("gender", RInput[(int)InformationNum.Gender].text);
        //添加书院
        form.AddField("college", RInput[(int)InformationNum.College].text);
        //添加专业
        form.AddField("profession", RInput[(int)InformationNum.Profession].text);
        //添加生日
        form.AddField("birthday", RInput[(int)InformationNum.Birthday].text);
        //添加兴趣爱好
        form.AddField("hobby", RInput[(int)InformationNum.Hobby].text);
        //添加备注
        form.AddField("remarks", RInput[(int)InformationNum.Remarks].text);
        form.AddField("remarks", RInput[(int)InformationNum.Remarks].text);
        return form;
    }


}
