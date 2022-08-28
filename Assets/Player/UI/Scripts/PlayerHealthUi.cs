using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthUi : MonoBehaviour
{
    private PlayerCombat _player;
    private TextMeshProUGUI _playerHealthUiText;
    void Start()
    {
        _player = FindObjectOfType<PlayerCombat>();
        _playerHealthUiText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ShowPlayerHealth();
    }

    private void ShowPlayerHealth()
    {
        string health = _player.Health.ToString();
        _playerHealthUiText.text = "Health: " + health;
    }
}
