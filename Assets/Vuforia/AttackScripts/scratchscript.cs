using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scratchscript : MonoBehaviour
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
        animator.Play("Scratch");

        yield return new WaitForSeconds(3);
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
