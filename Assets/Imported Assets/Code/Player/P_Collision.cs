﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Collision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]
    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    // public bool onUpperRightWall;
    // public bool onUpperLeftWall;
    // public bool onLowerRightWall;
    // public bool onLowerLeftWall;
    public int wallSide;

    [Space]
    [Header("Collision")]
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset,
    LowerRightOffset,
    LowerLeftOffset,
    rightOffset,
    leftOffset;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer)
                    || Physics2D.OverlapCircle((Vector2)transform.position + LowerLeftOffset, collisionRadius, groundLayer)
                    || Physics2D.OverlapCircle((Vector2)transform.position + LowerRightOffset, collisionRadius, groundLayer);

        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
                    || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        wallSide = onRightWall ? -1 : 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset,
                                        rightOffset, leftOffset,
                                        LowerRightOffset,
                                        LowerLeftOffset
                                        };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LowerRightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LowerLeftOffset, collisionRadius);
    }
}