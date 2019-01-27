using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class watergunscript : MonoBehaviour
{
    public Button squirtleAttack2;
    public GameObject watergun;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        squirtleAttack2.onClick.AddListener(squirtleAttack2Down);
        watergun.gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        watergun.gameObject.SetActive(true);
        animator.enabled = true;
        animator.Play("Bubble");

        yield return new WaitForSeconds(3);
        watergun.gameObject.SetActive(false);
        animator.enabled = false;
    }

    void squirtleAttack2Down()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
