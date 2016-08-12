using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.pool.api;
using UnityEngine;


/***
 * 创建怪物
 * 
 * 
 */


namespace Assets.roguelike2d.game
{
    public class EnemyCreateCommand:Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        [Inject(GameElement.ENEMY)]
        public IPool<GameObject> pool { get; set; }
        public override void Execute()
        {
            GameObject holder = new GameObject("enemy");
            holder.transform.SetParent(contextView.transform);
            GameObject enemyGo = pool.GetInstance();


            //创建敌人level/2
            int enemyCount = gameModel.level * 2;
            InstantiateItems(enemyCount, enemyGo, holder);

            GameObject.Destroy(enemyGo);
        }

        private void InstantiateItems(
            int count, GameObject enemy, GameObject holder)
        {
            RuntimeAnimatorController[] controller = new RuntimeAnimatorController[2];
            for (int j = 1; j <= 2; j++)
            {

                string address = "animation/controller/Enemy0" + j;
                controller[j - 1] = Resources.Load<RuntimeAnimatorController>(address);
            }
            for (int i = 0; i < count; i++)
            {
                Vector2 pos = RandomPosition();
                GameObject go = GameObject.Instantiate(enemy, pos, Quaternion.identity) as GameObject;
                go.GetComponent<SpriteRenderer>().sortingLayerName = GameLayers.Role.ToString();
                go.AddComponent<Animator>();
                go.AddComponent<BoxCollider2D>();
                go.GetComponent<Animator>().runtimeAnimatorController = controller[Random.Range(0,2)];
                go.transform.SetParent(holder.transform);
                go.tag = GameTags.Enemy.ToString();
            }
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
