using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// Displays notifications when the goal is met

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    [SerializeField] private GameObject toastPrefab;    
    [SerializeField] private Transform  toastParent;    
    [SerializeField] private float      displayTime = 2.5f;
    [SerializeField] private float      fadeTime    = 0.4f;

    private Queue<string> _queue = new Queue<string>();
    private bool          _showing = false;

    
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }
    // Queues up notification message
    public void ShowNotification(string message)
    {
        _queue.Enqueue(message);
        if (!_showing) StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        _showing = true;

        while (_queue.Count > 0)
        {
            string msg = _queue.Dequeue();
            yield return StartCoroutine(ShowToast(msg));
        }

        _showing = false;
    }
    // Displays the notification    
    private IEnumerator ShowToast(string message)
    {
        GameObject toast = Instantiate(toastPrefab, toastParent);
        TMP_Text label   = toast.GetComponentInChildren<TMP_Text>();
        if (label) label.text = message;

        CanvasGroup cg = toast.GetComponent<CanvasGroup>();
        if (cg == null) cg = toast.AddComponent<CanvasGroup>();

        // Fades the message in and out
        yield return FadeCanvasGroup(cg, 0f, 1f, fadeTime);
        yield return new WaitForSeconds(displayTime);
        yield return FadeCanvasGroup(cg, 1f, 0f, fadeTime);

        Destroy(toast);
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed  += Time.deltaTime;
            cg.alpha  = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }
        cg.alpha = to;
    }
}
