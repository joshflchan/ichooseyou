using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scratch2 : MonoBehaviour
{
    public Button squirtleAttack3;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        squirtleAttack3.onClick.AddListener(squirtleAttack3Down);
        animator = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        animator.enabled = true;
        animator.Play("Itch");

        yield return new WaitForSeconds(2);
        animator.Play("Idle");
        yield return new WaitForSeconds(1);
        animator.enabled = false;
    }

    void squirtleAttack3Down()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
