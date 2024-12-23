using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStik : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] RectTransform ThumbStikTrans;
    [SerializeField] RectTransform Bacgroundtrans;
    [SerializeField] RectTransform centerTrans;

    

    public delegate void OnStickInputValueUpdate(Vector2 inputValue);
    public delegate void OnStickTabed();
    public event OnStickInputValueUpdate onStickInputValueUpdate;
    public event OnStickTabed onStickTabed;
    bool bDarHalDragBod;
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log($"On Drag Fired {eventData.position}");
        Vector2 Touchpos = eventData.position;
        Vector2 centerpos = Bacgroundtrans.position;
        Vector2 localoffset = Vector2.ClampMagnitude(Touchpos - centerpos, Bacgroundtrans.sizeDelta.x/2);
        Vector2 inputVal = localoffset / (Bacgroundtrans.sizeDelta.x / 2);
        ThumbStikTrans.position = centerpos + localoffset;
        onStickInputValueUpdate?.Invoke(inputVal);
        bDarHalDragBod = true;
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        Bacgroundtrans.position = eventData.position;
        ThumbStikTrans.position = eventData.position;
        bDarHalDragBod = false; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Bacgroundtrans.position = centerTrans.position;
        ThumbStikTrans.position = Bacgroundtrans.position;
        onStickInputValueUpdate.Invoke(Vector2.zero);
        if (!bDarHalDragBod)
        {
            onStickTabed?.Invoke();
        }

    }
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
