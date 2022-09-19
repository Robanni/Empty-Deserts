using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private PlayerCombat _player;
    [SerializeField] private GameObject _gameObject;    
    void Start()
    {
        _player = FindObjectOfType<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowDathPanelIfPlayerISDead();
    }

    private void ShowDathPanelIfPlayerISDead()
    {
        if (_player.IsDead)
        {
            _gameObject.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
