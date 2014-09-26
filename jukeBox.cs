public AudioClip music1;
public AudioClip music2;
public AudioClip music3;
public AudioClip music4;
public AudioClip music5;

private int randomRoll;

void Start() {
  randomRoll = Random.Range(0,4)
  if (randomRoll == 0) {
    audio.clip = music1;
    audio.Play();
    audio.loop = true;
  }
  if (randomRoll == 1) {
    audio.clip = music2;
    audio.Play();
    audio.loop = true;
  }
  if (randomRoll == 2) {
    audio.clip = music3;
    audio.Play();
    audio.loop = true;
  }
  if (randomRoll == 3) {
    audio.clip = music4;
    audio.Play();
    audio.loop = true;
  }
  if (randomRoll == 4) {
    audio.clip = music5;
    audio.Play();
    audio.loop = true;
  }
}
