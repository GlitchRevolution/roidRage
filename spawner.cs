public float spawnTimer;
private float spawnTimerMaster;

public GameObject defaultRock; //Default rock, most common
public float defaultRockChance; //How frequently do they spawn?
public GameObject durableRock; //Takes a lot of hits
public float durableRockChance; //How frequently do they spawn?
public GameObject multiRock; //Breaks apart
public float multiRockChance; //How frequently do they spawn?
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

void Awake() {
	spawnTimerMaster = 0; // Reset the timer to 0 each level
	durableRockChance = Mathf.Abs(99-durableRockChance); //Translate the percentage
	
	//Check to see if chance percentages add up
	if (defaultRockChance + durableRockChance + multiRockChance != 100) { 
		Debug.Log("INCORRECT CHANCE VALUES! VALUES SHOULD BE BETWEEN 0-100. MULTIROCK VALUE AUTOMATICALLY ADJUSTED");
		multiRockChance = Mathf.Abs(100-durableRockChance-defaultRockChance);
	}
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
	RandomRockSelector = Random.Range(0-99); 
	
	private Vector3 spawnLocation; //Where does it spawn at?
	
	private Quaternion spawnRotation; //Random rotation (modeled for 3D)
	spawnRotation = new Vector3(Random.Range(0-360), Random.Range(0-360), Random.Range(0-360));
	
	//Uses the Chance float variables to determine which rock to spawn, alter in inspector
	if (RandomRockSelector >= 0 && RandomRockSelector <= defaultRockChance) {
		spawnRock = defaultRock;
	}
	if (RandomRockSelector > defaultRockChance && RandomRockSelector <= durableRockChance) {
		spawnRock = durableRock;
	}
	if (RandomRockSelector > durableRockChance && RandomRockSelector <= 99) {
		spawnRock = multiRock;
	}
	Instantiate(spawnRock, spawnLocation, spawnRotation);
}
