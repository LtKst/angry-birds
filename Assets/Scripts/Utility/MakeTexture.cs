using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class MakeTexture : MonoBehaviour {

    public static Texture2D MakeTex(int width, int height, Color col) {
        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; ++i) {
            pixels[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }
}