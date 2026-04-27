using UnityEngine;
using TMPro;

// displays in game stats
public class StatsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chainsText;
    [SerializeField] private TextMeshProUGUI lastTickText;
    [SerializeField] private TextMeshProUGUI bestChainText;
    [SerializeField] private TextMeshProUGUI tilesText;

    private void Start()
    {
        GameManager.Instance.OnTickComplete += UpdateStats;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnTickComplete -= UpdateStats;
    }

    private void UpdateStats(GameManager.TickStats stats)
    {
        chainsText.text    = $"Active Chains: {stats.chainsEvaluated}";
        lastTickText.text  = $"Last Tick: +{stats.balanceThisTick:F0}";
        bestChainText.text = $"Best Chain: {stats.bestChainValue:F0}";
        tilesText.text     = $"Tiles Placed: {stats.tilesOnGrid}";
    }
}