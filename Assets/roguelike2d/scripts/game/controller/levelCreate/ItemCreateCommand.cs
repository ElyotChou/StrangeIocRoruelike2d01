using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using Random = UnityEngine.Random;

/***
 * 创建地图上障碍物
 * 
 * 
 */


namespace Assets.roguelike2d.game
{
    public class ItemCreateCommand:Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        [Inject]
        public IGameConfig gameConfig { get; set; }

        public Dictionary<string, Sprite> dictSprites;
        public override void Execute()
        {
            int minCountWall = gameModel.minCountWall;
            int maxCountWall = gameModel.maxCountWall;
            TestAssert.That(maxCountWall != 0, lev.Error, "ItemCreateCommand Execute::gameModel未重置");

            GameObject holder = new GameObject("item");
            holder.transform.SetParent(contextView.transform);

            dictSprites = gameConfig.dictSprites;
            List<string> listObstacles = new List<string>();
            List<string> listFoods = new List<string>();
            

            foreach (string name in dictSprites.Keys)
            {
                if (name.StartsWith("ObstacleG")) listObstacles.Add(name);
                if (name.StartsWith("Food")) listFoods.Add(name);
            }
            //创建障碍物
            int wallCount = Random.Range(minCountWall, maxCountWall + 1);//障碍物个数
            InstantiateItems<ObstacleView>(wallCount, listObstacles, holder);
            //创建食物2-level*2
            int foodCount = Random.Range(2, gameModel.level * 2 + 1);
            InstantiateItems<FoodView>(foodCount, listFoods, holder);
            
        }

        private void InstantiateItems<T>(
            int count, List<string> spriteKey, GameObject holder) where T : Component
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 pos = RandomPosition();
                GameObject go = GameObject.Instantiate(gameModel.spriteModel, pos, Quaternion.identity) as GameObject;
                go.GetComponent<SpriteRenderer>().sprite = RandomSprite(spriteKey); ;
                go.GetComponent<SpriteRenderer>().sortingLayerName = GameLayers.Item.ToString();
                addTag(go,go.GetComponent<SpriteRenderer>().sprite.name);
                go.AddComponent<T>();
                go.AddComponent<BoxCollider2D>();
                go.transform.SetParent(holder.transform);
            }
        }

        private void addTag(GameObject go, string spriteName)
        {
            if (spriteName.StartsWith("ObstacleG")) go.tag = GameTags.Wall.ToString();
            if (spriteName.StartsWith("Food_01")) go.tag = GameTags.Food.ToString();
            if (spriteName.StartsWith("Food_02")) go.tag = GameTags.Soda.ToString();
        }

        private Sprite RandomSprite(List<string> spriteKey)
        {
            int index = Random.Range(0, spriteKey.Count);
            return dictSprites[spriteKey[index]];
        }

        private Vector2 RandomPosition()
        {
            int positionIndex = Random.Range(0, gameModel.listPosition.Count);
            Vector2 pos = gameModel.listPosition[positionIndex];
            gameModel.listPosition.RemoveAt(positionIndex);
            return pos;
        }

        
    }


}
