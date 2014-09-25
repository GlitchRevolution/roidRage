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
