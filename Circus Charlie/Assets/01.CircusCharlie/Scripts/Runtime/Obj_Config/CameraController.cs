using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject playerObj = default;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);
        playerObj = main.FindChildObj(GioleData.PLAYER_OBJ_NAME);


        

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = playerObj.transform.position;
    }


    private void FixedUpdate()
    {
    }

}
