using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TickUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI label;

    private float _nextCost;

    private void Start()
    {
        GameManager.Instance.OnTickUpgradeChanged += Refresh;
        GameManager.Instance.OnBalanceChanged += OnBalanceChanged;

        _nextCost = GameManager.TickUpgradeCosts[0];
        label.text = $"Faster Tick\n£{_nextCost}";
        button.interactable = GameManager.Instance.Balance >= _nextCost;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnTickUpgradeChanged -= Refresh;
        GameManager.Instance.OnBalanceChanged -= OnBalanceChanged;
    }

    private void Refresh(float nextCost, bool canUpgrade)
    {
        if (!canUpgrade) { label.text = "MAX SPEED"; button.interactable = false; return; }
        _nextCost = nextCost;
        label.text = $"Faster Tick\n${_nextCost}";
        button.interactable = GameManager.Instance.Balance >= _nextCost;
    }

    private void OnBalanceChanged(float newBalance)
    {
        button.interactable = newBalance >= _nextCost;
    }

    public void OnClick()
    {
        GameManager.Instance.PurchaseTickUpgrade();
    }
}