using FMODUnity;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // 
    FMOD.Studio.EventInstance FootstepsSound;

    public EventReference footstepsEvent;

    private float lastFootstepTime = 0f;
    private float distToGround;
    
    private void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {      
    }
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (IsGrounded() && Time.time - lastFootstepTime > 0.5f)
            {
                lastFootstepTime = Time.time;
                PlayFootsteps();
            }
        }
    }

    void PlayFootsteps()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distToGround + 0.5f))
        {
            if (hit.collider.CompareTag("Stone"))
            {
                FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
                FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                FootstepsSound.setParameterByNameWithLabel("footSwitcher", "Stone");
                FootstepsSound.start();
                FootstepsSound.release();
            }
            else if (hit.collider.CompareTag("Wood"))
            {
                FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
                FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                FootstepsSound.setParameterByNameWithLabel("footSwitcher", "Wood");
                FootstepsSound.start();
                FootstepsSound.release();
            }
            else
            {
                FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
                FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
                FootstepsSound.setParameterByNameWithLabel("footSwitcher", "Stone");
                FootstepsSound.start();
                FootstepsSound.release();
            }
        }       
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.5f);
    }  
}
