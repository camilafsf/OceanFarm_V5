using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCcontroller : MonoBehaviour
{
    private Transform[] movePoints;
    private Animator animator;
    private float destroyDelay;

    private int currentPointIndex;
    private List<Transform> randomizedMovePoints; // Lista para armazenar os pontos de movimento reordenados

    public void Initialize(Transform[] points, Animator anim, float delay)
    {
        movePoints = points;
        animator = anim;
        destroyDelay = delay;

        currentPointIndex = 0;
        randomizedMovePoints = new List<Transform>(movePoints); // Copiar os pontos de movimento originais para a lista
        RandomizeMovePoints(); // Chamar a função para reorganizar aleatoriamente os pontos de movimento
        MoveToNextPoint();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, randomizedMovePoints[currentPointIndex].position) < 0.1f)
        {
            PlayRandomAnimation();
            MoveToNextPoint();

            if (currentPointIndex == 0)
            {
                Invoke("DestroyNPC", destroyDelay);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, randomizedMovePoints[currentPointIndex].position, 10f * Time.deltaTime);
        }
    }

    private void MoveToNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % randomizedMovePoints.Count;
        transform.LookAt(randomizedMovePoints[currentPointIndex]);
    }

    private void PlayRandomAnimation()
    {
        int randomAnimationIndex = Random.Range(0, animator.runtimeAnimatorController.animationClips.Length);
        animator.Play(animator.runtimeAnimatorController.animationClips[randomAnimationIndex].name);
    }

    private void DestroyNPC()
    {
        Destroy(gameObject);
    }

    private void RandomizeMovePoints()
    {
        for (int i = 0; i < randomizedMovePoints.Count; i++)
        {
            Transform temp = randomizedMovePoints[i];
            int randomIndex = Random.Range(i, randomizedMovePoints.Count);
            randomizedMovePoints[i] = randomizedMovePoints[randomIndex];
            randomizedMovePoints[randomIndex] = temp;
        }
    }
}