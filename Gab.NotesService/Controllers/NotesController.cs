using GABNotes.Data;
using GABNotes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gab.NotesService.Controllers
{
    public class NotesController : ApiController
    {
        private NotesDbContex _notesDbContext = new NotesDbContex();
        //private 
        public IEnumerable<Note> GetAllNodes()
        {
            return _notesDbContext.Notes.ToList();
        }

        public bool CreateNote(Note NewNote)
        {
            _notesDbContext.Notes.Add(NewNote);
            _notesDbContext.SaveChanges();
            return true;
        }

    }
}
