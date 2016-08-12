using System.Collections.Generic;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public interface IGameModel
    {

        //关卡重置需要更新的数据
        void Reset();

        //关卡
        int level { get; set; }
        //背景地图的行列
        int rows { get; }
        int cols { get; }
        //关卡障碍物的最大最小值
        int minCountWall { get; }
        int maxCountWall { get; }
        //坐标集合
        List<Vector2> listPosition { get; set; }
        GameObject spriteModel { get; set; }
    }
}
