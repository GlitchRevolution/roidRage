
public float rotationSpeed; //How fast does it rotate?
public int hitPoints; //How many taps does it take to destroy?
private Quaternion explosionRotation = new Vector3(0,0,0);
private GameObject explosion;
private AudioClip explosionSound;
public GameObject breakRock;
private int randomRoll;
public bool isBreakable = false;

void Awake() {
  rigidbody.angularVelocity = Random.insideUnitSphere * rotationSpeed; //Set random rotation as it falls
  randomRoll = Random.Range(0-5);

  if (randomRoll == 0) {
  explosion = GameController.GameController.explosion1;
  explosionSound = GameController.GameController.sound1;
  }
  if (randomRoll == 1) {
  explosion = GameController.GameController.explosion2;
  explosionSound = GameController.GameController.sound2;
  }
  if (randomRoll == 2) {
  explosion = GameController.GameController.explosion3;
  explosionSound = GameController.GameController.sound3;
  }
  if (randomRoll == 3) {
  explosion = GameController.GameController.explosion4;
  explosionSound = GameController.GameController.sound4;
  }
  if (randomRoll == 4) {
  explosion = GameController.GameController.explosion5;
  explosionSound = GameController.GameController.sound5;
  }
  if (randomRoll == 5) {
  explosion = GameController.GameController.explosion6;
  explosionSound = GameController.GameController.sound6;
  }
}


void OnMouseDown(){
  hitPoints -=1; //Hit against rock
  if (hitPoints == 0) {
  RockDestroy(); //Start score keeping and explosion process
  }
}

void OnTriggerEnter(Collider other){
  if (other.tag == "Laser" || other.tag == "Shield")
        {
            RockDestroy();
        }
}

void RockDestroy(){
  if (isBreakable == false) {
  GameController.GameController.AddScore(); //Add to score, yay
  Instantiate(explosion, transform.position, explosionRotation);
  AudioSource.PlayClipAtPoint(explosionSound, transform.position);
  Destroy(gameObject);
  }
  if (isBreakable == true){
    Instantiate(explosion, transform.position, explosionRotation);
    AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    Instantiate(breakRock,transform.position,explosionRotation);
    Destroy(gameObject);
  }
}
