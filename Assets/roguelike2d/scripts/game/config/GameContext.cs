using System.Collections.Generic;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class GameContext:SignalContext
    {
        public GameContext(MonoBehaviour contextView) : base(contextView)
        {
        }
        public override strange.extensions.context.api.IContext Start()
        {
            Debug.logger.logEnabled = true;
            TestLoadConfig.log.Trace("GameContext Start");
            return base.Start();
        }

        protected override void mapBindings()
        {
            base.mapBindings();

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
#else
            injectionBinder.Bind<IInput>().To<KeyboardInput>().ToSingleton();
#endif
            //pool
            injectionBinder.Bind<IGameConfig>().To<GameConfig>().ToSingleton();
            injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.SPRITE_MODEL_POOL);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.ENEMY);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.PLAYER);

            //signals
            injectionBinder.Bind<StartSignal>().ToSingleton();
            injectionBinder.Bind<GameStartSignal>().ToSingleton();
            injectionBinder.Bind<LevelStartSignal>().ToSingleton();
            injectionBinder.Bind<GameInputSignal>().ToSingleton();
            injectionBinder.Bind<PlayerBehaviourSignal>().ToSingleton();

            //Commands
            commandBinder.Bind<StartSignal>().To<GameIndependentStartCommand>().Once();
            commandBinder.Bind<GameStartSignal>().To<GameStartCommand>();
            commandBinder.Bind<PlayerBehaviourSignal>().To<PlayerBehaviourCommand>();
            commandBinder.Bind<LevelStartSignal>()
                .To<GameBoardCteateCommand>()
                .To<ItemCreateCommand>()
                .To<EnemyCreateCommand>()
                .To<ExitCreateCommand>()
                .To <PlayerCreateCommand>()
                .InSequence();

            //mediator
            mediationBinder.Bind<GameDebugView>().To<GameDebugMediator>();
            mediationBinder.Bind<BoardView>().To<BoardMediator>();
            mediationBinder.Bind<ObstacleView>().To<ObstacleMediator>();
            mediationBinder.Bind<FoodView>().To<FoodMediator>();
            mediationBinder.Bind<EnemyView>().To<EnemyMediator>();
            mediationBinder.Bind<ExitView>().To<ExitMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerMediator>();



            mediationBinder.Bind<TestView>().To<TestMediator>();
            TestLoadConfig.log.Trace("GameContext mapBindings");
        }

        protected override void postBindings()
        {
            Camera cam = (contextView as GameObject).GetComponentInChildren<Camera>();
            Debug.Assert(cam != null, "GameContext没有发现游戏camera");
            injectionBinder.Bind<Camera>().ToValue(cam).ToName(ConfigElements.GAME_CAMERA);
            TestLoadConfig.log.Trace("GameContext postBindings");

            IPool<GameObject> spriteModelPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.SPRITE_MODEL_POOL);
            spriteModelPool.instanceProvider = new ResourceInstanceProvider("EmptySpriteModel", LayerMask.NameToLayer("Default"));
            spriteModelPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> enemyPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.ENEMY);
            enemyPool.instanceProvider = new ResourceInstanceProvider("Enemy", LayerMask.NameToLayer("Default"));
            enemyPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> playerPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.PLAYER);
            playerPool.instanceProvider = new ResourceInstanceProvider("Player", LayerMask.NameToLayer("Default"));
            playerPool.inflationType = PoolInflationType.INCREMENT;
            base.postBindings();
        }

        public override void Launch()
        {
            base.Launch();
            TestLoadConfig.log.Trace("GameContext Launch");
        }

    }
}
