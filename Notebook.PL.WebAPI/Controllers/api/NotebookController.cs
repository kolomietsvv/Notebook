using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using Notebook.PL.WebAPI.Models;

namespace Notebook.PL.WebAPI.Controllers.api
{
    public class NotebookController : ApiController
    {
        [HttpPatch]
        public IHttpActionResult BeforeLive()
        {
            NoteModel.WriteAll();
            return Ok("saved");
        }

        public IHttpActionResult Get()
        {
            var result = NoteModel.GetAll();
            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = NoteModel.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                var result = NoteModel.Add(noteModel);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                var result = NoteModel.Update(noteModel);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            NoteModel.Delete(id);
            return Ok();
        }

    }
}
