using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pokemans;
using System;
using UnityEngine.Networking;
using IBM.Watson.DeveloperCloud.Logging;

namespace Pokemans
{
		public interface Pokemon
		{
			int GetHealth();
			IEnumerator AttackEnemyPokemon(string attack);
			IEnumerator DeductHealth(int atkPwr);
		}
}
public class GameLogic : MonoBehaviour
{
	private bool isPlayersTurn = true;

	[SerializeField]
	public GameObject player;
		[SerializeField]
	public GameObject enemy;

	[SerializeField]
		public Canvas canvas;

	private UserInterfaceController uiController;

	private PlayerScript playerScript;
	private EnemyScript enemyScript;

	private Pokemon playerPokemon;
	private Pokemon enemyPokemon;

	private class Squirtle : Pokemon
	{
		private static string[] ATTACKS   = { "Water gun", "Bubbles", "Scratch" };
		private static int[] ATTACK_POWER = { 40, 40, 40 };

		private static int HEALTH_STAT = 132;
		private static int ATTACK_STAT = 81;
		private static int DEFENSE_STAT = 95;
		private static int SP_ATTACK_STAT = 68;
		private static int SP_DEFENSE_STAT = 64;

		private int health;

		private static string ACTIVE_URL = "https://huangsa.lib.id/activeplayer-calc@1.0.3/?";
		private static string WAITING_URL = "https://huangsa.lib.id/waitingplayer-calc@1.0.1/?";

		private GameLogic parent;
		private bool isPlayer;

		private class ActiveResponse
		{
			public string typeOfMove;
			public int value;
		}

		public Squirtle(GameLogic parent, bool isPlayer)
		{
			health = HEALTH_STAT;
			this.parent = parent;
			this.isPlayer = isPlayer;
			if (isPlayer)
			{
				parent.uiController.setPlayerName("Squirtle");
				parent.uiController.setPlayerHealthBar(health, HEALTH_STAT);
				parent.uiController.setPlayerMove1(ATTACKS[0]);
				parent.uiController.setPlayerMove2(ATTACKS[1]);
				parent.uiController.setPlayerMove3(ATTACKS[2]);
			}
			else
			{
				parent.uiController.setEnemyName("Squirtle");
				parent.uiController.setEnemyHealthBar(health, HEALTH_STAT);
			}
		}

		public int GetHealth()
		{
			return health;
		}

		public IEnumerator AttackEnemyPokemon(string attack)
		{
			int index = Array.IndexOf(ATTACKS, attack);
			int attackPower = ATTACK_POWER[index];
			UnityWebRequest www = UnityWebRequest.Get(getFormattedActiveUrl("ATK", attackPower));
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.downloadHandler.text);
				parent.callDeductHealth(Convert.ToInt32(Convert.ToDouble(www.downloadHandler.text)));
			}
		}

		public IEnumerator DeductHealth(int atkPwr)
		{
			UnityWebRequest www = UnityWebRequest.Get(getFormattedWaitingUrl(atkPwr));
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.downloadHandler.text);
				health -= Convert.ToInt32(Convert.ToDouble(www.downloadHandler.text));
				if (isPlayer)
				{
					parent.uiController.setPlayerHealthBar(health, HEALTH_STAT);
				}
				else
				{
					parent.uiController.setEnemyHealthBar(health, HEALTH_STAT);
				}
			}
		}

		private string getFormattedActiveUrl(string atkType, int atkMove)
		{
			return ACTIVE_URL + "type=" + atkType
					+ "&atkStat=" + ATTACK_STAT
					+ "&atkMove=" + atkMove
					+ "&defStat=" + DEFENSE_STAT;
		}

		private string getFormattedWaitingUrl(int atkPwr)
		{
			return WAITING_URL + "atkPwr=" + atkPwr
					+ "&defStat=" + DEFENSE_STAT;
		}
	}
		private class Charmander : Pokemon
		{
			private static string[] ATTACKS   = { "Ember", "Flamethrower", "Tackle" };
			private static int[] ATTACK_POWER = { 40, 40, 40 };

			private static int HEALTH_STAT = 132;
			private static int ATTACK_STAT = 81;
			private static int DEFENSE_STAT = 95;
			private static int SP_ATTACK_STAT = 68;
			private static int SP_DEFENSE_STAT = 64;

			private int health;

			private static string ACTIVE_URL = "https://huangsa.lib.id/activeplayer-calc@1.0.3/?";
			private static string WAITING_URL = "https://huangsa.lib.id/waitingplayer-calc@1.0.1/?";

			private GameLogic parent;
			private bool isPlayer;

			private class ActiveResponse
			{
				public string typeOfMove;
				public int value;
			}

			public Charmander(GameLogic parent, bool isPlayer)
			{
				health = HEALTH_STAT;
				this.parent = parent;
				this.isPlayer = isPlayer;
				if (isPlayer)
				{
					parent.uiController.setPlayerName("Charmander");
					parent.uiController.setPlayerHealthBar(health, HEALTH_STAT);
					parent.uiController.setPlayerMove1(ATTACKS[0]);
					parent.uiController.setPlayerMove2(ATTACKS[1]);
					parent.uiController.setPlayerMove3(ATTACKS[2]);
				}
				else
				{
					parent.uiController.setEnemyName("Charmander");
					parent.uiController.setEnemyHealthBar(health, HEALTH_STAT);
				}
			}

			public int GetHealth()
			{
				return health;
			}

			public IEnumerator AttackEnemyPokemon(string attack)
			{
				int index = Array.IndexOf(ATTACKS, attack);
				int attackPower = ATTACK_POWER[index];
				UnityWebRequest www = UnityWebRequest.Get(getFormattedActiveUrl("ATK", attackPower));
				yield return www.SendWebRequest();

				if (www.isNetworkError || www.isHttpError)
				{
					Debug.Log(www.error);
				}
				else
				{
					Debug.Log(www.downloadHandler.text);
					parent.callDeductHealth(Convert.ToInt32(Convert.ToDouble(www.downloadHandler.text)));
				}
			}

			public IEnumerator DeductHealth(int atkPwr)
			{
				UnityWebRequest www = UnityWebRequest.Get(getFormattedWaitingUrl(atkPwr));
				yield return www.SendWebRequest();

				if (www.isNetworkError || www.isHttpError)
				{
					Debug.Log(www.error);
				}
				else
				{
					Debug.Log(www.downloadHandler.text);
					health -= Convert.ToInt32(Convert.ToDouble(www.downloadHandler.text));
					if (isPlayer)
					{
						parent.uiController.setPlayerHealthBar(health, HEALTH_STAT);
					}
					else
					{
						parent.uiController.setEnemyHealthBar(health, HEALTH_STAT);
					}
				}
			}

			private string getFormattedActiveUrl(string atkType, int atkMove)
			{
				return ACTIVE_URL + "type=" + atkType
						+ "&atkStat=" + ATTACK_STAT
						+ "&atkMove=" + atkMove
						+ "&defStat=" + DEFENSE_STAT;
			}

			private string getFormattedWaitingUrl(int atkPwr)
			{
				return WAITING_URL + "atkPwr=" + atkPwr
						+ "&defStat=" + DEFENSE_STAT;
			}
		}

	public void callDeductHealth(int calculatedAttackPower)
	{
		if (isPlayersTurn)
		{
			StartCoroutine(enemyPokemon.DeductHealth(calculatedAttackPower));
			isPlayersTurn = false;
		}
		else
		{
			StartCoroutine(playerPokemon.DeductHealth(calculatedAttackPower));
			isPlayersTurn = true;
		}
	}

	// Use this for initialization
	void Start ()
	{
		uiController = canvas.GetComponent<UserInterfaceController>();
		playerScript = player.GetComponent<PlayerScript>();
		enemyScript = enemy.GetComponent<EnemyScript>();

		StartCoroutine(PlayGame());
	}

	private IEnumerator PlayGame()
	{
		playerPokemon = new Squirtle(this, true);
		enemyPokemon = new Charmander(this, false);

		while (playerPokemon.GetHealth() > 0 && enemyPokemon.GetHealth() > 0)
		{
			yield return StartCoroutine(playerScript.GetAttack(playerPokemon));
			yield return StartCoroutine(enemyScript.GetAttack(enemyPokemon));
			Debug.Log("Player health: " + playerPokemon.GetHealth() + " | Enemy health: " + enemyPokemon.GetHealth());
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
