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
        private Dictionary<int, Note> notes;
        private ContainerDAO containerDAO;

        public NoteLogic()
        {
            containerDAO = new ContainerDAO();
            notes = containerDAO.noteDAO.GetAll().ToDictionary(ent => ent.Id, ent => ent);
        }

        public Note Add(Note note)
        {
            note.Id = (notes.Keys.Count > 0) ? notes.Keys.Max() + 1 : 1;
            notes.Add(note.Id, note);
            return note;
        }

        public void Delete(int id)
        {
            notes.Remove(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return notes.Values;
        }

        public Note Get(int id)
        {
            return notes[id];
        }

        public void Update(Note note)
        {
            notes[note.Id] = note;
        }

        public void Dispose()
        {
            containerDAO.noteDAO.WriteAll(notes.Values);
        }

        public void WriteAll()
        {
            containerDAO.noteDAO.WriteAll(notes.Values);
        }
    }
}
