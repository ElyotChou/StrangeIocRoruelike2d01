using System;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEditor;
using UnityEngine;
/***
 * 创建依赖项
 * 测试操作可以在临时的测试视图完成
 * 
 * 
 */
namespace Assets.roguelike2d.game
{
    public class GameIndependentStartCommand:Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        //这只是实例化游戏输入注入
        [Inject]	
        public IInput input { get; set; }

        public override void Execute()
        {
            GameObject gameObj = new GameObject("debug_view");
            gameObj.AddComponent<GameDebugView>();
            gameObj.transform.SetParent(contextView.transform);
            TestLoadConfig.log.Trace("游戏依赖项加载");
        }

       
    }
}
