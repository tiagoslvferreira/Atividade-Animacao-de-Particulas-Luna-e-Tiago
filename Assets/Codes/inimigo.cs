using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inimigo : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2.0f;
    

    private Transform target;
    private Vector3 originalScale;
    private bool isFacingRight = true; // Verifica a direção atual

    private void Start()
    {
        target = startPoint;
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Calcula a direção do movimento
        Vector2 moveDirection = (target.position - transform.position).normalized;

        // Move o inimigo em direção ao ponto de destino
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Verifica se o inimigo chegou ao ponto de destino
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            // Troca o ponto de destino entre start e end
            target = (target == startPoint) ? endPoint : startPoint;

            // Inverte a escala (flip) quando muda de direção
            if ((moveDirection.x > 0 && !isFacingRight) || (moveDirection.x < 0 && isFacingRight))
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                isFacingRight = !isFacingRight; // Inverte o estado da direção
            }
        }
    }

    
}
