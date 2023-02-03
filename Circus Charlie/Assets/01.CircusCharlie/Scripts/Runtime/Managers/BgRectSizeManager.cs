using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRectSizeManager : MonoBehaviour
{

    public GameObject bgPoolObj = default;

    

    // Start is called before the first frame update
    void Start()
    {
        bgPoolObj = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME).FindChildObj(GioleData.BGPOOL_OBJ_NAME);

        RectTransform myRect = gameObject.GetComponent<RectTransform>();

        myRect = bgPoolObj.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
