using UnityEngine;
using UnityEngine.EventSystems;

public class PawnCorpController : MonoBehaviour, IPointerClickHandler
{
    public float Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.GetComponentInParent<PawnController>().IsPawnActive == false)
            return;

        var direction = gameObject.GetComponentInParent<Transform>().rotation * Vector3.right;
        GetComponent<Rigidbody>().AddForce(direction.normalized * Force, ForceMode.Acceleration);
    }
}
