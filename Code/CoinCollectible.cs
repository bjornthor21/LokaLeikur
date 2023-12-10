using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinCollectible : MonoBehaviour
{

    public AudioClip coinClip;

    private void Start()
    {

        // h�r er �g sm� a� leika m�r
        // stiga teljarinn telur alla peningana sem eru � empty object sem heitir coins til a� reikna hversu
        // miki� einn peninguur � a� st�kka UIpoints miki�
        // �annig h�r er logic sem ef a� �a� er peningur sem er ekki inn� coins �� ey�ist hann
        // svo a� peningurinn ey�inleggur ekki stigateljaran.
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
            // stig h�kka um einn, peningnum er eytt, stigateljarinn h�kka�ur og hlj�� spila�
            RubyController.points += 1;
            Destroy(gameObject);
            UIPointBar.instance.AddPoint();
            controller.PlaySound(coinClip);
        }
    }
}