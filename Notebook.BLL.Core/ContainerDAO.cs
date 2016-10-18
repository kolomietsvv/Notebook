using Notebook.DAL.File;
using Notebook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.BLL.Core
{
   static class ContainerDAO
    {
        public static INoteDAO noteDAO;
        static ContainerDAO()
        {
            noteDAO = new NoteDAO();
        }
    }
}
