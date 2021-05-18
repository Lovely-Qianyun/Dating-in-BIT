using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //单例模式,调用此脚本可用Manager.Instance
    public static Manager Instance;
    private GameObject LogInPage;
    private GameObject RegisterPage;
    private GameObject MainPage;
    private GameObject Tip_Panel;

    private void Awake()
    {
        Instance = this;
        //登录页面
        LogInPage = this.transform.GetChild(0).gameObject;
        LogInPage.AddComponent<LogInManager>();
        LogInPage.SetActive(true);
        //Tip_Panel
        Tip_Panel = this.transform.GetChild(3).gameObject;
        Tip_Panel.SetActive(false);
        //注册页面
        RegisterPage = this.transform.GetChild(1).gameObject;
        RegisterPage.AddComponent<RegisterManager>();
        RegisterPage.SetActive(false);
        //主页面
        MainPage = this.transform.GetChild(1).gameObject;
        MainPage.AddComponent<MainManager>();
        MainPage.SetActive(false);
    }
    //跳转Main页面
    public void SkipToMain()
    {
        MainPage.SetActive(true);
        LogInPage.SetActive(false);
        RegisterPage.SetActive(false);
    }
    //跳转LogIn页面
    public void SkipToLogIn()
    {
        MainPage.SetActive(false);
        LogInPage.SetActive(true);
        RegisterPage.SetActive(false);
    }
    //跳转Register页面
    public void SkipToRegister()
    {
        MainPage.SetActive(false);
        LogInPage.SetActive(false);
        RegisterPage.SetActive(true);
    }
    public void ShowTipPanel(string str)
    {
        //显示
        Tip_Panel.transform.GetChild(0).GetComponent<Text>().text = str;
        Tip_Panel.SetActive(true);
        //3秒后隐藏
        Invoke("hiddenTipPanel", 3);
    }
    void hiddenTipPanel()
    {
        Tip_Panel.SetActive(false);
    }
}
//调用对应输入使用 RegisterInput[(int)RegisterInputNum.UserName]
public enum RegisterInputNum
{
    UserName = 0,
    PassWord = 1,
    ConfirmPassWord,
    Name,
    SchoolNumber,
    Gender,
    College,
    Profession,
    Birthday,
    Hobby,
    Remarks,

}
public enum InformationNum
{
    UserName = 0,
    Name = 1,
    SchoolNumber,
    Gender,
    College,
    Profession,
    Birthday,
    Hobby,
    Remarks,

}
