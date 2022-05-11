using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building11 : MonoBehaviour
{
    private string objectName = null;
    [SerializeField] private int timer = 10;
     public bool isTimerON = false;
    bool First = true;

    private GameObject alter;
    public void Init()
    {
        switch (this.gameObject.name)
        {
            case "build_alter(Clone)":
                objectName = "Alter";
                timer = 10;
                //this.gameObject.SetActive(true);
           
                StartCoroutine("BuildingTimer");                
                break;
            case "build_whitetower(Clone)":             
                objectName = "Whitetower";
                timer = 30;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
              
          
                StartCoroutine("BuildingTimer");
                
                break;
            case "build_workshop(Clone)":
                objectName = "Workshop";
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);

                break;
            default:
                break;
        }

    }


    /*
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }*/
    /*
    private void Update()
    {
        if (isTimerON)
        {
            StartCoroutine("BuildingTimer");
            isTimerON = false;
        }

    }*/

    /*
    private void OnTriggerEnter(Collider other) //ȭ��Ʈ �������� ������ ���
    {

        if (other.gameObject.CompareTag("WhiteFreaks"))
        {
            switch (objectName)
            {
                case "Alter":
                    StartCoroutine("BuildingTimer");
                    break;
                case "Whitetower":
                    StartCoroutine("BuildingTimer");
                    break;
                case "Workshop": //�ٷ� �Ǽ�
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    */
    IEnumerator BuildingTimer()
    {

        while (true)
        {
            if (timer > 0)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
            else
            {

                switch (objectName)
                {
                    case "Alter":
                        alter = GameObject.Find("alter").gameObject;
                        alter.transform.position = this.transform.position;

                        AlterAttack alterAttack = alter.GetComponent<AlterAttack>();
                        alterAttack.bulletSpawnNewSetting();

                        GameManager.Instance.AlterIsChange.Invoke(this.gameObject);
                        Destroy(this.gameObject);
                        break;
                    case "Whitetower":
                        transform.GetChild(0).gameObject.SetActive(false);
                        transform.GetChild(1).gameObject.SetActive(true);
                        break;              
                    default:
                        break;
                }

                break;
            }
        }
    }
}