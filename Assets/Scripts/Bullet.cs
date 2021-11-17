using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _bulletLifetime=1f;

    private void OnTriggerEnter(Collider collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Die();
        }
        gameObject.SetActive(false);
    }

    public void LaunchBullet(Vector3 dir,float speed)
    {
        _rigidbody.velocity = dir.normalized * speed;
        StartCoroutine(HideBullet());
    }

    IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(_bulletLifetime);
        gameObject.SetActive(false);
    }
}
