using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinCollectible : MonoBehaviour
{

    public AudioClip coinClip;

    private void Start()
    {

        // hér er ég smá að leika mér
        // stiga teljarinn telur alla peningana sem eru í empty object sem heitir coins til að reikna hversu
        // mikið einn peninguur á að stækka UIpoints mikið
        // þannig hér er logic sem ef að það er peningur sem er ekki inní coins þá eyðist hann
        // svo að peningurinn eyðinleggur ekki stigateljaran.
        Transform parentTransform = transform.parent;


        if (transform.parent != null)
        {
            if (parentTransform.name != "coins")
            {
                Destroy(gameObject);
            }
        }
        else Destroy(gameObject);
    }

    // ef player snertir pening
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            // stig hækka um einn, peningnum er eytt, stigateljarinn hækkaður og hljóð spilað
            RubyController.points += 1;
            Destroy(gameObject);
            UIPointBar.instance.AddPoint();
            controller.PlaySound(coinClip);
        }
    }
}