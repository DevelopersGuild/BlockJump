using UnityEngine;
using System.Collections;

public class DisappearingBlock : Block
{
    public float TimeUntilDisapearing;
    public float LengthToDisapear;
    private float disapearingTimer = 0;
    private float reappearTimer = 0;
    private bool isVisible = true;
    private SpriteRenderer spriteRnederer;
    private Collider2D boxCollider;

    protected override void Start()
    {
        base.Start();
        disapearingTimer = TimeUntilDisapearing;
        reappearTimer = LengthToDisapear;
        spriteRnederer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<Collider2D>();
    }

    protected override void Update()
    {
        base.Update();
        if(isVisible == true)
        {
            disapearingTimer = disapearingTimer - Time.deltaTime;
        }
        else
        {
            reappearTimer = reappearTimer - Time.deltaTime;
        }
        if(disapearingTimer <= 0)
        {
            Disappear();
        }
        if(reappearTimer <= 0)
        {
            Reappear();
        }
    }

    private void Disappear()
    {
        spriteRnederer.enabled = false;
        boxCollider.enabled = false;
        isVisible = false;
        disapearingTimer = TimeUntilDisapearing;
    }

    private void Reappear()
    {
        spriteRnederer.enabled = true;
        boxCollider.enabled = true;
        isVisible = true;
        reappearTimer = LengthToDisapear;
    }

}
