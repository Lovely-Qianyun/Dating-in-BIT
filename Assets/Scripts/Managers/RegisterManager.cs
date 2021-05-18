using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RegisterManager : MonoBehaviour
{
    List<InputField> RegisterInput = new List<InputField>();
    Transform pageone;
    Transform pagetwo;
    private void Awake()
    {
        pageone = this.transform.GetChild(1).GetChild(0);
        pagetwo = this.transform.GetChild(1).GetChild(2);
        //取消注册
        this.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Manager.Instance.SkipToLogIn();
        });
        for (int i = 0; i < 8; ++i)
            RegisterInput.Add(pageone.GetChild(i).GetComponent<InputField>());
        //下一页
        pageone.GetChild(8).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            pageone.gameObject.SetActive(false);
            pagetwo.gameObject.SetActive(true);
        });
        for (int i = 0; i < 3; ++i)
            RegisterInput.Add(pagetwo.GetChild(i).GetComponent<InputField>());
        //上一页
        pagetwo.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            pageone.gameObject.SetActive(true);
            pagetwo.gameObject.SetActive(false);
        });
        //确定注册
        pagetwo.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate ()
        {
            ConfirmRegister(RegisterInput);
        });

    }
    void ConfirmRegister(List<InputField> Input)
    {
        //先确定两次密码是否一致，不一致则Tip_Panel，然后return
        //确定其他数据是否符合要求，如性别、生日是否符合格式等

        //连接服务器，在数据库中查询学号是否被注册
        //已被注册，显示Tip_Panel：用户已注册，return

        //未被注册
        //将数据写入数据库
        //显示Tip_Panel：注册成功，然后返回登录页面
    }
    
    //调用此函数将注册输入数据转为WWWForm类型，然后上传
    private WWWForm ConvertRegisterInput(List<InputField> RInput)
    {
        WWWForm form = new WWWForm();
        //添加用户名
        form.AddField("username", RInput[(int)RegisterInputNum.UserName].text);
        //添加密码
        form.AddField("password", RInput[(int)RegisterInputNum.PassWord].text);
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
        //添加默认头像，用户后续可以自己更改
        byte[] bs = (Resources.Load("Pictures/Expression.png") as Texture2D).EncodeToPNG();
        form.AddBinaryData("userimage", bs, "userimage", "image/png");

        return form;
    }

}




