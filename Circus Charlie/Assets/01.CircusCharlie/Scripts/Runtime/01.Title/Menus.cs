using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{

    private const string PLAY_SCENE_NAME = "02.PlayGame_Easy";




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //! ���� ����
    public void OnClickStart()
    {
        GioleFunc.LoadScene(PLAY_SCENE_NAME);
    }

    //! ���� ����
    public void OnClickExit()
    {
        GioleFunc.QuitThisGame();
    }
}
