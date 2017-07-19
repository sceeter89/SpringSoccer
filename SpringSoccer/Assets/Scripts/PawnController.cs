using UnityEngine;
using UnityEngine.EventSystems;

public class PawnController : MonoBehaviour, IPointerClickHandler
{
    private bool _isMousePressed;

    public float PawnRotationSpeed = 10;
    public bool IsPawnActive = false;
    public GameObject PawnCamera;
    public GameObject Pawn;

    private void Start ()
    {
    }

    private void Update()
    {
        if (IsPawnActive == false)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeselectPawn();
            SetMainCameraActive(true);
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isMousePressed = false;
        }
        if (_isMousePressed)
        {
            gameObject.transform.RotateAround(transform.position, Vector3.up,
                Input.GetAxis("Mouse X") * PawnRotationSpeed);
            /*var joint = Pawn.GetComponent<HingeJoint>();
            var rotationQuaternion = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * PawnRotationSpeed, Vector3.up);
            joint.axis = rotationQuaternion * joint.axis;
            joint.anchor = rotationQuaternion * joint.anchor;
            joint.connectedAnchor = rotationQuaternion * joint.connectedAnchor;*/
        }
    }

    public void SelectPawn()
    {
        PawnCamera.SetActive(true);
        IsPawnActive = true;
        
        GameObject.Find("Corp").GetComponent<PawnCorpController>().enabled = true;
    }

    public void DeselectPawn()
    {
        PawnCamera.SetActive(false);
        IsPawnActive = false;

        GameObject.Find("Corp").GetComponent<PawnCorpController>().enabled = false;
    }

    private void SetMainCameraActive(bool isActive)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = isActive;
    }

    private bool GetMainCameraActive()
    {
        return GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetMainCameraActive() == false)
            return;

        SetMainCameraActive(false);
        var pawns = GameObject.FindGameObjectsWithTag("PawnTag");

        foreach (var pawn in pawns)
        {
            var controller = pawn.GetComponent<PawnController>();
            controller.DeselectPawn();
        }

        SelectPawn();
    }
}
