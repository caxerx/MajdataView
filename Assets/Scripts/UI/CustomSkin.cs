using UnityEngine;
using System.Threading.Tasks;

public class CustomSkin : MonoBehaviour
{
    SpriteRenderer Outline;

    public Sprite Tap;
    public Sprite Tap_Each;
    public Sprite Tap_Break;
    public Sprite Tap_Ex;

    public Sprite Slide;
    public Sprite Slide_Each;
    public Sprite Slide_Break;
    //public Sprite Wifi;
    //public Sprite Wifi_Each;
    //public Sprite Wifi_Break;

    public Sprite Star;
    public Sprite Star_Double;
    public Sprite Star_Each;
    public Sprite Star_Each_Double;
    public Sprite Star_Break;
    public Sprite Star_Break_Double;
    public Sprite Star_Ex;
    public Sprite Star_Ex_Double;

    public Sprite Hold;
    public Sprite Hold_Each;
    public Sprite Hold_Ex;
    public Sprite Hold_Break;

    public Sprite[] Just = new Sprite[6];

    // Start is called before the first frame update
    async void Start()
    {
        print("CustomSkin Start");
        await LoadTexture();
        print("CustomSkin Loaded");
    }

    async Task LoadTexture()
    {
        var path = "./Skin";
        Outline = gameObject.GetComponent<SpriteRenderer>();
        print(path);
        
        Outline.sprite = await SpriteLoader.LoadSpriteFromUrl(path + "/outline.png");

        Tap = await SpriteLoader.LoadSpriteFromUrl(path + "/tap.png");
        Tap_Each = await SpriteLoader.LoadSpriteFromUrl(path + "/tap_each.png");
        Tap_Break = await SpriteLoader.LoadSpriteFromUrl(path + "/tap_break.png");
        Tap_Ex = await SpriteLoader.LoadSpriteFromUrl(path + "/tap_ex.png");

        Slide = await SpriteLoader.LoadSpriteFromUrl(path + "/slide.png");
        Slide_Each = await SpriteLoader.LoadSpriteFromUrl(path + "/slide_each.png");
        Slide_Break = await SpriteLoader.LoadSpriteFromUrl(path + "/slide_break.png");

        Star = await SpriteLoader.LoadSpriteFromUrl(path + "/star.png");
        Star_Double = await SpriteLoader.LoadSpriteFromUrl(path + "/star_double.png");
        Star_Each = await SpriteLoader.LoadSpriteFromUrl(path + "/star_each.png");
        Star_Each_Double = await SpriteLoader.LoadSpriteFromUrl(path + "/star_each_double.png");
        Star_Break = await SpriteLoader.LoadSpriteFromUrl(path + "/star_break.png");
        Star_Break_Double = await SpriteLoader.LoadSpriteFromUrl(path + "/star_break_double.png");
        Star_Ex = await SpriteLoader.LoadSpriteFromUrl(path + "/star_ex.png");
        Star_Ex_Double = await SpriteLoader.LoadSpriteFromUrl(path + "/star_ex_double.png");

        var border = new Vector4(0, 58, 0, 58);
        Hold = await SpriteLoader.LoadSpriteFromUrl(path + "/hold.png", border);
        Hold_Each = await SpriteLoader.LoadSpriteFromUrl(path + "/hold_each.png", border);
        Hold_Ex = await SpriteLoader.LoadSpriteFromUrl(path + "/hold_ex.png", border);
        Hold_Break = await SpriteLoader.LoadSpriteFromUrl(path + "/hold_break.png", border);

        Just[0] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_curv_r.png");
        Just[1] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_str_r.png");
        Just[2] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_wifi_u.png");
        Just[3] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_curv_l.png");
        Just[4] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_str_l.png");
        Just[5] = await SpriteLoader.LoadSpriteFromUrl(path + "/just_wifi_d.png");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
