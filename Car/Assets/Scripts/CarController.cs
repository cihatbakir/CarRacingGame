using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class AxleInfo // AxleInfo --> Aks bilgileri
{
    public WheelCollider leftWheel;  // sol tekerlek
    public WheelCollider rightWheel; // sa� tekerlek
    public bool motor;
    public bool steering; // steering = direksiyon

}
public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;  // Aks bilgilerini a��k bir listeye ba�lad�m.
    public float maxMotorTorque;  // max motor torku (g�c�)
    public float maxSteeringAngle; // max direksiyon a��s�
    public float acceleration; // h�zlanma
    public Camera miniMapCamera; // RaceManager dan miniMapCamera y� burada tan�mlad�k.
    public Camera mainCamera; // ana kamera
    public Rigidbody rigidbody; // kat� cisim
    public Action<double> MPH; // Araban�n sa� alt taraftaki mph g�sterimi

    void Awake()
    {
        if(gameObject.tag != "Player")
        {
            miniMapCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(true);
        }
    }


    private void FixedUpdate()  // ��levin i�erisinde fizik hesaplamalar� yapmak istedi�inizde, sabit g�ncelleme kulland���n�zdan emin olun un�ty i�inde temel kural budur.
    {
        // �ncelikle Klavyedeki oklar� kullanarak �nce ayarlayaca��m�z motor ad�nda bir �amand�ra de�i�keni olu�turaca��z.
        if (gameObject.tag == "Player")  // sonradan ekledik kamera i�in kullan�yoruz.
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical") * acceleration; // buras� dikey eksende ileri veya geri ok tu�lar�na m� W ye mi t�klad���m�z� kontrol eder. Vertical = Dikey
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");  // yatay eksende sa� sol i�in ge�erli

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;   // tekerlerin sol
                    axleInfo.rightWheel.steerAngle = steering;  // tekerlerin sa�  hareket etmesini sa�lar
                }

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;    // motor g�c�n� aktif etmek i�in kullan�r�z
                    axleInfo.rightWheel.motorTorque = motor;
                }

            }

            double mph = rigidbody.velocity.magnitude * 2.237; // nokta h�z� b�y�kl��� ile �arpmas�
            mph = Math.Round(mph, 0); // mph en yak�n tam say�ya yuvarlayacak.
            MPH?.Invoke(mph); // MPH � �a��rd���m�z ve kontrol etti�imiz fonksiyon.
        }

    }
}