using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStageObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            // 여기서 다음 스태이지로 넘어가는 구문 짜주기
            Debug.Log("오 도착해썽요! ");
        }
    }

}
