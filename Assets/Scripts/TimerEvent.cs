using UnityEngine;
using UnityEngine.Events;
public class TimerEvent : MonoBehaviour
{
    public float time = 5;
    public bool repeat = false;
    public UnityEvent onTimerComplete;
    private void Start()
    {
        if (repeat)
        {
            InvokeRepeating("OnTimerComplete", 0, time);
        }
        else
        {
            Invoke("OnTimerComplete", time);
        }
    }
    private void OnTimerComplete()
    {
        onTimerComplete.Invoke();
    }
}
