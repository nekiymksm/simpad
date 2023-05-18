using System.Collections.Generic;
using System.IO;
using _Simpad.Scripts.Notes;
using UnityEngine;

namespace _Simpad.Scripts.Save
{
    public class SaveManager
    {
        private DirectoryInfo _directoryInfo;
        private string _directoryPath;
        
        public NotesInfo NotesData { get; }

        public SaveManager()
        {
            _directoryPath = Application.persistentDataPath + "/notes/";
            _directoryInfo = new DirectoryInfo(_directoryPath);
            
            NotesData = new NotesInfo();
            NotesData.data = new List<NoteData>();
        }
        
        public void SaveNote(string fileName, string text)
        {
            if (Directory.Exists(_directoryPath) == false)
            {
                _directoryInfo.Create();
            }

            NoteData noteData = new NoteData();
            NotesData.data.Add(noteData);
            noteData.name = fileName;
            noteData.text = text;

            File.WriteAllText(_directoryPath + $"/{fileName}.json", JsonUtility.ToJson(noteData));
        }
        
        public bool CanLoadNotes()
        {
            if (Directory.Exists(_directoryPath))
            {
                var files = _directoryInfo.GetFiles();
                
                if (files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileText = File.ReadAllText(files[i].FullName);
                        NotesData.data.Add(JsonUtility.FromJson<NoteData>(fileText));
                    }
                    
                    return true;
                }
            }

            return false;
        }

        public void DeleteNote(string fileName)
        {
            string path = _directoryPath + $"/{fileName}.json";
            
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}