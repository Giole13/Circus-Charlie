using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //private PlayerController player = default;

    
    

    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerOBJ = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);
        //player = playerOBJ.FindChildObj(GioleData.PLAYER_OBJ_NAME).
        //    GetComponent<PlayerController>();

        //Screen.SetResolution(1280, 720, true);
        SetResolution(); // �ʱ⿡ ���� �ػ� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /* �ػ� �����ϴ� �Լ� */
    public void SetResolution()
    {
        int setWidth = 1280; // ����� ���� �ʺ�
        int setHeight = 720; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
}
