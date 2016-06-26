using UnityEngine;

public interface IItem {
    string name { get; set; }
    int id { get; set; }
    string desc { get; set; }
    Sprite icon { get; set; }
    ItemType type { get; set; }
    bool stackable { get; set; }
}