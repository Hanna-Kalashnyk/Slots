using System;
using CSFramework;
using DG.Tweening;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Elona.Slot {
	/// <summary>
	/// A main class for Elona Slot(Demo) derived from BaseSlotGame.
	/// For the most part, it's overriding the base methods to add visual/audio effects.
	/// </summary>
	public class Elos : MonoBehaviour {
		public CustomSlot slot;

        private bool keepPlaying = false;

        [SerializeField]
        private Button _dontStopButtonBackground;


		[SerializeField]
		private GameObject _popupPrefab;


		[Serializable]
		public class Assets {
			[Serializable]
			public class Tweens {
				public TweenSprite tsBonus, tsIntro1, tsIntro2, tsWin, tsWinSpecial;
			}

			public Tweens tweens;
			public AudioSource bgm, audioDemo, audioEarnSmall, audioEarnBig, audioPay, audioSpin, audioSpinLoop, audioReelStop, audioClick;
			public AudioSource audioWinSmall, audioWinMedium, audioWinBig, audioLose, audioBet, audioImpact, audioBeep;
			public AudioSource audioBonus, audioWinSpecial, audioSpinBonus;
			public ParticleSystem particlePay, particlePrize, particleFreeSpin;
			public ElosEffectMoney effectMoney;
			public ElosEffectBalloon effectBalloon;
		}

		[Serializable]
		public class ElonaSlotData {
			public int expNext = 100;
			public int lv = 1;
			public int exp;
		}

		[Serializable]
		public class ElonaSlotSetting {
			public bool allowDebt = true;
		}

		public Assets assets;
		public ElonaSlotData data;
		public ElonaSlotSetting setting;
		public ElosUI ui;
		public ElosBonusGame bonusGame;
		public float transitionTime = 3f;
		public CanvasGroup cg;
		public GameObject mold;

		protected void Awake() {
			slot.callbacks.onRoundComplete.AddListener(CheckLevelUp);
			slot.callbacks.onRoundComplete.AddListener(Save);
			slot.callbacks.onReelStart.AddListener(OnReelStart);
			slot.callbacks.onProcessHit.AddListener(OnProcessHit);
			Initialize();
		}

		public void Initialize() {
			mold.gameObject.SetActive(false);
			if (!slot.debug.skipIntro) {
				cg.alpha = 0;
				cg.DOFade(1f, transitionTime*0.5f).SetDelay(transitionTime*0.5f);
			}
		}
		private float waitBetweenGames;

		private void Update() {
			if (slot.debug.useDebugKeys) {
				if (Input.GetKeyDown(KeyCode.Alpha1)) assets.tweens.tsBonus.Play(0);
				if (Input.GetKeyDown(KeyCode.Alpha2)) assets.tweens.tsWinSpecial.Play(0);
				if (Input.GetKeyDown(KeyCode.Alpha3)) assets.tweens.tsIntro1.Play(0);
				if (Input.GetKeyDown(KeyCode.Alpha4)) assets.tweens.tsIntro2.Play(0);
				if (Input.GetKeyDown(KeyCode.F10)) slot.AddEvent(new SlotEvent(bonusGame.Activate));
			}
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
			}

			if (keepPlaying && slot.state == CustomSlot.State.Idle &&  Time.time - waitBetweenGames > 1f) {				
				StartCoroutine (GoEndless ());
			} else {
				StopCoroutine (GoEndless ());
				CoroutineManager.Instance.StopAllCoroutines ();
			}
		}

		public void Play() {
			if (slot.state == CustomSlot.State.Idle && slot.gameInfo.balance < slot.gameInfo.roundCost) {
				assets.audioBeep.Play();
				return;
			}
            if(keepPlaying) {
                keepPlaying = false;
				_dontStopButtonBackground.GetComponentInChildren<Text>().text = "AUTO\n SPIN";
            }
			slot.Play();
		}

        public void KeepPlaying()
		{            
            if(keepPlaying) {
                Debug.Log("Keep playing cancelled");
                keepPlaying = false;    
                _dontStopButtonBackground.GetComponentInChildren<Text>().text = "AUTO\n SPIN";
            } else {
                Debug.Log("Keep playing going on");
                keepPlaying = true;
				_dontStopButtonBackground.GetComponentInChildren<Text>().text = "STOP";
            }				
        }

        IEnumerator GoEndless()
        {            
            yield return new WaitUntil(() => slot.state == CustomSlot.State.Idle);
			if (slot.gameInfo.balance > slot.gameInfo.roundCost) {				
				slot.Play ();
				StartCoroutine (setUpTimeForGameEnd());
			} else {
				keepPlaying = false;    
			}
        }

		IEnumerator setUpTimeForGameEnd() {
			yield return new WaitUntil(() => slot.state == CustomSlot.State.Idle);
			waitBetweenGames = Time.time;
		}

		public void OnReelStart(ReelInfo info) { if (info.isFirstReel) AddExp(slot.lineManager.activeLines); }

		public void OnProcessHit(HitInfo info) {
			AddExp(info.hitChains);
			if (info.hitSymbol.payType == Symbol.PayType.Custom) slot.AddEvent(new SlotEvent(bonusGame.Activate));

		}

		public void AddExp(int amount = 0) {
			data.exp += amount;
			ui.RefreshExp();
		}

		public void CheckLevelUp() {
			if (data.exp >= data.expNext) {
				data.lv++;
				data.exp = 0;
				data.expNext *= 2;
				ui.RefreshExp();

				slot.AddEvent(3, () => {
					assets.tweens.tsWinSpecial.SetText("Level Up!").Play();
					slot.gameInfo.AddBalance(1000);
				});
			}
		}

		public void Save() { Save("game1"); }

		public void Save(string id) {
			//PlayerPrefs.SetInt(id + "_balance", slot.gameInfo.balance);
			PlayerPrefs.SetInt(id + "_lv", data.lv);
			PlayerPrefs.SetInt(id + "_exp", data.exp);
			PlayerPrefs.SetInt(id + "_expNext", data.expNext);
			PlayerPrefs.Save();
		}

		public void Load() { Load("game1"); }

		public void Load(string id) {
			//slot.gameInfo.balance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE)
			data.lv = PlayerPrefs.GetInt(id + "_lv", data.lv);
			data.exp = PlayerPrefs.GetInt(id + "_exp", data.exp);
			data.expNext = PlayerPrefs.GetInt(id + "_expNext", data.expNext);
		}

		public void DeleteSave(string id) {
			//PlayerPrefs.DeleteKey(id + "_balance");
			PlayerPrefs.DeleteKey(id + "_lv");
			PlayerPrefs.DeleteKey(id + "_exp");
			PlayerPrefs.DeleteKey(id + "_expNext");
		}
	}
}