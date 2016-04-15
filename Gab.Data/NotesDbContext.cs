using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GABNotes.Data.Entities;

namespace GABNotes.Data {
	public class NotesDbContex: DbContext {
		public DbSet<Note> Notes { get; set; }

        //AzureSampleDb
        public NotesDbContex(): base(System.Configuration.ConfigurationManager.ConnectionStrings["AzureSampleDb"].ConnectionString)
        {
        }
	}
}
