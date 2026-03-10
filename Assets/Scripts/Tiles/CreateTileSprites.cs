#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateTileSprites
{
    [MenuItem("Forge/Create Prototype Sprites")]
    public static void Create()
    {

        if (!Directory.Exists("Assets/Sprites"))
            AssetDatabase.CreateFolder("Assets", "Sprites");

        CreateSprite("MineSprite",    new Color(0.85f, 0.1f, 0.1f));  
        CreateSprite("RefinerSprite", new Color(1f, 1f, 1f));
        CreateSprite("ForgeSprite",   new Color(0.1f, 0.3f, 0.9f));   

        AssetDatabase.Refresh();
        Debug.Log("Forge: Prototype sprites created in Assets/Sprites/");
    }

    static void CreateSprite(string name, Color color)
    {
        Texture2D tex = new Texture2D(64, 64);
        Color[] pixels = new Color[64 * 64];
        for (int i = 0; i < pixels.Length; i++) pixels[i] = color;
        tex.SetPixels(pixels);
        tex.Apply();

        byte[] png  = tex.EncodeToPNG();
        string path = $"Assets/Sprites/{name}.png";
        File.WriteAllBytes(path, png);
    }
}
#endif