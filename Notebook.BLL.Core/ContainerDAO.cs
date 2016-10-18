using Notebook.DAL.File;
using Notebook.DAL.Interface;

namespace Notebook.BLL.Core
{
   class ContainerDAO
    {
        public INoteDAO noteDAO;
        public ContainerDAO()
        {
            noteDAO = new NoteDAO();
        }
    }
}
