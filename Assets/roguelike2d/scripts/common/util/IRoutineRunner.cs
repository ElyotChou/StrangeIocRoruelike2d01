
using System.Collections;
using UnityEngine;

namespace Assets.roguelike2d
{
    public interface IRoutineRunner
    {
        Coroutine StartCoroutine(IEnumerator method);
    }
}
