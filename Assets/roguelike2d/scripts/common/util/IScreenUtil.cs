
using UnityEngine;

namespace Assets.roguelike2d
{
    public interface IScreenUtil
    {
        //获取屏幕上矩形
        Rect GetScreenRect(float x, float y, float width, float height);
    }
}
