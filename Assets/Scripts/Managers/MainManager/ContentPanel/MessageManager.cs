using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    private GameObject MessagePage;
    private GameObject ChatPage;
    private GameObject InformationPage;

    private void Awake()
    {
        MessagePage = this.transform.GetChild(0).gameObject;
        ChatPage = this.transform.GetChild(1).gameObject;
        InformationPage = this.transform.GetChild(2).gameObject;

    }
}
