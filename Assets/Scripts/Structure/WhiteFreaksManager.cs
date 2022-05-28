using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFreaksManager : MonoBehaviour
{
    private int _allFreaksCount = 10;
    public int allFreaksCount { get => _allFreaksCount; }
    private int _idleFreaksCount = 10;
    public int idleFreaksCount { get => _idleFreaksCount; }
    private int _busyFreaksCount = 0;
    public int busyFreaksCount { get => _busyFreaksCount; }


    private static WhiteFreaksManager mInstance;
    public static WhiteFreaksManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<WhiteFreaksManager>();
            }
            return mInstance;
        }
    }
   
    public void increaseIdle()
    {
        _idleFreaksCount++;
        _busyFreaksCount--;
    }
    public void increaseBusy()
    {
            _busyFreaksCount++;
            _idleFreaksCount--;
      
    }
    /*
    public void increaseFreaks()
    {
        allFreaksCount++;
        idleFreaksCount++;
    }*/
    public void increaseFreaks(int num)
    {
        _allFreaksCount+=num;
        _idleFreaksCount+=num;
    }

    GameObject whiteFreaks;
    public GameObject GetWhiteFreaks()
    {
        if (_idleFreaksCount == 0)
        {
            SystemMassage.Instance.PrintSystemMassage("������ ������ ȭ��Ʈ�������� �����ϴ�.");
            return null;
        }
        else
        {
            increaseBusy();
            whiteFreaks =  ObjectPooling.Instance.GetObject("WhiteFreaks");
            return whiteFreaks;
        }  
    }


    public void ReturnWhiteFreaks(GameObject freaks)
    {
        ObjectPooling.Instance.ReturnObject(freaks);
        increaseIdle();
    }

}