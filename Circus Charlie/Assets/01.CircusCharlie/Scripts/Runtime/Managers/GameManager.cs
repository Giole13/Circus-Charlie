using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerController player = default;

    
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerOBJ = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);
        player = playerOBJ.FindChildObj(GioleData.PLAYER_OBJ_NAME).
            GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GioleFunc.LoadScene(GioleData.PLAY_SCENE_NAME);
            }
        }
    }
}
