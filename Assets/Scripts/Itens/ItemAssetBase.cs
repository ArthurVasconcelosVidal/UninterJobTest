using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemAsset", order = 1)]
public class ItemAssetBase : ScriptableObject{
    [SerializeField] ItemType itemType;
    [SerializeField] int itemID;

    public ItemType ItemType { get => itemType; }
    public int ItemID { get => itemID; }
}
