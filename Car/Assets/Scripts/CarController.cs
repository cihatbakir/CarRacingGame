using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class AxleInfo // AxleInfo --> Aks bilgileri
{
    public WheelCollider leftWheel;  // sol tekerlek
    public WheelCollider rightWheel; // sað tekerlek
    public bool motor;
    public bool steering; // steering = direksiyon

}
public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;  // Aks bilgilerini açýk bir listeye baðladým.
    public float maxMotorTorque;  // max motor torku (gücü)
    public float maxSteeringAngle; // max direksiyon açýsý
    public float acceleration; // hýzlanma
    public Camera miniMapCamera; // RaceManager dan miniMapCamera yý burada tanýmladýk.
    public Camera mainCamera; // ana kamera
    public Rigidbody rigidbody; // katý cisim
    public Action<double> MPH; // Arabanýn sað alt taraftaki mph gösterimi

    void Awake()
    {
        if(gameObject.tag != "Player")
        {
            miniMapCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(true);
        }
    }


    private void FixedUpdate()  // Ýþlevin içerisinde fizik hesaplamalarý yapmak istediðinizde, sabit güncelleme kullandýðýnýzdan emin olun unýty içinde temel kural budur.
    {
        // öncelikle Klavyedeki oklarý kullanarak önce ayarlayacaðýmýz motor adýnda bir þamandýra deðiþkeni oluþturacaðýz.
        if (gameObject.tag == "Player")  // sonradan ekledik kamera için kullanýyoruz.
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical") * acceleration; // burasý dikey eksende ileri veya geri ok tuþlarýna mý W ye mi týkladýðýmýzý kontrol eder. Vertical = Dikey
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");  // yatay eksende sað sol için geçerli

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;   // tekerlerin sol
                    axleInfo.rightWheel.steerAngle = steering;  // tekerlerin sað  hareket etmesini saðlar
                }

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;    // motor gücünü aktif etmek için kullanýrýz
                    axleInfo.rightWheel.motorTorque = motor;
                }

            }

            double mph = rigidbody.velocity.magnitude * 2.237; // nokta hýzý büyüklüðü ile çarpmasý
            mph = Math.Round(mph, 0); // mph en yakýn tam sayýya yuvarlayacak.
            MPH?.Invoke(mph); // MPH ý çaðýrdýðýmýz ve kontrol ettiðimiz fonksiyon.
        }

    }
}