using DG.Tweening;
using UnityEngine;

public class linearmove : MonoBehaviour
{
    public bool shouldmove;

    public float howmuchtomoveX;
    public float howmuchtomoveY;
    public float timetocompleteX;
    public float timetocompleteY;

    public Ease ease;
    public bool shoudloop;
    public LoopType loopType;

    void Start()
    {
        if(shouldmove==true)
        {
            ///...X movement
            this.transform.DOMoveX(this.transform.position.x+howmuchtomoveX,timetocompleteX).SetEase(ease);
            ///...X movement

            ///...Y movement
            this.transform.DOMoveY(this.transform.position.y+howmuchtomoveY,timetocompleteY).SetEase(ease);
            ///...X movement

        }
        if(shoudloop==true)
        {
            ///...X movement
            this.transform.DOMoveX(this.transform.position.x+howmuchtomoveX,timetocompleteX).SetEase(ease).SetLoops(-1,loopType);
            ///...X movement

            ///...Y movement
            this.transform.DOMoveY(this.transform.position.y+howmuchtomoveY,timetocompleteY).SetEase(ease).SetLoops(-1,loopType);
            ///...Y movement
        }

    }
}
