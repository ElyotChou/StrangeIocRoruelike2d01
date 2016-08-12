using System;
using System.Collections.Generic;
using strange.framework.api;
using UnityEngine;

namespace Assets.roguelike2d
{
    public class ResourceInstanceProvider:IInstanceProvider
    {
        GameObject prototype;
        private string resourceName;
        private int _layer;
        private int id = 0;

        public ResourceInstanceProvider(string name,int layer)
        {
            resourceName = name;
            _layer = layer;
        }

        #region IInstanceProvider implementation

        public T GetInstance<T>()
        {
            object instance = GetInstance(typeof(T));
            T retv = (T)instance;
            return retv;
        }

        public object GetInstance(Type key)
        {
            if (prototype == null)
            {
                //Get the resource from Unity
                prototype = Resources.Load<GameObject>(resourceName);
                prototype.transform.localScale = Vector3.one;
            }

            //Copy the prototype
            GameObject go = GameObject.Instantiate(prototype) as GameObject;
            go.layer = _layer;
            go.name = resourceName + "_" + id++;

            return go;
        }
        #endregion
    }
}
