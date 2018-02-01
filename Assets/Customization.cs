using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour {

	Sprite[] SpriteSheet;
	int CurrHeadID, CurrBodyID;
	Image representation;
	Text MobilityPointsText, ControlPointsText, DamagePointsText, StatPointsText;
	public int statPointsLeft;
	int ControlPoints = 1;
	int MobilityPoints = 1;
	int DamagePoints = 1;
	Button ControlBack, MobilityBack, DamageBack;
	Button ControlForward, MobilityForward, DamageForward;
	Button CreateCharacter;

	void Start () {

		//finding point texts

		MobilityPointsText = GameObject.Find ("MobilityPoints").GetComponent<Text> ();
		ControlPointsText = GameObject.Find ("ControlPoints").GetComponent<Text> ();
		DamagePointsText = GameObject.Find ("DamagePoints").GetComponent<Text> ();
		StatPointsText = GameObject.Find ("PointsLeft").GetComponent<Text> ();

		ControlBack = GameObject.Find ("ControlChangerBtBack").GetComponent<Button> ();
		MobilityBack = GameObject.Find ("MobilityChangerBtBack").GetComponent<Button> ();
		DamageBack = GameObject.Find ("DamageChangerBtBack").GetComponent<Button> ();

		ControlForward = GameObject.Find ("ControlChangerBt").GetComponent<Button> ();
		MobilityForward = GameObject.Find ("MobilityChangerBt").GetComponent<Button> ();
		DamageForward = GameObject.Find ("DamageChangerBt").GetComponent<Button> ();

		CreateCharacter = GameObject.Find ("CreateCharacter").GetComponent<Button> ();

		representation = GameObject.Find("Rep").GetComponent<Image>();
		CurrBodyID = 0;
		CurrHeadID = 0;
		SpriteSheet = Resources.LoadAll<Sprite> ("testeSprite");

		StatPointsText.text = "Stat Points Left: " + statPointsLeft;
		ControlPointsText.text = ControlPoints.ToString ();
		MobilityPointsText.text = MobilityPoints.ToString ();
		DamagePointsText.text = DamagePoints.ToString();

	}

	void Update(){
		//control
		if (ControlPoints == 3) {
			ControlForward.gameObject.SetActive (false);
			ControlBack.gameObject.SetActive (true);
		} 
		else if (ControlPoints == 1) {
			ControlForward.gameObject.SetActive (true);
			ControlBack.gameObject.SetActive (false);
		} 
		else {
			ControlForward.gameObject.SetActive (true);
			ControlBack.gameObject.SetActive (true);
		}

		//mobility
		if (MobilityPoints == 3) {
			MobilityForward.gameObject.SetActive (false);
			MobilityBack.gameObject.SetActive (true);
		} 
		else if (MobilityPoints == 1) {
			MobilityForward.gameObject.SetActive (true);
			MobilityBack.gameObject.SetActive (false);
		} 
		else {
			MobilityForward.gameObject.SetActive (true);
			MobilityBack.gameObject.SetActive (true);
		}

		//Damage
		if (DamagePoints == 3) {
			DamageForward.gameObject.SetActive (false);
			DamageBack.gameObject.SetActive (true);
		} 
		else if (DamagePoints == 1) {
			DamageForward.gameObject.SetActive (true);
			DamageBack.gameObject.SetActive (false);
		} 
		else {
			DamageForward.gameObject.SetActive (true);
			DamageBack.gameObject.SetActive (true);
		}

		if (statPointsLeft == 0) {
			CreateCharacter.interactable = true;
		}
		else {
			CreateCharacter.interactable = false;
		}
	}

	public void AssignStats(string StatChoice){
		if (statPointsLeft > 0) {
			if(StatChoice == "Control" && ControlPoints < 3)
				{
					statPointsLeft -= 1;
					ControlPoints += 1;
					ControlPointsText.text = ControlPoints.ToString ();
					StatPointsText.text = "Stat Points Left: " + statPointsLeft;
				}
			if(StatChoice == "Mobility" && MobilityPoints < 3)
				{
					statPointsLeft -= 1;
					MobilityPoints += 1;
					MobilityPointsText.text = MobilityPoints.ToString ();
					StatPointsText.text = "Stat Points Left: " + statPointsLeft;
				}
			if(StatChoice == "Damage" && DamagePoints < 3)
				{
					statPointsLeft -= 1;
					DamagePoints += 1;
					DamagePointsText.text = DamagePoints.ToString ();
					StatPointsText.text = "Stat Points Left: " + statPointsLeft;
				}
			}
		if (ControlPoints > 1 && StatChoice == "ControlBack") {
			statPointsLeft += 1;
			ControlPoints -= 1;
			ControlPointsText.text = ControlPoints.ToString ();
			StatPointsText.text = "Stat Points Left: " + statPointsLeft;
		}
		if (MobilityPoints > 1 && StatChoice == "MobilityBack") {
			statPointsLeft += 1;
			MobilityPoints -= 1;
			MobilityPointsText.text = MobilityPoints.ToString ();
			StatPointsText.text = "Stat Points Left: " + statPointsLeft;
		}
		if (DamagePoints > 1 && StatChoice == "DamageBack") {
			statPointsLeft += 1;
			DamagePoints -= 1;
			DamagePointsText.text = DamagePoints.ToString ();
			StatPointsText.text = "Stat Points Left: " + statPointsLeft;
		}
	}

	public void ChangeHead()
	{
		if (CurrHeadID < 2) 
		{
			CurrHeadID++;
		} 
		else if (CurrHeadID == 2) 
		{
			CurrHeadID = 0;
		}

		foreach (Sprite s in SpriteSheet) {
			if (s.name.Equals ("testeSprite_" + CurrBodyID + CurrHeadID)) 
			{
				representation.sprite = s;
			}
		}
	}

	public void ChangeBody(){
		if (CurrBodyID < 2) 
		{
			CurrBodyID++;
		} 
		else if (CurrBodyID == 2) 
		{
			CurrBodyID = 0;
		}

		foreach (Sprite s in SpriteSheet) {
			if (s.name.Equals ("testeSprite_" + CurrBodyID + CurrHeadID)) 
			{
				representation.sprite = s;
			}
		}
	}
}
