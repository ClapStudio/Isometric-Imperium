using UnityEngine;

public interface IItem {
    string name { get; set; }
    int id { get; set; }
    string desc { get; set; }
    Texture2D icon { get; set; }
    ItemType type { get; set; }
    bool stackable { get; set; }
}