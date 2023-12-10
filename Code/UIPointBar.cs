using UnityEngine;
using UnityEngine.UI;

public class UIPointBar : MonoBehaviour
{
    public static UIPointBar instance { get; private set; }

    public Image mask;
    float originalSize;

    // parent objectið sem geymir alla peningana
    static GameObject coinsObject;
    // fjöldi childs í parent
    int childCount;

    void Awake()
    {
        coinsObject = GameObject.Find("coins");
        // talið fjölda coins sem eru child í coins parent
        childCount = coinsObject.transform.childCount;

        // ef instancið er null eða ekki sma og þetta coin þá er því eytt og scriptan hættir
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        // uprunaleg stærð stigateljarans
        originalSize = mask.rectTransform.rect.width;
    }

    // einu stigi bætt við stigateljaran
    public void AddPoint()
    {
        // hér er stærðinn sett og inní hana er sett hve mikið hún á að hækka um
        // núverandi stærð + hve einn peningur hækkar um mikið
        // þar sem scriptan veit ekki hversu stór fullur stigateljarinn er þá notum við upprunalegu stærð
        // UIHealtbar sem byrjar fullur og er alltaf jafn stór og stigateljarinn á að vera
        SetSize(mask.rectTransform.rect.width + UIHealthBar.originalSize / childCount);
    }

    void SetSize(float size)
    {
        // stækkar um nýju stærðina en leyfir ekki að minnka minna en upprunaleg stærð hans
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Max(size, originalSize));
    }
}
