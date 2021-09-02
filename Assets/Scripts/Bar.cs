using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bar : MonoBehaviour
{
    public float maxLength = 1f;
    public Vector2 startPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;
    public HingeJoint2D startJoint;
    public HingeJoint2D endJoint;

    private float _startJointCurrentLoad = 0;
    private float _endJointCurrentLoad = 0;
    private MaterialPropertyBlock _propBlock;

    public void UpdateCreatingBar(Vector2 toPosition)
    {
        transform.position = (toPosition + startPosition) / 2;

        Vector2 dir = toPosition - startPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;
    }

    public void UpdateMaterial()
    {
        if (startJoint != null) _startJointCurrentLoad = startJoint.reactionForce.magnitude / startJoint.breakForce;
        if (endJoint != null) _endJointCurrentLoad = endJoint.reactionForce.magnitude / endJoint.breakForce;
        float maxLoad = Mathf.Max(_startJointCurrentLoad, _endJointCurrentLoad);

        _propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(_propBlock);
        barSpriteRenderer.SetPropertyBlock(_propBlock);

    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            UpdateMaterial();
        }
    }
}
