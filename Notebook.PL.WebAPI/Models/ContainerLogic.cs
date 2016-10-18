using Notebook.BLL.Core;
using Notebook.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notebook.PL.WebAPI.Models
{
    static class ContainerLogic
    {
        public static INoteLogic noteLogic;
        static ContainerLogic()
        {
            noteLogic = new NoteLogic();
        }
    }
}