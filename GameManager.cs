using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _finishMenu;
    [SerializeField] GameObject _scoreHUD;

    [SerializeField] TextEditor _textEditor;

    [SerializeField] AudioSource _loseSound;
    
    public static GameManager Instance;

    public bool gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
        }
        else
        {
            Destroy(Instance);
        }
    }

    void Start()
    {
        _scoreHUD.SetActive(false);
        _startMenu.SetActive(true);
        _finishMenu.SetActive(false);
        
        gameOver = true;

        _textEditor.UpdateTextBestScore();

        ShowAd();
    }

    public void StartGame()
    {
        _startMenu.SetActive(false);
        _scoreHUD.SetActive(true);

        gameOver = false;
    }

    public void GameOver()
    {
        _finishMenu.SetActive(true);

        Progress.Instance.SaveData();

        Instantiate(_loseSound);

        gameOver = true;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowAd()
    {
        YandexGame.FullscreenShow();
    }
}
