public float spawnTimer;
private float spawnTimerMaster;

public GameObject defaultRock; //Default rock, most common
public float defaultRockChance; //How frequently do they spawn?
public GameObject durableRock; //Takes a lot of hits
public float durableRockChance; //How frequently do they spawn?
public GameObject multiRock; //Breaks apart
public float multiRockChance; //How frequently do they spawn?

// Translation variables for 0-100 rolls
private float durableRockChanceTrans;
private float multiRockChanceTrans;
private float timeChanceTrans;
private float laserChanceTrans;
private float shieldChanceTrans;


public GameObject timePowerUp;
public float timeChance;
public GameObject laserPowerUp;
public float laserChance;
public GameObject shieldPowerUp;
public float shieldChance;
public GameObject multiplierPowerUp;
public float multiChance;
/* a note on the chance variables:
 * The script calculates the percentages by subtracting the percentage listed in the variable from 99 and then determining 
 * its probability in the Spawn() function. multiRockChance isn't used but is only there as a check digit for the other two.
 * Example: DefaultRock = 50, DurableRock = 35, MultiRock = 15; RandomRange = 0-99
 * Actuals: DefaultRock = 49, DurableRock = 84, MultiRock = null.
 * DefaultRock spawns if RandomRange is 0-49
 * DurableRock spawns if RandomRange is 50-84
 * MultiRock spawns if RandomRange is 85-99
 */

private GameObject spawnRock; //Placeholder for which rock to spawn
public float spawnTimerCall; //This number indicates the speed of spawns. Higher number = slower spawns!
public int maxWaveSize;
public float centerSpawnX;

public Vector3 rockDistance; //How far apart are the rocks? USE POSITIVE NUMBERS


void Awake() {
	spawnTimerMaster = 0; // Reset the timer to 0 each level
	//Check to see if chance percentages add up
	if (defaultRockChance + durableRockChance + multiRockChance + timeChance + laserChance + shieldChance + multiChance != 100) { 
		Debug.Log("INCORRECT CHANCE VALUES! VALUES SHOULD BE BETWEEN 0-100. VALUES SET TO DEFAULTS");
		defaultRockChance = 65;
		durableRockChance = 15;
		multiRockChance = 8;
		timeChance = 3;
		laserChance = 3;
		shieldChance = 3;
		multiChance = 3;
	}
	
	// Translate chances into usable percentages, number indicates MAX because MIN is already known
	durableRockChanceTrans = Mathf.Abs(99-multiRockChance-timeChance-laserChance-shieldChance-multiChance); 
	multiRockChanceTrans = Mathf.Abs(99-timeChance-laserChance-shieldChance-multiChance);
	timeChanceTrans = Mathf.Abs(99-laserChance-shieldChance-multiChance);
	laserChanceTrans = Mathf.Abs(99-shieldChance-multiChance);
	shieldChanceTrans = Mathf.Abs(99-multiChance);

	Spawn();
}

void FixedUpdate() {
	spawnTimerMaster += spawnTimer * Time.deltaTime; //Slowly add up the spawn timer to increase difficulty
}

void Update(){
	spawnTimerCall -= spawnTimerMaster; //Subtract the difficulty time scale from the spawn scale
	
	Invoke("Spawn", spawnTimerCall); //Call to spawn a new rock
}

void Spawn(){
	private int RandomRockSelector; //Random roll for rock type spawn
	RandomRockSelector = Random.Range(0,99); 
	
	private Vector3 spawnLocation; //Where does it spawn at?
	spawnLocation = new Vector3(Random.Range(-centerSpawnX,centerSpawnX), 10, 0);
	private Vector3 savedSpawnLocation;
	private Vector3 newRockSpawn;
	
	private Quaternion spawnRotation; //Random rotation (modeled for 3D)
	spawnRotation = new Vector3(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
	
	private int waveCount; //How many in the wave?
	private int waveCountMax; //Total in a wave

	//If not in a wave, set wave number
	if (waveCount == 0){
		savedSpawnLocation = spawnLocation;
		waveCount = Random.Range(1,maxWaveSize); //Randomly select wave size
		waveCountMax = waveCount; 
	}
	
	//If in a wave, spawn until not in a wave
	if (waveCount > 0) {
		//Uses the Chance float variables to determine which rock to spawn, alter in inspector
		// ROCKS
		if (RandomRockSelector >= 0 && RandomRockSelector <= defaultRockChance) {
			spawnRock = defaultRock;
		}
		if (RandomRockSelector > defaultRockChance && RandomRockSelector <= durableRockChanceTrans) {
			spawnRock = durableRock;
		}
		
		if (RandomRockSelector > durableRockChanceTrans && RandomRockSelector <= multiRockChanceTrans) {
			spawnRock = multiRock;
		}
		
		
		// POWER UPS
		if (RandomRockSelector > multiRockChanceTrans && RandomRockSelector <= timeChanceTrans) {
			spawnRock = timePowerUp;
		}
		
		if (RandomRockSelector > timeChanceTrans && RandomRockSelector <= laserChanceTrans) {
			spawnRock = laserPowerUp;
		}
		
		if (RandomRockSelector > laserChanceTrans && RandomRockSelector <= shieldChanceTrans) {
			spawnRock = shieldPowerUp;
		}
		
		if (RandomRockSelector > shieldChanceTrans && RandomRockSelector <= 99) {
			spawnRock = multiplierPowerUp;
		}
		
		//FIRST SPAWN?
		if (waveCount == waveCountMax) {
		Instantiate(spawnRock, spawnLocation, spawnRotation);
		}
		
		//IF FIRST SPAWN WAS TO THE LEFT OF CENTER, STAGGER TO THE RIGHT
		if (waveCount != waveCountMax && savedSpawnLocation.x <= centerSpawnX){
			newRockSpawn = new Vector3(savedSpawnLocation.x + rockDistance.x * (waveCountMax - waveCount), savedSpawnLocation.y + rockDistance.y * (waveCountMax - waveCount), savedSpawnLocation.z)
			Instantiate(spawnRock, newRockSpawn, spawnRotation);
		}
		//IF FIRST SPAWN WAS TO THE RIGHT OF CENTER, STAGGER TO THE LEFT
		if (waveCount != waveCountMax && savedSpawnLocation.x <= centerSpawnX){
			newRockSpawn = new Vector3(savedSpawnLocation.x - rockDistance.x * (waveCountMax - waveCount), savedSpawnLocation.y - rockDistance.y * (waveCountMax - waveCount), savedSpawnLocation.z)
			Instantiate(spawnRock, newRockSpawn, spawnRotation);
		}
		
		waveCount -= 1; //Subtract from the wave count if spawned
		if (waveCount == 0) {
		savedSpawnLocation = null;	
		}
		Spawn();
		}
	}
}
