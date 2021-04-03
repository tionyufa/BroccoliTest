using System;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;


[System.Serializable]
public class JsonSprites
{
    public string Id;
    public string Type;
    public float X;
    public float Y;
    public float Width;
    public float Height;

}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.List;
    }

    public static string ToJson<T>(T[] array, bool isTrue)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.List = array;
        return JsonUtility.ToJson(wrapper, isTrue);
    }
    [Serializable]
    private class Wrapper<T>
    {
        public T[] List;
    }
}
public class LoadMap : MonoBehaviour
{
    private readonly string _pathJson = "Assets/Resources/Json/testing.json";
    private string _json;
    private JsonSprites[] _listsJson;
    
    [SerializeField] private List<Texture2D> _textures;
    [SerializeField] private SpriteRenderer _prefab;
    
    private void Awake()
    {
        Load();
    }

    private void Start()
    {
        CreateSprite();
    }

    public void Load()
    {
        _json = File.ReadAllText(_pathJson);
        _listsJson = JsonHelper.FromJson<JsonSprites>(_json);
    }

    private void CreateSprite()
    {
        for (int i = 0; i < _listsJson.Length; i++)
        {
            if (_textures[i].name == _listsJson[i].Id)
            {
                var newSprite = Sprite.Create(_textures[i], new Rect(0f, 0f,_listsJson[i].Width * 100f,_listsJson[i].Height * 100f ), 
                    new Vector2(0f,0f));
                var spriteRenderer = Instantiate(_prefab,new Vector3(_listsJson[i].X , _listsJson[i].Y,0f),quaternion.identity);
                spriteRenderer.name = _listsJson[i].Id;
                spriteRenderer.sprite = newSprite;
                
            }        
            
        }
    }
   
    
}
