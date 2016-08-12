using System;
using strange.extensions.command.impl;
using DG.Tweening;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class PlayerBehaviourCommand:Command
    {
        [Inject]
        public int gameInputEvent { get; set; }
        [Inject]
        public IGameConfig gameConfig { get; set; }
        [Inject]
        public PlayerView playerView { get; set; }
        public override void Execute()
        {
            Rigidbody2D rig2d = playerView.GetComponent<Rigidbody2D>();
            TestAssert.That(rig2d != null, "PlayerBehaviourCommand Execute::: rig2d is null");

            Vector2 playerPos = playerView.transform.position;
            RaycastHit2D hit = Physics2D.Linecast(playerPos, playerPos + ray(),LayerMask.NameToLayer("Player"));
            Debug.DrawLine(playerPos, playerPos + ray(), Color.red, 5);
            
            if (!playerView.IsAction)
            {
                if (hit.transform == null)
                {
                    playerMove(playerPos);
                }
                else
                {
                    playerAction(hit, playerPos);
                }
                
            }
        }

        private void playerFlip()
        {
            Vector2 playerScale = playerView.transform.localScale;
            playerScale.x *= -1;
            playerView.transform.localScale = playerScale;
            playerView.Facing *= -1;
        }

        private void playerAction(RaycastHit2D hit, Vector2 playerPos)
        {
            switch (hit.collider.tag)
            {
                case "OutWall":
                    //TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute OutWall");
                    break;
                case "Wall":
                    playerView.GetComponent<Animator>().SetTrigger("Attack");
                    TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute Wall");
                    break;
                case "Food":
                    GameObject.Destroy(hit.collider.gameObject);
                    playerMove(playerPos);
                    TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute Food");
                    break;
                case "Soda":
                    GameObject.Destroy(hit.collider.gameObject);
                    playerMove(playerPos);
                    TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute Soda");
                    break;
                case "Enemy":
                    playerView.GetComponent<Animator>().SetTrigger("Attack");
                    //TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute Enemy");
                    break;
                default:
                    //TestLoadConfig.log.Trace("PlayerBehaviourCommand Execute default");
                    break;
            }
        }

        private void playerMove(Vector2 playerPos)
        {
            playerView.IsAction = true;
            playerView.GetComponent<Rigidbody2D>().transform.DOMove(playerPos + ray(), gameConfig.smoothing)
                .SetEase(Ease.OutQuad)
                .OnComplete(isMovingHandle);
        }

        private void isMovingHandle()
        {
            playerView.IsAction = false;
        }

        private Vector2 ray()
        {
            int h = 0, v = 0;
            switch (gameInputEvent)
            {
                case GameInputEvent.MOVE_LEFT:
                    h = -1;
                    if (h != playerView.Facing) playerFlip();
                    break;
                case GameInputEvent.MOVE_RIGHT:
                    h = 1;
                    if (h != playerView.Facing) playerFlip();
                    break;
                case GameInputEvent.MOVE_UP:
                    v = 1;
                    break;
                case GameInputEvent.MOVE_DOWN:
                    v = -1;
                    break;
            }
            return new Vector2(h,v);
        }
    }

}
