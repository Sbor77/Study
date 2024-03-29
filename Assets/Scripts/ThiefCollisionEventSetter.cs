﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThiefCollisionEventSetter : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public bool IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
            return;

        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsReached = true;
            _reached.Invoke();            
        }
    }
}
