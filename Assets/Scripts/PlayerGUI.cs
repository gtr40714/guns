using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
	private const int SlotWidth = 64, SlotHeight = 64;
	private const int PaddingX = 4, MarginBottom = 12;
	private int inventoryCount = 5;
    private Dictionary<string, GameProps> inventory = new Dictionary<string, GameProps>();
	
    void OnPickProps(string propId) {
        Debug.Log("OnPickProps" + propId.ToString());
        GameProps picked = PropCreator.CreateGunProp();
        picked.Load();
        inventory.Add(picked.Id, picked);
        // int slotId = 0;
        // foreach(var item in inventory)
        // {
        //     item.Key
        // }
    }

    void OnGUI()
    {
    	for(int i = 0; i < inventoryCount; i++)
    	{
    		Rect rect = new Rect(20 + (SlotWidth + PaddingX) * i, Screen.height - SlotHeight - MarginBottom, SlotWidth, SlotHeight);
    		string text = (i+1).ToString();
    		GUI.Box(rect, text);
    	}
        int index = 0;
        foreach(var item in inventory)
        {
            Rect rect = new Rect(20 + (SlotWidth + PaddingX) * index, Screen.height - SlotHeight - MarginBottom, SlotWidth, SlotHeight);
            GUI.Box(rect, item.Value.Name);
             GUI.DrawTexture(rect, item.Value.Icon, ScaleMode.ScaleToFit);
            index++;
        }

    }
}
