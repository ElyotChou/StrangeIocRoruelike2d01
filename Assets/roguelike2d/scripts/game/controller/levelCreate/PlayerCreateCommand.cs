using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.pool.api;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class PlayerCreateCommand:Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }
        [Inject(GameElement.PLAYER)]
        public IPool<GameObject> pool { get; set; }
        public override void Execute()
        {
            GameObject playerGo = pool.GetInstance();
            RuntimeAnimatorController contoller = Resources.Load<RuntimeAnimatorController>("animation/controller/Player_01");
            Vector2 pos = new Vector2(1.5f, 1.5f);
            GameObject go = GameObject.Instantiate(playerGo, pos, Quaternion.identity) as GameObject;
            go.AddComponent<Animator>();
            go.AddComponent<Rigidbody2D>();
            go.AddComponent<BoxCollider2D>();
            go.GetComponent<SpriteRenderer>().sortingLayerName = GameLayers.Role.ToString();
            go.GetComponent<Animator>().runtimeAnimatorController = contoller;
            go.GetComponent<Rigidbody2D>().isKinematic = true;
            go.name = "Player";
            go.layer = LayerMask.NameToLayer("Player");
            go.transform.SetParent(contextView.transform);
            GameObject.Destroy(playerGo);
        }
    }
}
