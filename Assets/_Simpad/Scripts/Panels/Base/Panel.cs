using _Simpad.Scripts.Notes;
using _Simpad.Scripts.Save;
using UnityEngine;

namespace _Simpad.Scripts.Panels.Base
{
    public abstract class Panel : MonoBehaviour
    {
        protected PanelsManager PanelsManager;
        protected NotesManager NotesManager;
        protected SaveManager SaveManager;

        public void Init(PanelsManager panelsManager, NotesManager notesManager, SaveManager saveManager)
        {
            PanelsManager = panelsManager;
            NotesManager = notesManager;
            SaveManager = saveManager;
            
            OnInit();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
        }

        protected virtual void OnInit()
        {
        }
        
        protected virtual void OnShow()
        {
        }
    
        protected virtual void OnHide()
        {
        }
    }
}