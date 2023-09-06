using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _speed;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _lifeTime)
            Destroy(gameObject);
        else
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Die();

        if (collision.TryGetComponent(out Enemy enemy))
            enemy.Die();

        Destroy(gameObject);
    }

    public void SetRotation(Quaternion rotation)
    {

        transform.rotation = rotation;
        transform.Rotate(new Vector3(0,0, -90f));
    }
}
