using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public int currentRound = 1;
    public TextMeshProUGUI roundText;
    public List<GameObject> basketList;

    public void GameOver() {
        SceneManager.LoadScene("GameOverScene");
    }
    
    public void NextRound() {
        currentRound++;
        roundText.text = "Round: " + currentRound;
        ResetBaskets();
    }

    public void ResetBaskets() {
        foreach(GameObject basketGO in basketList) {
            Destroy(basketGO);
        }
    basketList.Clear();

        for(int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    basketList = new List<GameObject>();
      for(int i = 0; i < numBaskets; i++) {
        GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY + (basketSpacingY * i);
        tBasketGO.transform.position = pos;
        basketList.Add(tBasketGO);
      }  
    }

    public void AppleMissed() {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach(GameObject tempGO in appleArray) {
                Destroy(tempGO);
            }
        if(basketList.Count > 0) {
            int basketIndex = basketList.Count -1;
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
        }

        if(basketList.Count == 0) {
            NextRound();
            //SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentRound >= 5) {
            GameOver();
        }
    }
}
