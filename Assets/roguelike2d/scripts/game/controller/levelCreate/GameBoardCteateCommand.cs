using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.pool.api;
using UnityEngine;
/***
 * 创建背景地图
 * 
 * 
 */

namespace Assets.roguelike2d.game
{
    public class GameBoardCteateCommand:Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        
        [Inject]
        public IGameConfig gameConfig { get; set; }

        public override void Execute()
        {
            int rows = gameModel.rows;
            int cols = gameModel.cols;
            TestAssert.That(rows != 0, lev.Error, "GameBoardCteateCommand Execute::gameModel未重置");
            GameObject board = new GameObject("board");
            board.transform.SetParent(contextView.transform);

            Dictionary<string, Sprite> dictSprites = gameConfig.dictSprites;
            List<string> listFloors=new List<string>();
            List<string> listOutWall = new List<string>();

            foreach (string name in dictSprites.Keys)
            {
                if (name.StartsWith("Floor")) listFloors.Add(name);
                if (name.StartsWith("OutWall")) listOutWall.Add(name);
            }

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    GameObject go =
                        GameObject.Instantiate(gameModel.spriteModel, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity) as GameObject;
                    if (x == 0 || y == 0 || x == cols - 1 || y == rows - 1)
                    {
                        int index = Random.Range(0, listOutWall.Count);
                        go.GetComponent<SpriteRenderer>().sprite = dictSprites[listOutWall[index]];
                        go.AddComponent<BoxCollider2D>();
                        go.GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 0.9f);
                        go.tag = GameTags.OutWall.ToString();
                    }
                    else
                    {
                        int index = Random.Range(0, listFloors.Count);
                        go.GetComponent<SpriteRenderer>().sprite = dictSprites[listFloors[index]];
                    }
                    go.AddComponent<BoardView>();
                    go.GetComponent<SpriteRenderer>().sortingLayerName = GameLayers.BackGround.ToString();
                    go.transform.SetParent(board.transform);
                }
            }

        }


    }
}
