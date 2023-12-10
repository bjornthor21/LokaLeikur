using UnityEngine;
using UnityEngine.UI;

public class UIPointBar : MonoBehaviour
{
    public static UIPointBar instance { get; private set; }

    public Image mask;
    float originalSize;

    // parent objecti� sem geymir alla peningana
    static GameObject coinsObject;
    // fj�ldi childs � parent
    int childCount;

    void Awake()
    {
        coinsObject = GameObject.Find("coins");
        // tali� fj�lda coins sem eru child � coins parent
        childCount = coinsObject.transform.childCount;

        // ef instanci� er null e�a ekki sma og �etta coin �� er �v� eytt og scriptan h�ttir
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        // uprunaleg st�r� stigateljarans
        originalSize = mask.rectTransform.rect.width;
    }

    // einu stigi b�tt vi� stigateljaran
    public void AddPoint()
    {
        // h�r er st�r�inn sett og inn� hana er sett hve miki� h�n � a� h�kka um
        // n�verandi st�r� + hve einn peningur h�kkar um miki�
        // �ar sem scriptan veit ekki hversu st�r fullur stigateljarinn er �� notum vi� upprunalegu st�r�
        // UIHealtbar sem byrjar fullur og er alltaf jafn st�r og stigateljarinn � a� vera
        SetSize(mask.rectTransform.rect.width + UIHealthBar.originalSize / childCount);
    }

    void SetSize(float size)
    {
        // st�kkar um n�ju st�r�ina en leyfir ekki a� minnka minna en upprunaleg st�r� hans
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Max(size, originalSize));
    }
}
