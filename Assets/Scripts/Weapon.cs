using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPointBullet;
    [SerializeField] private float _timeBetweenShoot;

    private bool _canShoot = true;
    private float ElapsedTime;

    private void Update()
    {
        Reload();
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            Quaternion _playerRotation = transform.rotation;

            _canShoot = false;

            Bullet bullet = Instantiate(_bulletPrefab, _spawnPointBullet.position, _playerRotation);
            bullet.SetRotation(_spawnPointBullet.rotation);
        }
    }

    private void Reload()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > _timeBetweenShoot)
        {
            ElapsedTime = 0;
            _canShoot = true;
        }
    }
}
