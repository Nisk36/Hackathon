using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : Object
{
    private string title;
    private string information;

    public Quest(string title="�^�C�g���Ȃ�",string info = "���e�Ȃ�")
    {
        this.title = title;
        this.information = info;
    }

    public string GetTitle()
    {
        return title;
    }
    
    public string GetInformation()
    {
        return information;
    }
}
