using Notebook.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.DAL.Interface
{
    public interface INoteDAO
    {
        void WriteAll(IEnumerable<Note> notes);
        IEnumerable<Note> GetAll();       
    }
}
