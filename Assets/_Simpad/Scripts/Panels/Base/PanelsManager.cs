using _Simpad.Scripts.Notes;
using _Simpad.Scripts.Save;
using UnityEngine;

namespace _Simpad.Scripts.Panels.Base
{
    public class PanelsManager : MonoBehaviour
    {
        [SerializeField] private Panel[] _panels;
        
        private NotesManager _notesManager;
        private SaveManager _saveManager;
        
        public void Init(NotesManager notesManager, SaveManager saveManager)
        {
            _notesManager = notesManager;
            _saveManager = saveManager;

            InitPanels();
            GetPanel<MainPanel>().Show();
        }

        public T GetPanel<T>() where T : Panel
        {
            for (int i = 0; i < _panels.Length; i++)
            {
                if (_panels[i].GetType() == typeof(T))
                {
                    return _panels[i] as T;
                }
            }

            return null;
        }

        private void InitPanels()
        {
            for (int i = 0; i < _panels.Length; i++)
            {
                _panels[i].Init(this, _notesManager, _saveManager);
            }
        }
    }
}