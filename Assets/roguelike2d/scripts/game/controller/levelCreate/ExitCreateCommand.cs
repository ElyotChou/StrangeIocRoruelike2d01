using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class ExitCreateCommand:Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        [Inject]
        public IGameConfig gameConfig { get; set; }

        public override void Execute()
        {
            
            //创建出口
            Vector2 pos = new Vector2(gameModel.rows - 1.5f, gameModel.cols - 1.5f);
            GameObject go = GameObject.Instantiate(gameModel.spriteModel, pos, Quaternion.identity) as GameObject;
            go.GetComponent<SpriteRenderer>().sprite = gameConfig.dictSprites["Exit"]; ;
            go.GetComponent<SpriteRenderer>().sortingLayerName = GameLayers.Item.ToString();
            go.AddComponent<ExitView>();
            go.name = "Exit";
            go.transform.SetParent(contextView.transform);
        }
    }
}
