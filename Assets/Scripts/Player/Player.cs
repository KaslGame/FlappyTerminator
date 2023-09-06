using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlaneMover))]
public class Player : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;
 
    private PlaneMover _mover;
    [SerializeField] private int _score;

    private void Start()
    {
        _mover = GetComponent<PlaneMover>();
    }

    public void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetPlane();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}