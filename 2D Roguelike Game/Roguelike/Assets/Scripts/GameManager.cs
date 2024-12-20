using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BoardManager BoardManager;
    public PlayerController PlayerController;

    public TurnManager TurnManager { get; private set; }

    private int m_FoodAmount = 100; // Player's food amount

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        TurnManager = new TurnManager();

        // Subscribe the OnTurnHappen method to the OnTick event
        TurnManager.OnTick += OnTurnHappen;

        BoardManager.Init();
        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1));
    }

    // Called when a turn happens
    private void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        Debug.Log("Current amount of food: " + m_FoodAmount);
    }
}