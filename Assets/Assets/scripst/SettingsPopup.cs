using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
	[SerializeField] private Slider speedSlider;
	void Start()
	{
		speedSlider.value = PlayerPrefs.GetFloat ("speed", 1);
	}
	public void OnSubmitName(string name)  // Этот метод срабатывает в момент начала ввода данных в текстовом поле
	{
		Debug.Log (name);
	}
	public void OnSpeedValue(float speed) // Этот метод срабатывает при изменении положения ползунка
	{
		Messenger<float>.Broadcast (GameEvent.SPEED_CHANGED, speed); // значение, заданное положением ползунка, рассылается как событие <float>
		//Debug.Log ("Speed: " + speed);
	}
	public void Open()
	{
		gameObject.SetActive (true); //активируете этот объект, чтобы открыть окно
	}
	public void Close()
	{
		gameObject.SetActive (false); //деативируете обЪект, чтобы закрыть окно

	}
}
