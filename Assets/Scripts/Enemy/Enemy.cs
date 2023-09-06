using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _reward;

    private Transform _target;

    private Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        SetRotation();
        _weapon.Shoot();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Die()
    {
        if (_target.TryGetComponent(out Player player))
            player.AddScore(_reward);

        gameObject.SetActive(false);
    }

    private void SetRotation()
    {
        if (_target != null)
        {
            var direction = _target.position - transform.position;
            direction.Normalize();
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
