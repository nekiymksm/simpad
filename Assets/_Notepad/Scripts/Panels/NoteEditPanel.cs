using _Notepad.Scripts.Notes;
using _Notepad.Scripts.Panels.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Notepad.Scripts.Panels
{
    public class NoteEditPanel : Panel
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _save;
        [SerializeField] private Button _delete;
        [SerializeField] private Button _close;

        private NoteItem _currentNoteItem;

        private void Awake()
        {
            _save.onClick.AddListener(OnSaveButtonClick);
            _delete.onClick.AddListener(OnDeleteButtonClick);
            _close.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDestroy()
        {
            _save.onClick.RemoveListener(OnSaveButtonClick);
            _delete.onClick.RemoveListener(OnDeleteButtonClick);
            _close.onClick.RemoveListener(OnCloseButtonClick);
            
            NotesManager.StartNoteEdit -= OnNoteEditStart;
        }

        protected override void OnInit()
        {
            NotesManager.StartNoteEdit += OnNoteEditStart;
        }

        protected override void OnShow()
        {
            PanelsManager.GetPanel<MainPanel>().Hide();
            _inputField.ActivateInputField();
        }

        protected override void OnHide()
        {
            PanelsManager.GetPanel<MainPanel>().Show();
        }

        private void OnSaveButtonClick()
        {
            SaveManager.SaveNote(_currentNoteItem.NoteName, _inputField.text);
            _currentNoteItem.OnSave(_inputField.text);
            
            Hide();
        }
    
        private void OnDeleteButtonClick()
        {
            SaveManager.DeleteNote(_currentNoteItem.NoteName);
            _currentNoteItem.OnDelete();
            
            Hide();
        }
        
        private void OnCloseButtonClick()
        {
            _currentNoteItem.OnClose();
            
            Hide();
        }

        private void OnNoteEditStart(NoteItem noteItem)
        {
            _currentNoteItem = noteItem;
            _inputField.text = noteItem.SavedText;
            
            Show();
        }
    }
}