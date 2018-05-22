using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Импорт инфраструктуры для работы с кодом UI 


public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel; // Обьект сцены Reference Text, предназначеный для создания свойства text
	[SerializeField] private SettingsPopup settingsPopup;


	/*void Update () {
		scoreLabel.text = Time.realtimeSinceStartup.ToString (); отображалось время игры вместо счёта, тестовый кусок кода
	}*/ 
	public void OnPointerDown () 
	{
		Debug.Log ("pointer down");
	}
	public void OnOpenSettings() { // метод вызываемый кнопкой настроек 
		settingsPopup.Open(); // Заменяем отладочный текст методом всплывающего окна	Debug.Log ("open settings");
	}
	private int _score;

	void Awake()
	{
		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit); // Объявляем, какой метод отвечает на событие ENEMY_HIT
	}
	void OnDestroy()
	{
		Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit); // При разрушении объекта удаляйте подписчика, чтобы избежать ошибок.
	}
		
	void Start()
	{
		_score = 0;
		scoreLabel.text = _score.ToString (); // Присвоение переменной score начального значения 0.
		settingsPopup.Close ();
	}
	private void OnEnemyHit()
	{
		_score += 1; // Увеличение переменной score на 1 в ответ на данное событие.
		scoreLabel.text = _score.ToString();
	}
}
