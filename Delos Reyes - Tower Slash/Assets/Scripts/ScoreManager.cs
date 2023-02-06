using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    [Header ("Scores")]
    public float score;
    public float totScore;
    public float highScore;
    public float summonQuota;

    private Text comboTxt;
    public GameObject comboText;
    public int pCombo;
    public int hiCombo;

    public GameObject uiGo;
    private Text hiComboText;
    private Text hiscoreText;
    private Text totscoreText;

    [Header ("Others")]
    public float pSpeed;
    public float pMult;
    private PlayerMovement pScript;
    public bool hard;
    public bool summoned;

    public GameObject bossImg;

    void Start(){
      scoreText = GetComponent<Text>();
      comboTxt = comboText.GetComponent<Text>();
      pScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerMovement>();
      hard = pScript.hard;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null ){
          pSpeed = pScript.speed; //moved here bcos it value doenst autoupdate
          pCombo = pScript.combo;
          pMult = pScript.scoreMult;
          score += pSpeed*pMult*Time.deltaTime;
          scoreText.text = ((int)score).ToString();

          if(pCombo < 10 && pCombo != 0) comboTxt.text = "0"+ pCombo;
          else if(pCombo > 10) comboTxt.text = pCombo.ToString();
          else comboTxt.text = null;
        }

        setPoints();
        //if(score >= summonQuota && hard && !summoned) Summon();
    }

    void setPoints()
    {
      highScore = score;
      if(pCombo > hiCombo){
        hiCombo = pCombo; //store the highest value everytime.
      }

      if(GameObject.FindGameObjectWithTag("Player") == null ){ //activate the scoreboard
      totScore = highScore + ((hiCombo/pMult)*highScore); //latter is bonus

      hiscoreText = uiGo.transform.GetChild(1).GetChild(2).GetComponent<Text>();//hiscore txt
      totscoreText = uiGo.transform.GetChild(1).GetChild(0).GetComponent<Text>();//hiscore txt
      hiComboText = uiGo.transform.GetChild(1).GetChild(1).GetComponent<Text>(); //highest combo hpTxt
      hiscoreText.text = (int)highScore + " pts";
      totscoreText.text = (int)totScore + " pts";
      hiComboText.text = hiCombo.ToString();
      }
    }

    /*void Summon()
    {
      Debug.Log("summoning boss!");
      bossImg.SetActive(true);
      summoned = true;
    }*/
}
