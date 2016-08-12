using System.Collections.Generic;
using UnityEngine;

namespace Assets.roguelike2d
{
    public interface IGameConfig
    {
        //所有精灵的atlas
        Dictionary<string, Sprite> dictSprites { get; }
        //移动顺滑度
        float smoothing{get;}
    }
}
