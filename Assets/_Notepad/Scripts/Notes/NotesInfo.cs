using System;
using System.Collections.Generic;

namespace _Notepad.Scripts.Notes
{
    [Serializable]
    public class NotesInfo
    {
        public List<NoteData> data;
    }
    
    [Serializable]
    public class NoteData
    {
        public string name;
        public string text;
    }
}