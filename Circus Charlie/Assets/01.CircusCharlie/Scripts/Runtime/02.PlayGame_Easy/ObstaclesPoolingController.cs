using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPoolingController : MonoBehaviour
{
    public float hoopSpeed = 1f;
    public float hoopCreateTime = 3f;

    public List<GameObject> hoopPoolList = default;

    private float createTime = 0;


    private const string SHORT_HOOP_NAME = "FireHoopShort";
    private const string LONG_HOOP_NAME = "FireHoopLong";

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 풀링할 친구들 가져오기
        GameObject shortHoopObj = GioleFunc.FindChildObj(gameObject, SHORT_HOOP_NAME);
        GameObject longHoopObj = GioleFunc.FindChildObj(gameObject, LONG_HOOP_NAME);



        // 인스턴스 해서 풀에다가 넣어주기!
        for (int i = 0; i < 3; ++i)
        {
            GameObject shorthoop_ = Instantiate(shortHoopObj, gameObject.transform);
            shorthoop_.name = SHORT_HOOP_NAME + "_" + i;
            hoopPoolList.Add(shorthoop_);
            shorthoop_.SetActive(false);
        }
        for (int i = 3; i < 6; ++i)
        {
            GameObject longhoop_ = Instantiate(longHoopObj, gameObject.transform);
            longhoop_.name = LONG_HOOP_NAME + "_" + i;
            hoopPoolList.Add(longhoop_);
            longhoop_.SetActive(false);
        }

        shortHoopObj.SetActive(false);
        longHoopObj.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        createTime += Time.deltaTime;

        // 랜덤으로 시간마다 후프를 켜주는 함수
        if (hoopCreateTime < createTime)
        {
            int i = Random.RandomRange(0, 6);

            hoopPoolList[i].SetActive(true);

            createTime = 0f;
        }


    }
}
