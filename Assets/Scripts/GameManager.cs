using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	/// <summary> The singleton isntance of the GameMnager. </summary>
	public static  GameManager Instance { get; private set; }

	/// <summary> The current life points. </summary>
	public int Life { get;set;}

	/// <summary> The total number of life points. </summary>
	public int TotalLife { get; set; }

	/// <summary> The current number of enemies. </summary>
	public int Enemies { get; set; }

	/// <summary> The total number of enemies. </summary>
	public int TotalEnemies { get; set; }

	/// <summary> The scrollbar for life points. </summary>
	Scrollbar LifeBar;

	/// <summary> The scrollbar for enemies. </summary>
	Scrollbar EnemyBar;

	/// <summary> The text for the Win/Lose message. </summary>
	Text MessageText;

	/// <summary> Called upon initialization. </summary>
	void Start ()
	{
		// Initialize the fields
		Instance = this;
		Life = TotalLife = 6;
		Enemies = TotalEnemies = 6;
		LifeBar = GameObject.Find("LifeBar").GetComponent< Scrollbar>();
		EnemyBar = GameObject.Find("EnemyBar").GetComponent<Scrollbar>();
		MessageText = GameObject.Find("MessageText").GetComponent<Text>();
	}

	/// <summary> Called on every frame. </summary>
	void Update ()
	{
		//  Update the scroll bars
		LifeBar.size = ((float)Life)/ ((float) TotalLife);
		EnemyBar.size = ((float)Enemies) / ((float)TotalEnemies);

		// Check the winning/lossing conditions
		if (Enemies == 0) {
			LifeBar.gameObject.SetActive(false);
			EnemyBar.gameObject.SetActive(false);
			MessageText.text = "YOU WIN!!!";
		}
		if (Life == 0) {
			LifeBar.gameObject.SetActive(false);
			EnemyBar.gameObject.SetActive(false);
			MessageText.text = "YOU LOSE!!!";
		}
	}
}
