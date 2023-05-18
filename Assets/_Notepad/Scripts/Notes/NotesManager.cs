using System;
using _Notepad.Scripts.Save;
using Object = UnityEngine.Object;

namespace _Notepad.Scripts.Notes
{
    public class NotesManager
    {
        private SaveManager _saveManager;
        private NoteItem _noteItemPrefab;
        private NoteItem _currentNoteItem;

        public event Action<NoteItem> NoteItemCreated;
        public event Action<NoteItem> NoteItemDeleted;
        public event Action<NoteItem> StartNoteEdit; 

        public NotesManager(SaveManager saveManager, NoteItem noteItemPrefab)
        {
            _saveManager = saveManager;
            _noteItemPrefab = noteItemPrefab;
        }

        public void NewNote()
        {
            CreateNote();
            _currentNoteItem.Init(this, null, null);
            
            EditNote(_currentNoteItem);
        }

        public void EditNote(NoteItem noteItem)
        {
            _currentNoteItem = noteItem;
            StartNoteEdit?.Invoke(noteItem);
        }

        public void OnNoteDelete()
        {
            NoteItemDeleted?.Invoke(_currentNoteItem);
        }

        public void TryLoadNotes()
        {
            if (_saveManager.CanLoadNotes())
            {
                var notesInfo = _saveManager.NotesData.data;
                
                for (int i = 0; i < notesInfo.Count; i++)
                {
                    CreateNote();
                    _currentNoteItem.Init(this, notesInfo[i].name, notesInfo[i].text);
                }
            }
        }

        private void CreateNote()
        {
            _currentNoteItem = Object.Instantiate(_noteItemPrefab);
            NoteItemCreated?.Invoke(_currentNoteItem);
        }
    }
}