using Notebook.Common.Entities;
using Notebook.DAL.Interface;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Notebook.DAL.File
{
    public class NoteDAO : INoteDAO
    {
        private static string _filePath = ConfigurationManager.ConnectionStrings["file"].ConnectionString;
        private static string _fieldSeparator = ConfigurationManager.AppSettings["fieldSeparator"];
        private static readonly string _fileHeader = "id" + _fieldSeparator + "Surname" +
            _fieldSeparator + "Name" + _fieldSeparator + "YearOfBirth" + _fieldSeparator + "PhoneNumber";
        private static int maxId = 0;

        public NoteDAO()
        {
            if (!System.IO.File.Exists(_filePath))
                System.IO.File.WriteAllLines(_filePath, new string[]{_fileHeader});
        }

        public void WriteAll(IEnumerable<Note> notes)
        {
            System.IO.File.WriteAllLines(_filePath, new string[] { _fileHeader });
            System.IO.File.AppendAllLines(_filePath, notes.Select(note => note.ToString(_fieldSeparator)));
        }

        public IEnumerable<Note> GetAll()
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(new string[] { _fieldSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    yield return new Note()
                    {
                        Id = int.Parse(fields[0]),
                        Surname = fields[1],
                        Name = fields[2],
                        YearOfBirth = int.Parse(fields[3]),
                        PhoneNumber = fields[4]
                    };
                }
            }
        }
    }
}
