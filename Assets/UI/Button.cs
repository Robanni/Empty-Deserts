using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class Button : MonoBehaviour,  IPointerClickHandler
{
    public delegate void ButtonClicked();
    public event ButtonClicked ButtonClickedEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonClickedEvent?.Invoke();
    }
}
