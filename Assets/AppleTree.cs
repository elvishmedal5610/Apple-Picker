using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject badApplePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float badAppleChance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
      Invoke("DropApple", 2f);  
    }

    void DropApple() {
      GameObject apple;
      if(Random.value < badAppleChance) {
        apple = Instantiate<GameObject>(badApplePrefab);
      }
      else {
        apple = Instantiate<GameObject>(applePrefab);
      }
        //GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
      //Basic Movement
      Vector3 pos = transform.position;
      pos.x += speed * Time.deltaTime;
      transform.position = pos;

      //Changing Direction
      if(pos.x < -leftAndRightEdge) {
        speed = Mathf.Abs(speed);
      }
      else if(pos.x > leftAndRightEdge) {
        speed = -Mathf.Abs(speed);
      }
      //else if(Random.value < changeDirChance) {
        //speed *= -1;
      //}  
    }
    void FixedUpdate() {
        if(Random.value < changeDirChance) {
            speed *= -1;
        }
    }
}
