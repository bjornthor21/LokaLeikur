using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // geumir rigidbody skotsins
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // public fall sem sk�tur skotinu � gefna �tt me� gefnu afli
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        // athugar ef skoti� er langt fr� upphaflegu sta�setningu ef svo ey�ir skotinu
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    // collision detection sem er kalla� � �egar skoti� snertir annan rigidbody collider
    void OnCollisionEnter2D(Collision2D other)
    {
        // ef colliderinn sem skoti� hitti er �vinur
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            // �� er shot falli� � �vina scriptunni kalla�
            e.shot();
        }

        // ey�ir alltaf skotinu �egar �a� snerir annan collider
        Destroy(gameObject);
    }
}
