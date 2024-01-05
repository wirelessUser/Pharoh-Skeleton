using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRend;

    public GameObject linePos_1, linePos_2;

   public GameObject bulletPrefab;

    public float  fireBulletSpeed;

    public Transform LeftHandWithGun;

    public float rotationSpeedLimiter;
    public List<Rigidbody2D> bulletBody;
    public float distanceFromCamera = 10f;
    [SerializeField] private Transform aimingCrossHair;
    void Start()
    {
        mainCamera = Camera.main;
        lineRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouseInput();
    }


    public void TrackMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            Debug.Log("Mosue Button Is Up");
        }

    }


    public void Aim()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 aimPoint = ray.GetPoint(distanceFromCamera);
        Vector3 aimDirection = aimPoint - linePos_1.transform.position;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        LeftHandWithGun.transform.rotation = Quaternion.Slerp(LeftHandWithGun.transform.rotation, targetRotation, Time.deltaTime * rotationSpeedLimiter);

        SetLineRendererWhileAiming();
        SettingCrosshairToAim();
    }

    private void SettingCrosshairToAim()
    {
        aimingCrossHair.gameObject.SetActive(true);
        aimingCrossHair.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.forward * 10);
    }

    private void SetLineRendererWhileAiming()
    {
        lineRend.positionCount = 2;
        lineRend.enabled = true;
        lineRend.SetPosition(0, linePos_1.transform.position);
        lineRend.SetPosition(1, linePos_2.transform.position);
    }

    public void Fire()
    {
        lineRend.enabled = false;

        GameObject bullet = Instantiate(bulletPrefab, linePos_1.transform.position, linePos_1.transform.rotation);
        Vector3 dirBullet = (linePos_2.transform.position - linePos_1.transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * fireBulletSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 3);

    }
}
