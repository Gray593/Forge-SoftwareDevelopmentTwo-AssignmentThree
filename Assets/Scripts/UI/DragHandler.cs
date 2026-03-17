using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// This class manages the movement of tiles within the game
[RequireComponent(typeof(Image))]
public class DragHandler : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TileDefinition TileDefinition { get; private set; }

    private Image         _image;
    private Canvas        _canvas;
    private InventorySlot _inventoryOwner;
    private GridCell      _gridOwner;
    private GameObject    _ghost;
    private bool          _placedSuccessfully = false; // prevents double return on success


    //The following two Init functions are called by the inventory slot and grid cell respectively, depending
    // on where the tile is being dragged from
    public void InitFromInventory(TileDefinition tile, InventorySlot owner)
    {
        TileDefinition  = tile;
        _inventoryOwner = owner;
        _image          = GetComponent<Image>();
        _canvas         = FindFirstObjectByType<Canvas>();
    }

    public void InitFromGrid(TileDefinition tile, GridCell owner)
    {
        TileDefinition = tile;
        _gridOwner     = owner;
        _image         = GetComponent<Image>();
        _canvas        = FindFirstObjectByType<Canvas>();
    }

    //This function is called when a piece starts being dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Checks if the piece can be dragged
        if (_inventoryOwner != null && !_inventoryOwner.CanDrag)
        {
            eventData.pointerDrag = null;
            return;
        }

        // Tries to find the canvas again if it couldnt be found initially
        if (_canvas == null) _canvas = FindFirstObjectByType<Canvas>();
        if (_canvas == null) { Debug.LogError("No Canvas found in scene"); return; }

        // Creates a ghost copy the tile follows the mouse while the original stays in the inventory pane
        _ghost = new GameObject("DragGhost");
        _ghost.transform.SetParent(_canvas.transform, false);

        Image ghostImage         = _ghost.AddComponent<Image>();
        ghostImage.sprite        = _image.sprite;
        ghostImage.raycastTarget = false; // registers the tile dropping on the cell below

        RectTransform ghostRT  = _ghost.GetComponent<RectTransform>();
        ghostRT.sizeDelta      = GetComponent<RectTransform>().sizeDelta;
        ghostRT.position       = transform.position;

        CanvasGroup cg         = _ghost.AddComponent<CanvasGroup>();
        cg.blocksRaycasts      = false;
        cg.alpha               = 0.8f;

        // If dragging from grid, remove tile from that cell immediately
        _placedSuccessfully = false;
        if (_gridOwner != null)
            GridManager.Instance.TryRemoveTile(_gridOwner.GridX, _gridOwner.GridY);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_ghost != null)
            _ghost.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Cleanup if statement that destroys the ghost image if its not placed in a valid position
        if (_ghost != null) { Destroy(_ghost); _ghost = null; }

        // returns the tile to the inventory if its not placed successfully
        if (_gridOwner != null && !_placedSuccessfully)
            InventoryManager.Instance?.ReturnTile(TileDefinition);
    }

    // Placement callback function that destroys the ghost tile when tiles are placed successfully.
    public void OnPlacedSuccessfully()
    {
        _placedSuccessfully = true;
        if (_ghost != null) { Destroy(_ghost); _ghost = null; }

        // if the tile has been dragged from the inventory decrement the inventory count of that tile 
        if (_inventoryOwner != null)
            _inventoryOwner.OnTilePlaced();

        AudioManager.Instance?.PlaySnap();
    }

    public void OnPlaceFailed()
    {
        if (_ghost != null) { Destroy(_ghost); _ghost = null; }

        // If a tile is picked up from the grid and placement failed, return the tile back to inventory
        if (_gridOwner != null)
            InventoryManager.Instance?.ReturnTile(TileDefinition);

        AudioManager.Instance?.PlayError();
    }
}