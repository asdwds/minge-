using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider co)
    {
        Debug.Log("Enter");
    }

    void OnTriggerStay(Collider co)
    {
        Debug.Log("Stay");
    }

}
