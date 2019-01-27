using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubblescript : MonoBehaviour {
    public Button squirtleAttack1;
    public GameObject bubbles;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        squirtleAttack1.onClick.AddListener(squirtleAttack1Down);
        bubbles.gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        bubbles.gameObject.SetActive(true);
        animator.enabled = true;
        animator.Play("Bubble");

        yield return new WaitForSeconds(3);
        bubbles.gameObject.SetActive(false);
        animator.enabled = false;
    }

    void squirtleAttack1Down()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
