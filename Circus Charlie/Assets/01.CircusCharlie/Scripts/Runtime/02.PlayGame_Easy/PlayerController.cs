using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid2D = default;
    public float jumpPower = 300f;

    private bool isGroundTouch = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid2D = gameObject.GetComponent<Rigidbody2D>();

        //_playerRigid2D.AddForce(new Vector2(0, 1000));

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClickJump()
    {
        if (isGroundTouch)
        {
            playerRigid2D.AddForce(new Vector2(0, jumpPower));
        }
    }

    //! 땅에 닿았을 때 점프 가능
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGroundTouch = true;
    }

    //! 땅에서 떨어졌을 때는 점프 불가능
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGroundTouch = false;
    }

    //! 플레이어가 죽는 함수
    public void Die()
    {

        //playerRigid2D.velocity = Vector2.zero;
        Debug.Log("사망했습니다!");
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //PlayerController player = collision.transform.GetComponent<PlayerController>();
        //player.
        Die();
    }
}
