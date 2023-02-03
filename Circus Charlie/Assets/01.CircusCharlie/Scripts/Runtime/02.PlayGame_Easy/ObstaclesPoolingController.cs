using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPoolingController : MonoBehaviour
{
    public float hoopSpeed = 1f;
    public float hoopCreateTime = 3f;
    public float hoopMoveSpeed = 1f;

    public GameObject bgPoolObj = default;


    private GameObject FrontObstaclesObj = default;

    public List<GameObject> hoopPoolList = default;

    private float createTime = 0;

    private RectTransform ObstaclesRect = default;
    private RectTransform bgPoolObjRect = default;
    private const string SHORT_HOOP_NAME = "FireHoopShort";
    private const string LONG_HOOP_NAME = "FireHoopLong";

    private BgpoolScrollingController bgPoolObjScript = default;

    public bool makerEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 풀링할 친구들 가져오기
        GameObject shortHoopObj = GioleFunc.FindChildObj(gameObject, SHORT_HOOP_NAME);
        GameObject longHoopObj = GioleFunc.FindChildObj(gameObject, LONG_HOOP_NAME);
        ObstaclesRect = gameObject.GetComponent<RectTransform>();

        FrontObstaclesObj = GioleFunc.GetRootObj("FrontObstacles").
            FindChildObj("ObstaclesFools");



        bgPoolObjRect = bgPoolObj.GetComponent<RectTransform>();

        bgPoolObjScript = bgPoolObj.GetComponent<BgpoolScrollingController>();

        hoopMoveSpeed = bgPoolObjScript.backGroundMoveSpeed;

        // 인스턴스 해서 풀에다가 넣어주기!
        for (int i = 0; i < 3; ++i)
        {
            // bgPool에다가 넣어주기
            GameObject shorthoop_ = Instantiate(shortHoopObj, FrontObstaclesObj.transform);
            shorthoop_.name = SHORT_HOOP_NAME + "_" + i;
            hoopPoolList.Add(shorthoop_);
            shorthoop_.SetActive(false);
        }
        for (int i = 3; i < 6; ++i)
        {
            // bgPool에다가 넣어주기
            GameObject longhoop_ = Instantiate(longHoopObj, FrontObstaclesObj.transform);
            longhoop_.name = LONG_HOOP_NAME + "_" + i;
            hoopPoolList.Add(longhoop_);
            longhoop_.SetActive(false);
        }

        shortHoopObj.SetActive(false);
        longHoopObj.SetActive(false);

        //bgPoolObjScript.SyncMoveLeft(ref isSyncMoveLeft);
        //bgPoolObjScript.SyncMoveRight(ref isSyncMoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        //ObstaclesRect.anchoredPosition = uiRect.anchoredPosition;


        //if (Input.GetKey(KeyCode.D))
        //{
        //    // 만약 방향키를 눌렀을 때 가속도가 더해진다면?
        //    ObstaclesRect.anchoredPosition += Vector2.left * Time.deltaTime * hoopMoveSpeed;
        //}
        //else
        //{
        //}



        if (makerEnabled)
        {

            ObstaclesRect.anchoredPosition = Vector2.zero;

            createTime += Time.deltaTime;

            // 랜덤으로 시간마다 후프를 켜주는 로직
            if (hoopCreateTime < createTime)
            {
                int i = Random.RandomRange(0, 6);
                if (hoopPoolList[i].activeSelf == true)
                {
                    /* Do nothing */
                }
                else
                {
                    //플레이어 앞에다가 위치 시켜주기
                    hoopPoolList[i].GetRect().anchoredPosition =
                        //BgPOol의 절대값으로 올려줘야겠지요?
                        new Vector2(Mathf.Abs(bgPoolObjRect.anchoredPosition.x) + 800f,
                        hoopPoolList[i].GetComponent<RectTransform>().anchoredPosition.y);
                    hoopPoolList[i].SetActive(true);
                }
                createTime = 0f;
            }

        }
    }       // Update()


    //! 불고리 생성 중단 함수
    public void MakerController()
    {
        makerEnabled = false;
    }
}
