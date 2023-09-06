using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _panel;

    private void Awake()
    {
        _panel.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    public void Again()
    {
        int gameScene = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene(gameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDied()
    {
        _panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}