using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class DogAttackState : DogBaseState
{
    [SerializeField]
    private DogTransition _transition;

    [SerializeField]
    private float _attackTime = 0.25f;

    [SerializeField]
    private float _maxDistance = 0;

    [SerializeField]
    private float _radius;

    public float AttackTime => _attackTime;
    private Rigidbody _rigidbody;

    public override string DoChange(string nextState)
    {
        Dictionary<string, object> dict = new() { ["idle"] = nextState.ToLower() };
        // _weapon.SetActive(false);

        return _transition.MakeTransition(dict);
    }

    public override void FixedUpdate() { }

    public override void OnEnter(Animator animator, Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        animator.SetTrigger("Attack");
        Damage();
    }

    private void Damage()
    {
        Debug.LogWarning("bite");
        _rigidbody.gameObject.GetComponent<DogController>().SpawnAttackTrigger();
    }

    public override void OnExit(Animator animator, Rigidbody rigidbody)
    {
        _rigidbody.gameObject.GetComponent<DogController>().DestroyAtttackTrigger();
    }

    public override void OnInit() { }

    public override void Update() { }
}
