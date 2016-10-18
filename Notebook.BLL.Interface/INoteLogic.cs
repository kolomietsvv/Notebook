using Notebook.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.BLL.Interface
{
    public interface INoteLogic:IDisposable
    {
        void WriteAll();
        Note Add(Note note);
        void Update(Note note);
        void Delete(int id);
        IEnumerable<Note> GetAll();
        Note Get(int id);
    }
}
