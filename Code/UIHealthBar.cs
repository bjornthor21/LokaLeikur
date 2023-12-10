using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    // Static instance af clasanum sem leyfir ��rum scriptum a� komast � hana.
    public static UIHealthBar instance { get; private set; }

    // setur inn maski� sem er nota� til a� minnka health teljaran
    public Image mask;
    // upprunaleg st�r� hans. sem er public static svo a� UIPointbar.cs getur n�� � upprunalegu st�r� hans
    public static float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // upprunaleg st�r� sett sem n�verandi st�r� fyrst �egar scriptan er keyr�
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        // minnkar teljaran
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
