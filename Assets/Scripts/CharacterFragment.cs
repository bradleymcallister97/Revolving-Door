using UnityEngine;
using System.Collections;

public class CharacterFragment : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody>().AddExplosionForce(300, Vector3.zero, 200);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
