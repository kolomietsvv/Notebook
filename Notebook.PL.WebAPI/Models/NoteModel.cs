using Notebook.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Notebook.PL.WebAPI.Models
{
    class YearRange : RangeAttribute
    {
        public YearRange()
            : base(typeof(int),
                   "1875",
                    DateTime.Now.Year.ToString())
        { }
    }

    public class NoteModel
    {
        public int? Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [YearRange]
        public int YearOfBirth { get; set; }
        [Required]
        [RegularExpression(@"\+?[0-9]{2,11}")]
        public string PhoneNumber { get; set; }

        public static void AddAll()
        {
            ContainerLogic.noteLogic.WriteAll();
        }

        public static Note Update(NoteModel note)
        {
            var ent = new Note()
            {
                Id = note.Id.Value,
                Name = note.Name,
                Surname = note.Surname,
                PhoneNumber = note.PhoneNumber,
                YearOfBirth = note.YearOfBirth
            };
            ContainerLogic.noteLogic.Update(ent);
            return ent;
        }

        public static void WriteAll()
        {
            ContainerLogic.noteLogic.WriteAll();
        }

        public static NoteModel Add(NoteModel note)
        {
            var ent = ContainerLogic.noteLogic.Add(new Note()
            {
                Name = note.Name,
                Surname = note.Surname,
                PhoneNumber = note.PhoneNumber,
                YearOfBirth = note.YearOfBirth
            });
            return new NoteModel()
            {
                Id = ent.Id,
                Surname = ent.Surname,
                Name = ent.Name,
                PhoneNumber = ent.PhoneNumber,
                YearOfBirth = ent.YearOfBirth
            };
        }

        public static void Delete(int id)
        {
            ContainerLogic.noteLogic.Delete(id);
        }

        public static IEnumerable<NoteModel> GetAll()
        {
            return ContainerLogic.noteLogic.GetAll().Select(
                ent => new NoteModel()
                {
                    Id = ent.Id,
                    Surname = ent.Surname,
                    Name = ent.Name,
                    PhoneNumber = ent.PhoneNumber,
                    YearOfBirth = ent.YearOfBirth
                });
        }

        public static NoteModel Get(int id)
        {

            var ent = ContainerLogic.noteLogic.Get(id);
            return new NoteModel()
            {
                Id = ent.Id,
                Surname = ent.Surname,
                Name = ent.Name,
                PhoneNumber = ent.PhoneNumber,
                YearOfBirth = ent.YearOfBirth
            };
        }

    }
}