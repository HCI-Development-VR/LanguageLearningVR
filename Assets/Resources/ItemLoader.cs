using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemLoader : MonoBehaviour {

	public int current;

	public const string path = "items";

	ItemContainer ic;
	// Use this for initialization
	void Start () {

		current = 0;

		ic = ItemContainer.Load (path);

		foreach (Item item in ic.items) {
			print (item.stage);
		}
	}

	public ItemContainer getContainer(){
		return ic;
	}
}