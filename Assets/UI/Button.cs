using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class Button : MonoBehaviour,  IPointerClickHandler
{
    public delegate void ButtonClicked();
    public event ButtonClicked ButtonClickedEvent;

    public delegate IEnumerator TimerButtonClicked();
    public event TimerButtonClicked TimerButtonClickedEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonClickedEvent?.Invoke();
        if(TimerButtonClickedEvent != null)
        StartCoroutine(TimerButtonClickedEvent?.Invoke());
    }
}
