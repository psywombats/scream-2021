﻿using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeakboxComponent : TextAutotyper {

    private static readonly string SystemSpeaker = "SYSTEM";

    [SerializeField] private float animationSeconds = 0.2f;
    [Space]
    [SerializeField] private TextMeshProUGUI namebox = null;
    [SerializeField] private RectTransform mainBox = null;
    [SerializeField] private Image portraitImage = null;
    [SerializeField] private RectTransform tailTrans = null;
    [SerializeField] private RectTransform topTailTrans = null;
    [SerializeField] private RectTransform boxTrans = null;
    [SerializeField] private RectTransform portraitTrans = null;
    [Space]
    [SerializeField] private Vector2 margin = new Vector2(340, 48);
    [SerializeField] private Vector2 tailMargin = new Vector2(64, 48);

    public bool isDisplaying { get; private set; }

    private Vector3 pos = Vector3.zero;
    private PortraitData portrait = null;

    public void Start() {
        textbox.text = "";
        GetComponent<CanvasGroup>().alpha = 0f;
        advanceArrow.SetActive(false);
    }

    public IEnumerator SetupForPos(Vector3 pos, float duration) {
        var screen = MapManager.Instance.Camera.GetCameraComponent().WorldToScreenPoint(pos);
        var rect = GetComponent<RectTransform>();

        if (pos == Vector3.zero) {
            screen = new Vector2(640, 72);
        }
        var boxX = Mathf.Clamp(screen.x, margin.x, 1280 - margin.x);
        var boxY = Mathf.Clamp(screen.y, margin.y, 1280 - margin.y);
        var tailX = Mathf.Clamp(screen.x, tailMargin.x, 1280 - tailMargin.x);
        var tailY = Mathf.Clamp(screen.y, tailMargin.y, 1280 - tailMargin.y);

        yield return CoUtils.RunParallel(new IEnumerator[] {
            CoUtils.RunTween(boxTrans.DOAnchorPos(new Vector2(boxX, boxY), duration)),
            CoUtils.RunTween(tailTrans.DOAnchorPos(new Vector2(tailX, tailY), duration)),
            CoUtils.RunTween(topTailTrans.DOAnchorPos(new Vector2(tailX, tailY), duration)),
            CoUtils.RunTween(tailTrans.GetComponent<CanvasGroup>().DOFade(screen.y > 96 ? 1 : 0, duration)),
            CoUtils.RunTween(topTailTrans.GetComponent<CanvasGroup>().DOFade(screen.y <= 96 ? 1 : 0, duration)),
        }, this);
    }

    public void MarkHiding() {
        isDisplaying = false;
    }

    public IEnumerator TestRoutine() {
        isDisplaying = true;
        while (true) {
            yield return DisableRoutine();
            yield return CoUtils.Wait(1.0f);
            yield return SpeakRoutine("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do " +
                "eiusmod tempor incididunt ut labore et dolore magna aliqua.");
            yield return SpeakRoutine("Diaghilev", "Or thus spake the ancestors.", new Vector3(5, 4, 5));
            yield return SpeakRoutine("Diaghilev", "Etc.", new Vector3(5, 4, 5));
            yield return SpeakRoutine("Homasa", "Hello I am someone completely different", new Vector3(8, 4, 6));
            yield return SpeakRoutine("eom");
        }
    }

    public IEnumerator SpeakRoutine(string text, Vector3 worldPos) => SpeakRoutine(SystemSpeaker, text, worldPos);
    public IEnumerator SpeakRoutine(string text) => SpeakRoutine(SystemSpeaker, text, Vector3.zero);
    public IEnumerator SpeakRoutine(string speakerName, string text) => SpeakRoutine(speakerName, text, Vector3.zero);
    public IEnumerator SpeakRoutine(string speakerName, string text, Vector3 worldPos, PortraitData portrait = null) {
        if (text == null || text.Length == 0) {
            text = speakerName;
            speakerName = SystemSpeaker;
        }
        if (speakerName == SystemSpeaker) {
            SetNameboxEnabled(false);
        }
        if (!isDisplaying) {
            pos = worldPos;
            yield return SetupForPos(pos, 0f);
            if (speakerName == SystemSpeaker) {
                SetNameboxEnabled(false);
            }
            namebox.text = speakerName;
            namebox.GetComponent<CanvasGroup>().alpha = 1f;

            if (speakerName != SystemSpeaker) {
                SetNameboxEnabled(true);
            }
            
            StartCoroutine(HandlePortraitRoutine(portrait, 0f));

            yield return EnableRoutine();
        } else {
            StartCoroutine(HandlePortraitRoutine(portrait, animationSeconds / 2f));
            if (pos != worldPos) {
                pos = worldPos;
                yield return CoUtils.RunParallel(new IEnumerator[] {
                    EraseNameRoutine(animationSeconds / 2.0f),
                    EraseTextRoutine(animationSeconds / 2.0f),
                }, this);
                yield return SetupForPos(pos, .6f);
            } else {
                yield return EraseTextRoutine(animationSeconds / 2.0f);
            }
            if (namebox.text != speakerName && speakerName != SystemSpeaker) {
                namebox.GetComponent<CanvasGroup>().alpha = 1f;
                namebox.text = speakerName;
            }
        }
        if (speakerName == SystemSpeaker) {
            namebox.text = "";
        }

        textbox.GetComponent<CanvasGroup>().alpha = 1f;
        yield return TypeRoutine(text);
    }

    private IEnumerator EnableRoutine() {
        isDisplaying = true;
        Global.Instance.Input.PushListener(this);

        yield return CoUtils.RunParallel(new IEnumerator[] {
            ShowMainBoxRoutine(animationSeconds),
            SetupForPos(pos, animationSeconds),
        }, this);
    }
    public IEnumerator DisableRoutine() {
        isDisplaying = false;
        yield return CoUtils.RunParallel(new IEnumerator[] {
            EraseNameRoutine(animationSeconds / 2.0f),
            EraseTextRoutine(animationSeconds / 2.0f),
            CloseMainBoxRoutine(animationSeconds),
        }, this);
        SetupPortrait(null);
        Global.Instance.Input.RemoveListener(this);
    }

    protected virtual void SetNameboxEnabled(bool enabled) {
        namebox.enabled = enabled;
    }
    protected virtual bool IsNameboxEnabled() {
        return namebox.enabled;
    }

    protected virtual IEnumerator EraseTextRoutine(float seconds) {
        yield return CoUtils.RunTween(textbox.GetComponent<CanvasGroup>().DOFade(0.0f, seconds));
    }
    protected virtual IEnumerator EraseNameRoutine(float seconds) {
        yield return CoUtils.RunTween(namebox.GetComponent<CanvasGroup>().DOFade(0.0f, seconds));
    }

    protected virtual IEnumerator ShowMainBoxRoutine(float seconds) {
        yield return CoUtils.RunParallel(new IEnumerator[] {
            CoUtils.RunTween(GetComponent<CanvasGroup>().DOFade(1f, seconds)),
            CoUtils.RunTween(mainBox.DOLocalMoveY(mainBox.localPosition.y + 12f, seconds, true))
        }, this);
    }
    protected virtual IEnumerator CloseMainBoxRoutine(float seconds) {
        yield return CoUtils.RunParallel(new IEnumerator[] {
            CoUtils.RunTween(GetComponent<CanvasGroup>().DOFade(0f, seconds)),
            CoUtils.RunTween(mainBox.DOLocalMoveY(mainBox.localPosition.y - 12f, seconds, true))
        }, this);
    }

    private IEnumerator HandlePortraitRoutine(PortraitData data, float duration) {
        if (data != portrait) {
            if (portrait != null) {
                yield return CoUtils.RunTween(portraitTrans.GetComponent<CanvasGroup>().DOFade(0f, duration));
            }
            portraitTrans.GetComponent<CanvasGroup>().alpha = 0f;
            SetupPortrait(data);
            if (data != null) {
                yield return CoUtils.RunTween(portraitTrans.GetComponent<CanvasGroup>().DOFade(1f, duration));
            }
        }
    }

    private void SetupPortrait(PortraitData data) {
        portrait = data;
        if (data != null) {
            portraitImage.sprite = data.portrait;
        } else {
            portraitTrans.GetComponent<CanvasGroup>().alpha = 0f;
        }
        portraitTrans.anchoredPosition = new Vector2(0, data == null ? 0 : data.offset);
        portraitImage.SetNativeSize();
    }
}