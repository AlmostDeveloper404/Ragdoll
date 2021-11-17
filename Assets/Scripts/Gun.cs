using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] float FireRate = 0.2f;
    [SerializeField] Transform FirePoint;

    List<Bullet> bullets = new List<Bullet>();
    [SerializeField] GameObject BulletPref;

    [SerializeField] float BulletSpeed = 40f;

    Camera _camera;
    [SerializeField] int MaxBulletsInScene = 40;
    PlayerMovement playerMovement;

    public int GunIndex;

    int currentBulletInList = 0;
    float _timer;

    private void Awake()
    {
        _timer = 0;
        _camera = Camera.main;
    }


    private void Start()
    {
        playerMovement = PlayerMovement.instance;

        for (int i = 0; i < MaxBulletsInScene; i++)
        {
            GameObject bullet = Instantiate(BulletPref);
            bullets.Add(bullet.GetComponent<Bullet>());
        }

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer < 0 && playerMovement.CanShoot())
        {
            TryShoot();
            _timer = FireRate;
        }
    }
  
    void TryShoot()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);


        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider)
            {
                Shoot(hitInfo.point);
            }
        }
    }

    void Shoot(Vector3 desiredPos)
    {
        if (currentBulletInList >= bullets.Count)
        {
            currentBulletInList = 0;
        }

        Bullet bullet = bullets[currentBulletInList];
        bullet.gameObject.SetActive(true);

        bullet.transform.position = FirePoint.position;
        bullet.transform.rotation = FirePoint.rotation;

        Vector3 dir = desiredPos - FirePoint.position;
        bullet.LaunchBullet(dir,BulletSpeed);

        currentBulletInList++;
    }
}
