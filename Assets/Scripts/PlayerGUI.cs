using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCutKey {
	public KeyCode keyCode {get; private set;}
	public KeyCode alias {get; private set;}
	public int index {get; private set;}
	public ShortCutKey(KeyCode keyCode, KeyCode alias, int index) {
		this.keyCode = keyCode;
		this.alias = alias;
		this.index = index;
	}
}

public class PlayerWeaponCtrl : IEquipable {

	private GameObject gameObject;

	public PlayerWeaponCtrl(GameObject gameObject) {
		this.gameObject = gameObject;
	}

	public void EquipGun(Gun gun) {
		// 
		GameObject weaponGO = GameObject.FindWithTag("weapon");
		Debug.Log(weaponGO);
		foreach (Transform child in weaponGO.transform) {
     		GameObject.Destroy(child.gameObject);
		}
		// TODO
		GameObject newWeaponGameObject = Resources.Load<GameObject>(gun.ResPath);
		GameObject newWeaponObject = GameObject.Instantiate(newWeaponGameObject, weaponGO.transform);
		newWeaponObject.transform.localPosition = Vector3.zero;
		newWeaponObject.transform.localRotation = Quaternion.identity;
	}
}

public class PlayerGUI : MonoBehaviour
{
	private const int SlotWidth = 82, SlotHeight = 64;
	private const int PaddingX = 4, MarginBottom = 24;
	private int inventoryCount = 5;
    private Dictionary<int, GameProps> inventory = new Dictionary<int, GameProps>();
    private List<ShortCutKey> shortCutKeys = new List<ShortCutKey>() {
    	new ShortCutKey(KeyCode.Keypad1, KeyCode.Alpha1, 0),
    	new ShortCutKey(KeyCode.Keypad2, KeyCode.Alpha2, 1),
    	new ShortCutKey(KeyCode.Keypad3, KeyCode.Alpha3, 2),
    	new ShortCutKey(KeyCode.Keypad4, KeyCode.Alpha4, 3),
    	new ShortCutKey(KeyCode.Keypad5, KeyCode.Alpha5, 4),
    };
    private PlayerWeaponCtrl weaponCtrl;

    void Start() {
		weaponCtrl = new PlayerWeaponCtrl(gameObject);
    }

    // private ShortCutKey shortCutKey = new ShortCutKey(KeyCode.Keypad1, KeyCode.Alpha1);

    private int findEmptySlotId() {
    	for(int i = 0; i < inventoryCount; i++)
    	{
    		if(inventory.ContainsKey(i)) {
    			continue;
    		} else {
    			return i;
    		}
    	}
    	return -1;
    }
	
    void OnPickProps(string propId) {
        Debug.Log("OnPickProps" + propId.ToString());
        GameProps picked = PropCreator.CreateGunProp(weaponCtrl);
        picked.Load();
        int slotIndex = findEmptySlotId();
        if(slotIndex != -1) {
        	inventory.Add(slotIndex, picked);
        } else {
        	Debug.Log("Insufficient capacity.");
        }
        // int slotId = 0;
        // foreach(var item in inventory)
        // {
        //     item.Key
        // }
    }

    void UseItemBySlotId(int slotId) {
		if(inventory.ContainsKey(slotId)) {
			inventory[slotId].Pick();
			inventory.Remove(slotId);
		}
    }

    public void Update()
    {
    	// for(int i = 0; i < shortCutKeys.Count; i++) {
    	// 	ShortCutKey shortCutKey = shortCutKeys[i];
    	// 	if (Input.GetKeyDown(shortCutKey.keyCode) || Input.GetKeyDown(shortCutKey.alias))
	    //     {
	    //         Debug.Log("KeyDown: " + shortCutKey.keyCode.ToString());
	    //     }
    	// }
    	foreach(ShortCutKey shortCutKey in shortCutKeys) {
    		if (Input.GetKeyDown(shortCutKey.keyCode) || Input.GetKeyDown(shortCutKey.alias))
	        {
	            Debug.Log("KeyDown: " + shortCutKey.keyCode.ToString());
	            UseItemBySlotId(shortCutKey.index);
	        }
    	}
        
    }

    void OnGUI()
    {
    	for(int i = 0; i < inventoryCount; i++)
    	{
    		Rect rect = new Rect(20 + (SlotWidth + PaddingX) * i, Screen.height - SlotHeight - MarginBottom, SlotWidth, SlotHeight);
    		string text = (i+1).ToString();
    		GUI.Box(rect, text);
    	}
        // int index = 0;
        for(int i = 0; i < inventoryCount; i++)
        {
        	if(inventory.ContainsKey(i)) {
        		GameProps item = inventory[i];
        		Rect rect = new Rect(20 + (SlotWidth + PaddingX) * i, Screen.height - SlotHeight - MarginBottom, SlotWidth, SlotHeight);
	            GUI.Box(rect, item.Name);
	            GUI.DrawTexture(rect, item.Icon, ScaleMode.ScaleToFit);
        	}
        }
        // foreach(var item in inventory)
        // {
        //     Rect rect = new Rect(20 + (SlotWidth + PaddingX) * index, Screen.height - SlotHeight - MarginBottom, SlotWidth, SlotHeight);
        //     GUI.Box(rect, item.Value.Name);
        //      GUI.DrawTexture(rect, item.Value.Icon, ScaleMode.ScaleToFit);
        //     index++;
        // }

    }
}
