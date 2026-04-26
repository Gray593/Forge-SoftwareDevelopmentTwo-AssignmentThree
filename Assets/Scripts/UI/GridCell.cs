using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//This class is one singular grid cell, it is used in every cell within the game grid 

public class GridCell : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] private Image    backgroundImage;
    [SerializeField] private Image    tileIconImage;
    [SerializeField] private Color    emptyColor    = new Color(0.2f, 0.2f, 0.2f, 1f);
    [SerializeField] private Color    occupiedColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    public int GridX { get; private set; }
    public int GridY { get; private set; }

    private TileDefinition _currentTile;
    public void Init(int x, int y)
    {
        GridX = x;
        GridY = y;
        ClearTile();
    }

    // Set tile is responsible for setting a tile to the current grid cell and also enabling the drag handler
    public void SetTile(TileDefinition tile)
    {
        _currentTile = tile;
        tileIconImage.sprite        = tile.icon;
        tileIconImage.enabled       = true;
        tileIconImage.raycastTarget = true;
        if (backgroundImage) backgroundImage.color = occupiedColor;

        DragHandler drag = tileIconImage.GetComponent<DragHandler>();
        if (drag != null) drag.InitFromGrid(tile, this);

        AudioManager.Instance?.PlaySnap();
    }
    // clear tile is used to remove a tile from the cell
    public void ClearTile()
    {
        _currentTile = null;
        tileIconImage.enabled       = false;
        tileIconImage.raycastTarget = false;
        if (backgroundImage) backgroundImage.color = emptyColor;
    }

    // The OnDrop function is used to determine if a tile can be placed or not 
    public void OnDrop(PointerEventData eventData)
    {
        DragHandler drag = eventData.pointerDrag?.GetComponent<DragHandler>();
        if (drag == null) return;

        bool placed = GridManager.Instance.TryPlaceTile(GridX, GridY, drag.TileDefinition);
        if (placed)
            drag.OnPlacedSuccessfully();
        else
            drag.OnPlaceFailed();
    }

    // The OnPointerClick function removes tiles from the cell when they are right clicked upon
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (_currentTile != null && GridManager.Instance.TryRemoveTile(GridX, GridY))
                InventoryManager.Instance?.ReturnTile(_currentTile);
        }
    }
}