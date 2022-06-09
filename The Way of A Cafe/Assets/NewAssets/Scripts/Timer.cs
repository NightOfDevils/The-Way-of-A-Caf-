using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Timer UI references: ")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TextMeshProUGUI uiText;
    public CraftingManager craftingManager;
    public Timer timer;

    public int Duration { get; private set; }

    private int remainingDuration;

    private void ResetTimer()
    {
        uiText.SetText("00:00");
        uiFillImage.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }

    public Timer setDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        uiText.SetText(string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60));
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        craftingManager.SpawnProduct();
        ResetTimer();
        timer.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
