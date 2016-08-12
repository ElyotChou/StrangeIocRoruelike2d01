using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Animations;
using AnimatorController = UnityEditor.Animations.AnimatorController;
using AnimatorControllerLayer = UnityEditor.Animations.AnimatorControllerLayer;


public class test : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{

	    AnimatorController controller =
	        AnimatorController.CreateAnimatorControllerAtPath("Assets/resources/animation/controller/Enemy01.controller");
	    Animator ownAnimator = gameObject.AddComponent<Animator>();
	    ownAnimator.runtimeAnimatorController = controller;
	}

	
	// Update is called once per frame
	void Update () {
	}

    void test01()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Scavengers_SpriteSheet");
        foreach (Sprite sprite in sprites)
        {
            dictSprites.Add(sprite.name, sprite);
        }
        //===================================================================
        RuntimeAnimatorController aniControl = Resources.Load<RuntimeAnimatorController>("animation/Player_01");
        AnimationClip aniClip_Idle = Resources.Load<AnimationClip>("animation/playerClip");
        TestAssert.That(aniControl != null, lev.Error, "aniControl is null");
        TestAssert.That(aniClip_Idle != null, lev.Error, "aniClip_Idle is null");

        GameObject go = new GameObject("palyer");
        go.AddComponent<SpriteRenderer>();
        go.GetComponent<SpriteRenderer>().sprite = dictSprites["Player_01"];
        go.AddComponent<Animator>();
        go.GetComponent<Animator>().runtimeAnimatorController = aniControl;
    }

    void test02()
    {
        AnimatorController controller =
            AnimatorController.CreateAnimatorControllerAtPath("Assets/animation.controller");
        // Add parameters
        //controller.AddLayer("hahaha");
        AnimatorState mstate = new AnimatorState();
        mstate.name = "myState";
        Motion mmotion = Resources.Load<AnimationClip>("animation/playerClip") as Motion;
        mmotion.name = "myMotion";
        AnimatorControllerLayer myLayer = new AnimatorControllerLayer();
        myLayer.name = "hahaha";
        //myLayer.SetOverrideBehaviours(mstate,;
        myLayer.SetOverrideMotion(mstate, mmotion);
        controller.AddLayer(myLayer);
    }
}

