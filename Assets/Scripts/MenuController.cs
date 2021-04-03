using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum MenuEnum 
{
    gameMenu,
    other
}
[System.Serializable]
public class PanelUI
{
    public MenuEnum _menuEnum;
    public GameObject _panel;
    public Button _EscButton;
    public TextMeshProUGUI _text;
}
public class MenuController : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [Header("Menu")]
    [SerializeField] private PanelUI _menu;
    [SerializeField] private Button _buttonMenu;
    
    private RaycastHit2D _hit2D;

    private void Awake()
    {
        _menu._EscButton.onClick.AddListener(OffPanel);
        _buttonMenu.onClick.AddListener(OnPanel);
    }

    public void OnPanel()
    {
        _hit2D = Physics2D.Raycast(Camera.main.transform.position, Vector2.zero);
        if (_hit2D.collider != null)
        {
            _menu._text.text = String.Format("<color=#000000> Sprite name - </color> " + _hit2D.collider.name);
        }
        _controller.setIsMove(false);
        _menu._panel.gameObject.SetActive(true);
        
        
    }

    public void OffPanel()
    {
        _controller.setIsMove(true);
        _menu._panel.gameObject.SetActive(false);
        
    }
}
