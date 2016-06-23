using UnityEngine;
using System.Collections;

public interface IItemData {
    Item item { get; set; }
    int amount { get; set; }    
}
