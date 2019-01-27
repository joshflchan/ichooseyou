using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flamethrowerscript : MonoBehaviour {
    public Button charmanderAttack1;
    public GameObject flamethrower;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        charmanderAttack1.onClick.AddListener(charmanderAttack1Down);
        flamethrower.gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        animator.enabled = true;
        animator.Play("Flamethrower");

        flamethrower.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        flamethrower.gameObject.SetActive(false);
        animator.enabled = false;
    }

    void charmanderAttack1Down()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
