using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pokemans;

public class EnemyScript : MonoBehaviour {

	int i = 0;
	public Animator animator;
	public GameObject flamethrower;
	public GameObject ember;
    // circle stuff
	public IEnumerator GetAttack(Pokemon pokemon)
    {
		yield return new WaitForSeconds (2f);
      animator.enabled = true;
			if (i==0){
      animator.Play("Ember");
			yield return StartCoroutine(pokemon.AttackEnemyPokemon("Ember"));
      ember.gameObject.SetActive(true);
      yield return new WaitForSeconds(3);
			animator.enabled = false;
      ember.gameObject.SetActive(false);
			i++;
		} else if (i==1){
      animator.Play("Flamethrower");
			yield return StartCoroutine(pokemon.AttackEnemyPokemon("Flamethrower"));
      flamethrower.gameObject.SetActive(true);
      yield return new WaitForSeconds(3);
			animator.enabled = false;
      flamethrower.gameObject.SetActive(false);
			i++;
		} else if (i==2){
      animator.Play("Itch");
      yield return new WaitForSeconds(3);
      animator.Play("Idle");
			animator.enabled = false;
			yield return StartCoroutine(pokemon.AttackEnemyPokemon("Tackle"));
			i=0;
		}
  }

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		flamethrower.gameObject.SetActive(false);
		ember.gameObject.SetActive(false);
	}

    private void Update()
    {
    }

}
