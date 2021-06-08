using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//Server.Instance调用
public class Server
{
    public static Server Instance = new Server();

    string MyIpAddress = "10.171.213.101/Dating_BIT/";
    //连接服务器，返回登录匹配结果值:true,false,error,字符串
    public IEnumerator IGetLogInData(string SchoolNumber, string PassWord)
    {

        UnityWebRequest uwr = UnityWebRequest.Get("http://" + MyIpAddress +
            "LogIn.php?schoolnumber=" + SchoolNumber
            + "&password=" + PassWord);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            LogInManager.result = "NETERROR";
            LogInManager.isOver = true;
            yield return null;
        }
        //判断是否正确，或者用变量接收返回的数据
        //uwr.downloadHandler.text
        //返回为"true"，则正确
        //返回为 "false"，则错误
        //返回为"error"，则不存在
        LogInManager.isOver = true;
        LogInManager.result = uwr.downloadHandler.text;
    }

    //连接服务器，返回注册匹配结果值:true,false字符串
    public IEnumerator IGetRegister(string SchoolNumber, string Name)
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://" + MyIpAddress +
            "GetRegister.php?schoolnumber=" + SchoolNumber
            + "&name=" + Name);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            RegisterManager.result = "NETERROR";
            RegisterManager.isOver = true;
            yield return null;
        }
        //判断是否正确，或者用变量接收返回的数据
        //uwr.downloadHandler.text
        //返回为"true"，可以注册，然后将数据存入数据库
        //返回为 "false"，已被注册，错误
        RegisterManager.result = uwr.downloadHandler.text;
        RegisterManager.isOver = true;
    }

    //连接服务器，将注册数据上传至数据库
    //需先将数据处理为WWWForm形式
    public IEnumerator IPostRegister(WWWForm wwwform)
    {
        UnityWebRequest uwr = UnityWebRequest.Post("http://" + MyIpAddress +
            "PostRegister.php",wwwform);
        yield return uwr.SendWebRequest();
        RegisterManager.result = uwr.downloadHandler.text;
        RegisterManager.isOver = true;
    }

    //连接服务器，返回用户所有数据,存入UserData脚本
    public IEnumerator IGetUserData(string SchoolNumber)
    {
        UnityWebRequest uwr = UnityWebRequest.Get("http://" + MyIpAddress +
            "GetUserData.php?schoolnumber=" + SchoolNumber);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            yield return null;
        }
        string[] result = uwr.downloadHandler.text.Split('|');
        UserData.UserName = result[0];
        UserData.PassWord = result[1];
        UserData.Name = result[2];
        UserData.SchoolNumber = result[3];
        UserData.Gender = result[4];
        UserData.College = result[5];
        UserData.Profession = result[6];
        UserData.Birthday = result[7];
        UserData.Hobby = result[8];
        UserData.Remarks = result[9];
        uwr = UnityWebRequestTexture.GetTexture("http://" + MyIpAddress + "userimages/" + UserData.SchoolNumber + "userimage.png");
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            yield return null;
        }
        UserData.UserImage = DownloadHandlerTexture.GetContent(uwr);
        LogInManager.isOver = true;
    }
    //连接服务器，上传用户所有数据,不包括图片
    public IEnumerator IPostUserData(WWWForm wwwform)
    {
        UnityWebRequest uwr = UnityWebRequest.Post("http://" + MyIpAddress +
            "PostUserData.php",wwwform);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError || !uwr.downloadHandler.text.Equals("true"))
        {
            InformationPanel.result = false;
            InformationPanel.isOver = true;
            yield return null;
        }
        InformationPanel.result = true;
        InformationPanel.isOver = true;
        //Debug.Log(uwr.downloadHandler.text);
    }

    //上传用户图片
    public IEnumerator IPostUserImage(WWWForm wwwform)
    {
        UnityWebRequest uwr = UnityWebRequest.Post("http://" + MyIpAddress
            + "postUserImage.php",wwwform);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            yield return null;
        }
    }


}
