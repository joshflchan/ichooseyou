using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {
	private GameObject PlayerName;
	private GameObject PlayerHealthBar;
	private GameObject PlayerMove1;
	private GameObject PlayerMove2;
	private GameObject PlayerMove3;
	
	private GameObject EnemyName;
	private GameObject EnemyHealthBar;

	// Use this for initialization
	void Start () {
		PlayerName = GameObject.Find("Player Name");
		PlayerHealthBar = GameObject.Find("Player Health Bar");
		PlayerMove1 = GameObject.Find("Player Move 1");
		PlayerMove2 = GameObject.Find("Player Move 2");
		PlayerMove3 = GameObject.Find("Player Move 3");
		EnemyName = GameObject.Find("Enemy Name");
		EnemyHealthBar = GameObject.Find("Enemy Health Bar");
	}

	public void setPlayerName(string name)
	{
		PlayerName.GetComponent<Text>().text = name;
	}

	public void setPlayerHealthBar(int currentHealth, int maxHealth)
	{
		PlayerHealthBar.GetComponent<Slider>().value = currentHealth * 100 / maxHealth;
	}

	public void setPlayerMove1(string move)
	{
		PlayerMove1.GetComponent<Text>().text = move;
	}

	public void setPlayerMove2(string move)
	{
		PlayerMove2.GetComponent<Text>().text = move;
	}

	public void setPlayerMove3(string move)
	{
		PlayerMove3.GetComponent<Text>().text = move;
	}

	public void setEnemyName(string name)
	{
		EnemyName.GetComponent<Text>().text = name;
	}

	public void setEnemyHealthBar(int currentHealth, int maxHealth)
	{
		EnemyHealthBar.GetComponent<Slider>().value = currentHealth * 100 / maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
