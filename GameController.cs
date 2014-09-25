public static GameController;
public int score;
public int time;
private float timeCounter;

//Storage for the explosion particle effects and associated sounds
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

void FixedUpdate() {
timeCounter = Time.deltaTime;
time = (int)timeCounter; //See how long they last in seconds
}

void Update() {
Debug.Log(score); //What's the score
}

public void GameOver(){
  //Put GameoverStuff here
}
