using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class emberscript : MonoBehaviour
{
    public Button charmanderAttack2;
    public GameObject ember;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        charmanderAttack2.onClick.AddListener(charmanderAttack2Down);
        ember.gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        ember.gameObject.SetActive(true);
        animator.enabled = true;
        animator.Play("Ember");

        yield return new WaitForSeconds(2);
        ember.gameObject.SetActive(false);
        animator.enabled = false;
    }

    void charmanderAttack2Down()
    {
        StartCoroutine(Wait());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
