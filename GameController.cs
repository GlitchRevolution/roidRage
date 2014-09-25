public static GameController;
public int score;
public int time;
private float timeCounter;

// Storage for the explosion particle effects and associated sounds
public explosion1;
public sound1;
public explosion2;
public sound2;
public explosion3;
public sound3;
public explosion4;
public sound4;
public explosion5;
public sound5;
public explosion6;
public sound6;

// Power up variable storage
public float powerUpCountdown = 0;
private float powerUpTimer;
public bool slowTime;
public bool laserDefense;
public bool shield;
public bool multiplier;

public GameObject laserBlast;
public Vector3 laserBlastSpawn;

public GameObject shieldObject;
public Vector3 shieldObjectSpawn;

public float scoreMultiplier;
private float scoreMultiplierAction;

void Awake() {
powerUpTimer = 0;
scoreMultiplierAction = 1;
}

public void AddScore(){
  score += 1 * scoreMultiplierAction;
}


void FixedUpdate() {
timeCounter = Time.deltaTime;
time = (int)timeCounter; // See how long they last in seconds
}

void Update() {
  Debug.Log(score); // What's the score
}

public void GameOver(){
  // Put GameoverStuff here
}


// POWER UPS
public void SlowTime(){
  powerUpTimer = powerUpCountdown; // Set timer to variable established in inspector
  if (powerUpTimer > 0 && slowTime == true){
  Time.timeScale= 0.5f; // Half speed
  powerUpTimer -= Time.deltaTime; // Subtract timer by actual time
  SlowTime(); // Repeat process so long as timer still has juice and bool is correct
  } else if (powerUpTimer <= 0 && slowTime == true) {
    slowTime = false; // Reset bool
    powerUpTimer = 0; // Reset timer
    ResetPowerUp(); // Reset EVERYTHING
  }
}
  
public void LaserDefense(){
  private Quaternion laserAngle;
    powerUpTimer = powerUpCountdown; // Set timer to variable established in inspector
    if (powerUpTimer > 0 && laserDefense == true){
    laserAngle = new Quaternion(0, 0, Random.Range(0,180),0); // Roll for a random direction for the laser to fire in
    Instantiate(laserBlast,laserBlastSpawn,laserAngle); // Spawn a random laser going a random direction
    powerUpTimer -= Time.deltaTime; // Subtract timer by actual time
    Invoke("LaserDefense",1);  // Repeat process with cool down
    } else if (powerUpTimer <= 0 && laserDefense == true){
    laserDefense = false; // Reset bool
    powerUpTimer = 0; // Reset timer
    ResetPowerUp(); // Reset EVERYTHING
    }
    
}

public void Shield(){
    powerUpTimer = powerUpCountdown; // Set timer to variable established in inspector
    private bool shieldSpawned;
    if (powerUpTimer > 0 && shield == true){
      if (shieldSpawned == false){
        Instantiate(shieldObject,shieldObjectSpawn,Quaternion.identity); // Spawn the shield
        shieldSpawned = true;
      }
    powerUpTimer -= Time.deltaTime; // Subtract timer by actual time
    Shield();  // Repeat process with cool down
    } else if (powerUpTimer <= 0 && shield == true){
    shield = false; // Reset bool
    powerUpTimer = 0; // Reset timer
    ResetPowerUp(); // Reset EVERYTHING
    shieldSpawned = false; // Reset shield spawn bool
    }
}

public void Multiplier(){
    powerUpTimer = powerUpCountdown; // Set timer to variable established in inspector
    if (powerUpTimer > 0 && multiplier == true){
    scoreMultiplierAction = scoreMultiplier; 
    powerUpTimer -= Time.deltaTime; // Subtract timer by actual time
    Multiplier();  // Repeat process with cool down
    } else if (powerUpTimer <= 0 && multiplier == true){
    scoreMultiplierAction = 1; // Reset multiplier
    multiplier = false; // Reset bool
    powerUpTimer = 0; // Reset timer
    ResetPowerUp(); // Reset EVERYTHING
    }
}

public void ResetPowerUp(){
  Time.timeScale = 1; // Reset time scale
  scoreMultiplierAction = 1; // Reset multiplier
  powerUpTimer = 0;
  slowTime = false;
  laserDefense = false;
  shield = false;
  multiplier = false;
}
