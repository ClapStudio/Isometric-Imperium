using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item : IItem {
    [SerializeField]
    string _name;
    [SerializeField]
    int _id;
    [SerializeField]
    string _desc;
    [SerializeField]
    Texture2D _icon;
    [SerializeField]
    ItemType _type;
    [SerializeField]
    bool _stackable;


    //Getters Setters
    public string name {
        get { return _name; }
        set { _name = value; }
    }
    public int id {
        get { return _id; }
        set { _id = value; }
    }
    public string desc {
        get { return _desc; }
        set { _desc = value; }
    }
    public Texture2D icon {
        get { return _icon; }
        set { _icon = value; }
    }
    public ItemType type {
        get { return _type; }
        set { _type = value; }
    }
    public bool stackable {
        get { return _stackable; }
        set { _stackable = value; }
    }
    public override bool Equals(object obj) {
        //return base.Equals(obj);
        Item item = obj as Item;
        return item.id == id;
    }
    public override int GetHashCode() {
        return id;
    }
}
