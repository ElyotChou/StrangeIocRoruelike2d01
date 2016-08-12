using System.Collections;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Assets.roguelike2d.game
{
    public class KeyboardInput:IInput
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }
        [Inject]
        public IRoutineRunner routinerunner { get; set; }
        [Inject]
        public GameInputSignal gameInputSignal { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            TestLoadConfig.log.Trace("KeyboardInput PostConstruct");
            routinerunner.StartCoroutine(update());
        }

        protected IEnumerator update()
        {
            while (true)
            {
                int input=GameInputEvent.NONE;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    input |= GameInputEvent.MOVE_LEFT;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    input |= GameInputEvent.MOVE_RIGHT;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    input |= GameInputEvent.MOVE_UP;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    input |= GameInputEvent.MOVE_DOWN;
                }
                gameInputSignal.Dispatch(input);
                yield return null;
            }
        }
    }
}
