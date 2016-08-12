using UnityEngine;

namespace Assets.roguelike2d
{
    [Implements(typeof(IScreenUtil))]
    public class ScreenUtil : IScreenUtil
    {
        [Inject(ConfigElements.GAME_CAMERA)]
        public Camera gameCamers { get; set; }

        public Rect GetScreenRect(float x, float y, float width, float height)
        {
            Debug.Assert((x > 0 && x < 1 && y > 0 && y < 1), "屏幕坐标范围在【0~1】");
            Debug.Assert((width > 0 && width < 1 && height > 0 && height < 1), "Rect范围在【0~1】");
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            return new Rect(x*screenWidth, y*screenHeight, width*screenWidth, height*screenHeight);
        }


    }
}
