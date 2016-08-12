using Assets.roguelike2d;
using Assets.roguelike2d.game;
using UnityEngine;
using DG.Tweening;

public class test01 : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    Debug.Log(LayerMask.NameToLayer("Player"));
	}

    void myCallBack()
    {
        Debug.Log("myCallBack");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButton(0))
	    {
	        //Debug.Log("mousebutton");
	        move();
	    }
	    if (Input.GetKeyDown(KeyCode.UpArrow))
	    {
	        Debug.Log("Left button down");
	    }
	}

    void move()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, new Vector2(0, 0),13);
        Debug.DrawLine(transform.position, new Vector2(0, 0), Color.red, 5);
        Debug.Log(hit.collider.tag);
    }
}
