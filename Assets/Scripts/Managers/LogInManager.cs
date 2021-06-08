using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogInManager : MonoBehaviour
{
    //用户名输入框
    private InputField IN_UserName;
    //密码输入框
    private InputField IN_PassWord;
    public static bool isOver = false;
    public static string result = "";

    private void Awake()
    {
        //初始化
        IN_UserName = this.transform.GetChild(1).GetChild(0).GetComponent<InputField>();
        IN_PassWord = this.transform.GetChild(1).GetChild(1).GetComponent<InputField>();
        //登录按钮
        this.transform.GetChild(2).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () {
            LogIn(IN_UserName, IN_PassWord);
        });
        //注册按钮
        this.transform.GetChild(2).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () {
            Register();
        });
        //退出按钮
        this.transform.GetChild(2).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () {
            Application.Quit();
        });

        //IN_PassWord.onValueChanged.AddListener((string str) =>
        //{
        //    password = str;
        //    IN_PassWord.text = "";
        //    for (int i = 0;i < str.Length; ++i)
        //        IN_PassWord.text += "*";
        //});
    }
    private void LogIn(InputField SchoolNumber, InputField PassWord)
    {
        //获取用户名和密码的string
        string schoolnumber = SchoolNumber.text;
        string key = PassWord.text;
        //上传服务器，在数据库中寻找用户名
        StartCoroutine(Server.Instance.IGetLogInData(schoolnumber, key));

        StartCoroutine(login(schoolnumber));
        
    }
    private void Register()
    {
        //调用Manager脚本跳转页面
        Manager.Instance.SkipToRegister();
    }
    IEnumerator login(string schoolnumber)
    {
        Manager.Cover.SetActive(true);
        while (!isOver)
        {
            yield return 0;
        }
        isOver = false;
        Manager.Cover.SetActive(false);
        if (result.Equals("NETERROR"))
        {
            Manager.Instance.ShowTipPanel("网络故障,请稍后重试");
            yield break;
        }
        //找到该用户名
        if (!result.Equals("error"))
        {
            //匹配密码
            //密码正确，登录成功，调用Manager脚本显示MainPage
            //同时加载用户数据到UserData脚本
            if (result.Equals("true"))
            {
                StartCoroutine(Server.Instance.IGetUserData(schoolnumber));
                Manager.Cover.SetActive(true);
                while (!isOver)
                {
                    yield return 0;
                }
                isOver = false;
                Manager.Cover.SetActive(false);
                Manager.Instance.SkipToMain();
            }
            //密码错误，登录失败，显示Tip_Panel：用户名或密码错误
            else if(result.Equals("false"))
            {
                Manager.Instance.ShowTipPanel("用户名或密码错误");
            }
        }
        //未找到该用户
        else
        {
            //未找到用户名，显示Tip_Panel：用户不存在
            Manager.Instance.ShowTipPanel("用户不存在");
        }

    }
}
