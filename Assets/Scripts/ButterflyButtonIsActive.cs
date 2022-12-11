using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyButtonIsActive : MonoBehaviour
{
    [SerializeField] private Button MenuStart;

    [SerializeField] private Button Inventory;

    [SerializeField] private Button AddItem;
    [SerializeField] private Button DeleteItem;

    [SerializeField] private Button BackMenu;
    [SerializeField] private Button BackStart;
    
    [SerializeField] private GameObject PanelStart;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PanelInvetory;

    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject Item;

    private Stack<GameObject> _stackItem;



    private bool _menuStart => PanelStart.gameObject.activeSelf;
    private bool _mainMenu => MainMenu.gameObject.activeSelf;
    private bool _punelInventory=> PanelInvetory.gameObject.activeSelf;

    private void Start()
    {
        _stackItem = new Stack<GameObject>();

        MenuStart.onClick.AddListener(DeActiveMenuStart);
        BackStart.onClick.AddListener(ActiveMenuStart);

        Inventory.onClick.AddListener(DeActiveMainMenu);
        BackMenu.onClick.AddListener(ActiveMainMenu);

        AddItem.onClick.AddListener(AddItemContent);

        DeleteItem.onClick.AddListener(DeleteItemContent);

        //Debug.Log(PanelStart.transform.childCount);
    }

   
    public void AddItemContent()
    {
        if (_stackItem.Count == 100) return;
        var item = Instantiate(Item, Content.transform, false);
        _stackItem.Push(item);
    }

    public void DeleteItemContent()
    {
        if (_stackItem == null) return;
        
        var item = _stackItem.Pop();
        Destroy(item);
        
    }



    public void DeActiveMenuStart()
    {
        if (_menuStart)
        {
            
            PanelStart.gameObject.SetActive(false);
            SetAactiveChildren(PanelStart, false);

            MainMenu.gameObject.SetActive(true);
            SetAactiveChildren(MainMenu, true);
        }
    }
    public void ActiveMenuStart()
    {
        if (!_menuStart)
        {
            PanelStart.gameObject.SetActive(true);
            SetAactiveChildren(PanelStart, true);

            MainMenu.gameObject.SetActive(false);
            SetAactiveChildren(MainMenu, false);
        }
    }

    public void DeActiveMainMenu()
    {
        if (_mainMenu)
        {
            MainMenu.gameObject.SetActive(false);
            SetAactiveChildren(MainMenu, false);

            PanelInvetory.gameObject.SetActive(true);
            SetAactiveChildren(PanelInvetory, true);
        }
    }
    public void ActiveMainMenu()
    {
        if (!_mainMenu)
        {
            MainMenu.gameObject.SetActive(true);
            SetAactiveChildren(MainMenu, true);

            PanelInvetory.gameObject.SetActive(false);
            SetAactiveChildren(PanelInvetory, false);
        }
    }

    private void SetAactiveChildren(GameObject parentUI, bool activeself)
    {
        var children = parentUI.transform;
        for (int i = 0; i < children.childCount; i++)
        {
            var childrenSelect = children.GetChild(i).gameObject;
           
            //if (childrenSelect.TryGetComponent(out Image image)) image.enabled = activeself;
            
            //if (childrenSelect.TryGetComponent(out Button button)) button.enabled = activeself;

            //if (childrenSelect.TryGetComponent(out Text text))  text.enabled = activeself;

            //if (childrenSelect.TryGetComponent(out CanvasRenderer canvasRenderer)) canvasRenderer.cullTransparentMesh = activeself;

            childrenSelect.SetActive(activeself);
      
        }
    }
}
