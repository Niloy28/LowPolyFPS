using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Enemy
{
    public class EnemyAction : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Shoot(Transform player)
        {
        }
    }
}