using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHoopController : MonoBehaviour
{
    RectTransform fireHoopObjRect = default;


    //후프 속도
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        fireHoopObjRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        PlayerController player = collision.transform.GetComponent<PlayerController>();
    //        player.Die();
    //    }
    //}

}
