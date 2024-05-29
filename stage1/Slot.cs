using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerEnterHandler , IPointerExitHandler
{//IPointerClickHandler,

    public GameObject Slot_;

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage;  // 아이템의 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    [SerializeField]
    Transform Parent_transform;

    private HP_Manager hp_manager;

    public SoundEffect_Manager soundEffect;

    //https://daily50.tistory.com/508 참고해서 마우스 오버 이벤트...(마우스 오버하면 해당 슬롯의 하위 Activate부분이 활성화되면서 시각적 효과를 줌)
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        

        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData) //아이템 사용
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment)
                {
                    // 장착
                    //StartCoroutine(theWeaponManager.ChangeWeaponCoroutine(item.weaponType, item.itemName));
                }
                else
                {
                    // 소비
                    ItemUse(item);
                    soundEffect.Effect_Sound("ITEMUSE");
                    Debug.Log(item.itemName + " 을 사용했습니다.");
                    SetSlotCount(-1);
                }
            }
        }
    }

        public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
            DragSlot.instance.SetColor(1);
            
        }
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        
        if (item != null)
        {
            
            DragSlot.instance.transform.position = eventData.position;
            

        }
        
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
            
        }
            
    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }


    private void Start()
    {
        this.gameObject.SetActive(true);
        go_CountImage.SetActive(false);
        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(false);
        hp_manager = GameObject.FindObjectOfType<HP_Manager>();
        soundEffect = GameObject.FindObjectOfType<SoundEffect_Manager>();

    }

    private void Awake()
    {
        Slot_=this.gameObject;
    }


    // 아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
            
    }

    // 해당 슬롯 하나 삭제
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }


    public void ItemUse(Item item_)
    {
        switch (item_.itemType)
        {
            case Item.ItemType.Health:
                hp_manager.Heal(item.Hp_amount);
                break;
            case Item.ItemType.Use:
                break;
            default:
                break;
        }
    }


}
