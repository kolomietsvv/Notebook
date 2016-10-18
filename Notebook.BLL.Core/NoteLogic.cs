using Notebook.BLL.Interface;
using Notebook.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Notebook.BLL.Core
{
    public class NoteLogic : INoteLogic
    {

        public Dictionary<int, Note> Notes;

        public NoteLogic()
        {
            Notes = ContainerDAO.noteDAO.GetAll().ToDictionary(ent => ent.Id, ent => ent);
        }

        public Note Add(Note note)
        {
            note.Id = (Notes.Keys.Count > 0) ? Notes.Keys.Max() + 1 : 1;
            Notes.Add(note.Id, note);
            return note;
        }

        public void Delete(int id)
        {
            Notes.Remove(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes.Values;
        }

        public Note Get(int id)
        {
            return Notes[id];
        }

        public void Update(Note note)
        {
            Notes[note.Id] = note;
        }

        public void Dispose()
        {
            ContainerDAO.noteDAO.WriteAll(Notes.Values);
        }

        public void WriteAll()
        {
            ContainerDAO.noteDAO.WriteAll(Notes.Values);
        }
    }
}
