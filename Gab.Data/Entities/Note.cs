using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GABNotes.Data.Entities {
	public class Note {
		public int NoteId { get; set; }
		public String Text { get; set; }
		public String Title { get; set; }
		public String Author { get; set; }

		public String City { get; set; }
	}
}
