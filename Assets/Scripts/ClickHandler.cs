using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClickHandler : MonoBehaviour
{

    public UnityEvent upEvent;
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        Debug.Log("Down");
        downEvent?.Invoke();
    }

    private void OnMouseUp()
    {
        Debug.Log("Up");
        upEvent?.Invoke();
    }
}
