
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;
/***
 * 开始游戏
 * gameModel重置
 * 摄像机移到视图中央
 * 初始化sprite模型
 */
namespace Assets.roguelike2d.game
{
    public class GameStartCommand:Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject(ConfigElements.GAME_CAMERA)]
        public Camera cam { get; set; }
        [Inject(GameElement.SPRITE_MODEL_POOL)]
        public IPool<GameObject> pool { get; set; }
        public override void Execute()
        {
            gameModel.Reset();
            cam.transform.position = new Vector3(5, 5,-10);
            gameModel.spriteModel = pool.GetInstance();
            TestLoadConfig.log.Trace("游戏Model初始化");
        }
    }
}
