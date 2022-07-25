﻿using commonlayer.Model;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.Interface
{
    public interface INoteBl
    {
        public NoteEntity CreatNote(CreateNote note, long id);
        public bool UpdateNote(long id, string title, string description);
        public bool DeleteNote(long id);
        public IEnumerable<NoteEntity> GetAllNotes();

        public bool ArchiveNote(long id);
        public bool PinNote(long id);
        public bool PermanentDelete(long id);
        public NoteEntity GetNotesById(long id);
    }
}
