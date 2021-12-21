using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private float moveInput;
	private Rigidbody2D rb;
	private bool facingRight = true;
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private float inputVertical;
	public float distance;
	public LayerMask whatIsLadder;
	private bool isClimbing;
	private int extraJumps;
	public int extraJumpsValue;
	public float gravityValue;
	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping;
	private float timeBtwShots;
	public float startTimeBtwShots;
	public GameObject[] projectile;
	public double DeathPosY;
	public Transform[] checkPoints;
	public bool TryAgain = false;
	public Transform StartFlag;
	private int NumStartElevating = 6;
	public float returnDistance;
	private int SavedCheckedPoint = -1;
	
	DataToPreserve playerData;
	Scene_1_Manager scene_1;


    // Start is called before the first frame update
	void Awake(){
		playerData = FindObjectOfType<DataToPreserve>();
		playerData.resetLives();
		scene_1 = FindObjectOfType<Scene_1_Manager>();
	}
    void Start()
    {
		extraJumps = extraJumpsValue;
       	rb = GetComponent<Rigidbody2D>(); 
	  	timeBtwShots = 0;
		transform.position = StartFlag.position;
		// transform.position = checkPoints[3].position; // this line of code is for test
    }
	
    // Update is called once per frame
	
    void Update()
    {
		//player jumping && double+ jumps
		if(isGrounded == true){
			extraJumps = extraJumpsValue;
		}

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
			isJumping = true;
			jumpTimeCounter = jumpTime;
			extraJumps--;
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
			isJumping = true;
			jumpTimeCounter = jumpTime;
		}

		if(Input.GetKey(KeyCode.UpArrow) && isJumping == true){
			if(jumpTimeCounter > 0){
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
			else{
				isJumping = false;
			}
		}

		if(Input.GetKeyUp(KeyCode.UpArrow)){
			isJumping = false;
		}
		//shooting
		if(timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.Z)){
			Instantiate(projectile[0], transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
			//Debug.Log("Now a bullet is being shoot");
		}
		else if(timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.X)){
			Instantiate(projectile[1], transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
		}
		else if(timeBtwShots <= 0 && Input.GetKeyDown(KeyCode.C)){
			Instantiate(projectile[2], transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
		}
		else{
			timeBtwShots -= Time.deltaTime;
		}
		//to save the check points
		for(int i = 6; i >= 0; i--){
			if(transform.position.x >= checkPoints[i].position.x && SavedCheckedPoint < i){
				SavedCheckedPoint = i;
			}
		}
		for(int i = checkPoints.Length - 1; i >= 7 ; i--){
			if(Vector2.Distance(checkPoints[i].transform.position, transform.position) <= returnDistance && SavedCheckedPoint < i){
				SavedCheckedPoint = i;
				//Debug.Log(SavedCheckedPoint);
			}
		}
    }
	
	void FixedUpdate(){
		//player movement
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
		
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		//player flipping
		if(facingRight == false && moveInput > 0){
			Flip();
		}
		else if(facingRight == true && moveInput < 0){
			Flip();
		}

		//climbing ladder
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

		if(hitInfo.collider != null){
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				isClimbing = true;
			}
		}
		else{
			if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
				isClimbing = false;
			}
		}
		if(isClimbing == true && hitInfo.collider != null){
			inputVertical = Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
			rb.gravityScale = 0;
		}
		else{
			rb.gravityScale = gravityValue;
		}

		//death judgement
		fallingDeath(transform.position.y);
		if(TryAgain){
			if(SceneManager.GetActiveScene().name == "Scene1"){
				scene_1.resetEnemy();
				scene_1.resetBrick();
			}
			TryAgain = false;
		}
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	void fallingDeath(double playerPosition){
		if(playerPosition < DeathPosY){
			MinusLives();
		}
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy"){
			MinusLives();
		}
		else if(other.gameObject.tag == "MovingPlatform"){
			this.transform.parent = other.transform;
		}
	}
	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "MovingPlatform"){
			this.transform.parent = null;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "woodhorse(Clone)"){
			MinusLives();
		}
		else if(other.gameObject.name == "wormvirus(Clone)"){
			MinusLives();
		}
		else if(other.gameObject.name == "password(Clone)"){
			MinusLives();
		}
	}
	private void MinusLives(){
		playerData.PlayerRemainingLives --;
		Debug.Log("Lives remaining:" + playerData.PlayerRemainingLives);
		if(playerData.PlayerRemainingLives != 0){
			ResetPosition();
			TryAgain = true;
		}
		else if(playerData.PlayerRemainingLives < 0){
			playerData.PlayerRemainingLives = 0;
		}
	}
	private void ResetPosition(){
		if(SavedCheckedPoint != -1){
			transform.position = checkPoints[SavedCheckedPoint].position;
			scene_1.resetDos();
			return;
		}
		transform.position = StartFlag.position;
	}
	public bool IsFacingRight(){
		return facingRight;
	}
	
}
