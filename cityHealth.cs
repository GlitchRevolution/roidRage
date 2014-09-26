public int health;
public GameObject cityMax; //Full Health City
public GameObject cityHurt; //City indicating that there are two hits left
public GameObject cityDestroyed; //Destroyed city, one Healthpoint from defeat

void Awake(){
cityMax = transform.FindChild("CityMax").gameObject; //Find the city skylines
cityHurt = transform.FindChild("CityHurt").gameObject;
cityDestroyed = transform.FindChild("CityDestroyed").gameObject;
cityHurt.SetActive = false; //Disable the unused skylines
cityDestroyed.SetActive = false;
}

void OnTriggerEnter(Collider other){
  
  if (other.tag == "Rock") {
  health -= 1; //If the ground is hit by a rock, damage city
  }
  
  if (health <= 0) {
  GameController.GameController.GameOver(); //If health is 0 or less, start GameOver sequence
  }
  
  //Enable/Disable certain city skylines based on health points
  if (health > 2) {
  cityMax.SetActive = true;
  cityHurt.SetActive = false;
  cityDestroyed.SetActive = false;
  }
  if (health == 2) {
  cityMax.SetActive = false;
  cityHurt.SetActive = true;
  cityDestroyed.SetActive = false;
  }
  if (health == 1) {
  cityMax.SetActive = false;
  cityHurt.SetActive = false;
  cityDestroyed.SetActive = true;
  }
  
}


// NEW ADDITIONS
// Add the following code to OnTriggerEnter for Rock
// cameraShakeCounter = cameraShakeAmount;
// ScreenWipe();

public Camera gameCamera; // variable to identify the Camera
public Vector3 gameCameraLocation;
public int cameraShakeAmount;
private int cameraShakeCounter;
public GameObject impactExplosion;

void Awake(){
  gameCameraLocation = gameCamera.transform.position;
}

// REPLACEMENT
if (other.tag == "Rock") {
  health -= 1; //If the ground is hit by a rock, damage city
  Instantiate (impactExplosion, other.gameObject.transform);
  Destroy(other.gameObject);
  }

void ScreenWipe(){
  if (cameraShakeCounter > 0) {
  gameCamera.Translate(Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f),0);  
  cameraShakeCounter -= 1;
  Invoke ("ScreenWipe",.1f);
  }
  if (cameraShakeCounter == 0){
    gameCamera.Translate(gameCameraLocation * Time.deltaTime);
  }
}

