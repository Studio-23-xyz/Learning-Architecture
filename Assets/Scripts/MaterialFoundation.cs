using System.Collections;
using System.Collections.Generic;
using Scriptable_object;
using UnityEngine;

public class MaterialFoundation : MonoBehaviour
{
    public MaterialBuilder materialBuilder;
    private HingeJoint2D _leftHingeJoint;
    private HingeJoint2D _rightHingeJoint;
    private int _cost;
    private int _angle;
    private int _strength;
    private float _length;
    private Rigidbody2D _rb;

    void Start()
    {
        AddLeftHingeJoint();

        AddRightHingeJoint();
        
        AssigningValuesFromScriptableObject();
        
        AddRigidBodyAndMakeItStatic();
    }

    private void AssigningValuesFromScriptableObject()
    {
        _cost = materialBuilder.materialCost;
        _angle = materialBuilder.materialAngle;
        _strength = materialBuilder.materialStrength;
        _length = materialBuilder.length;
        gameObject.AddComponent<SpriteRenderer>(); //.sprite = materialBuilder.materialSprite;
    }

    private void AddRightHingeJoint()
    {
        _rightHingeJoint = gameObject.AddComponent<HingeJoint2D>();
        _rightHingeJoint.anchor = new Vector2(-0.5f, 0.0f);
    }

    private void AddLeftHingeJoint()
    {
        _leftHingeJoint = gameObject.AddComponent<HingeJoint2D>();
        _leftHingeJoint.anchor = new Vector2(0.5f, 0.0f);
    }

    private void AddRigidBodyAndMakeItStatic()
    {
        
        gameObject.AddComponent<Rigidbody2D>();
        _rb = GetComponent<Rigidbody2D>();    
        _rb.bodyType = RigidbodyType2D.Static;
    }
    
}
