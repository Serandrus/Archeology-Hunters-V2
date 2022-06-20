using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;
    private Vector2 posInput;

    // Start is called before the first frame update
    void Start()
    {
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imgJoystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = posInput.x / (imgJoystickBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (imgJoystickBg.rectTransform.sizeDelta.y);

            //normalize
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            //Joystick move
            imgJoystick.rectTransform.anchoredPosition = new Vector2(posInput.x * (imgJoystickBg.rectTransform.sizeDelta.x / 4), posInput.y * (imgJoystickBg.rectTransform.sizeDelta.y / 4));
        }
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        OnDrag(eventdata);
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        posInput = Vector2.zero;
        imgJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }

    public float inputMouseX()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Mouse X");
    }

    public float inputMouseY()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Mouse Y");
    }
}
