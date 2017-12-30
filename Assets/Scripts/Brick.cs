using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;

	public AudioClip crack;
	public int maxHits;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionExit2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.25f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			GameObject smokePuff = Object.Instantiate(smoke, gameObject.transform.position, smoke.transform.rotation) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;; 
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
}
