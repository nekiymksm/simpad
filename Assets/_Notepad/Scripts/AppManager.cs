using _Notepad.Scripts.Notes;
using _Notepad.Scripts.Panels.Base;
using _Notepad.Scripts.Save;
using UnityEngine;

namespace _Notepad.Scripts
{
    public class AppManager : MonoBehaviour
    {
        [SerializeField] private NoteItem _noteItemPrefab;
        [SerializeField] private PanelsManager _panelsManager;

        private SaveManager _saveManager;
        private NotesManager _notesManager;

        private void Awake()
        {
            _saveManager = new SaveManager();
            _notesManager = new NotesManager(_saveManager, _noteItemPrefab);
            
            _panelsManager.Init(_notesManager, _saveManager);
        }

        private void Start()
        {
            _notesManager.TryLoadNotes();
        }
    }
}