using _Simpad.Scripts.Notes;
using _Simpad.Scripts.Panels.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Simpad.Scripts.Panels
{
    public class MainPanel : Panel
    {
        [SerializeField] private Button _newNoteButton;
        [SerializeField] private VerticalLayoutGroup _contentVerticalLayoutGroup;
        
        private RectTransform _contentRectTransform;

        private void Awake()
        {
            _contentRectTransform = _contentVerticalLayoutGroup.GetComponent<RectTransform>();
            _newNoteButton.onClick.AddListener(OnNewNoteButtonClick);
        }

        private void OnDestroy()
        {
            _newNoteButton.onClick.RemoveListener(OnNewNoteButtonClick);
            
            NotesManager.NoteItemCreated -= OnNoteCreated;
            NotesManager.NoteItemDeleted -= OnNoteDeleted;
        }

        protected override void OnInit()
        {
            NotesManager.NoteItemCreated += OnNoteCreated;
            NotesManager.NoteItemDeleted += OnNoteDeleted;
        }

        private void OnNewNoteButtonClick()
        {
            NotesManager.NewNote();
        }

        private void OnNoteCreated(NoteItem noteItem)
        {
            noteItem.transform.SetParent(_contentRectTransform, false);
            SetContentSize(noteItem.HeightValue + _contentVerticalLayoutGroup.spacing);
        }

        private void OnNoteDeleted(NoteItem noteItem)
        {
            SetContentSize((noteItem.HeightValue + _contentVerticalLayoutGroup.spacing) * -1);
        }
        
        private void SetContentSize(float modifierValue)
        {
            _contentRectTransform.sizeDelta 
                = new Vector2(0, _contentRectTransform.rect.height + modifierValue);
        }
    }
}