using UnityEngine;
using UnityEngine.EventSystems;

public class Button: MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }
}