using _Simpad.Scripts.Notes;
using _Simpad.Scripts.Panels.Base;
using _Simpad.Scripts.Save;
using UnityEngine;

namespace _Simpad.Scripts
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