using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Threading.Tasks;

public static class SpriteLoader 
{
    public async static Task<Texture2D> LoadTextureAsync(string path)
    {
        var request = UnityWebRequest.Get(path);
        await request.SendWebRequest();
        var bytes = request.downloadHandler.data;
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(bytes);
        return texture;
    }

    public async static Task<Sprite> LoadSpriteFromUrl(string path)
    {
        var texture = await LoadTextureAsync(path);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public async static Task<Sprite> LoadSpriteFromUrl(string path, Vector4 border)
    {
        var texture = await LoadTextureAsync(path);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100, 1, SpriteMeshType.FullRect, border);
    }

    public static Sprite LoadSpriteFromFile(string path)
    {
        if (!File.Exists(path)) return Sprite.Create(new Texture2D(0, 0), new Rect(0, 0, 0, 0), new Vector2(0.5f, 0.5f));
        var bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(bytes);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
    public static Sprite LoadSpriteFromFile(string path,Vector4 border)
    {
        if (!File.Exists(path)) return Sprite.Create(new Texture2D(0, 0), new Rect(0, 0, 0, 0), new Vector2(0.5f, 0.5f));
        var bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(bytes);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),100,1,SpriteMeshType.FullRect,border);

    }
}
