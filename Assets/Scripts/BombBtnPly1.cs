using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BombBtnPly1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        print(buttonPressed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        print(buttonPressed);
    }
}