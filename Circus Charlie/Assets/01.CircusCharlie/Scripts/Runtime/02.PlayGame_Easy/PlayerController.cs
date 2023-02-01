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

    //! ���� ����� �� ���� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGroundTouch = true;
    }

    //! ������ �������� ���� ���� �Ұ���
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGroundTouch = false;
    }

    //! �÷��̾ �״� �Լ�
    public void Die()
    {

        //playerRigid2D.velocity = Vector2.zero;
        Debug.Log("����߽��ϴ�!");
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //PlayerController player = collision.transform.GetComponent<PlayerController>();
        //player.
        Die();
    }
}
