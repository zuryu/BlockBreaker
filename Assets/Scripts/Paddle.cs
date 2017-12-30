using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX;
	public float maxX;
	
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0);
		float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, minX, maxX);
		paddlePos.x = mousePosInBlocks;
		
		this.transform.position = paddlePos;
	}
}
