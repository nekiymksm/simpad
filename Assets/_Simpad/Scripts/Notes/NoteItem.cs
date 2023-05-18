using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Simpad.Scripts.Notes
{
    public class NoteItem : MonoBehaviour
    {
        [SerializeField] private Button _edit;
        [SerializeField] private TextMeshProUGUI _text;
        
        private NotesManager _notesManager;

        public float HeightValue { get; private set; }
        public string NoteName { get; private set; }
        public string SavedText { get; private set; }

        private void Awake()
        {
            HeightValue = GetComponent<RectTransform>().rect.height;
            _edit.onClick.AddListener(OnEditButtonClick);
        }

        private void OnDestroy()
        {
            _edit.onClick.RemoveListener(OnEditButtonClick);
        }

        public void Init(NotesManager notesManager, string noteName, string text)
        {
            _notesManager = notesManager;
            
            NoteName = noteName ?? "note" + DateTime.UtcNow.ToString("dd-MM-yyyy_hh-mm-ss");
            OnSave(text);
        }

        public void OnSave(string text)
        {
            _text.SetText(text);
            SavedText = text;
        }

        public void OnDelete()
        {
            Destroy(gameObject);
            _notesManager.OnNoteDelete();
        }

        public void OnClose()
        {
            if (SavedText == null)
            {
                OnDelete();
            }
        }

        private void OnEditButtonClick()
        {
            _notesManager.EditNote(this);
        }
    }
}