using businesslayer.Interface;
using commonlayer.Model;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.service
{
    public class NoteBl : INoteBl
    {
        INoteRl iNoteRl;
        public NoteBl(INoteRl iNoteRl)
        {
            this.iNoteRl = iNoteRl;
        }
        public NoteEntity CreatNote(CreateNote note, long id)
        {
            try
            {
                return iNoteRl.CreateNote( note, id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteNote(long id)
        {
            try
            {
                return iNoteRl.DeleteNote(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<NoteEntity> GetAllNotes()
        {
            try
            {
                return iNoteRl.GetAllNotes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateNote(long id, string title, string description)
        {
            try
            {
                return iNoteRl.UpdateNote(id, title,description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ArchiveNote(long id)
        {
            try
            {
                return iNoteRl.ArchiveNote(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool PinNote(long id)
        {
            try
            {
                return iNoteRl.PinNote(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool PermanentDelete(long id)
        {
            try
            {
                return iNoteRl.PermanentDelete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public NoteEntity GetNotesById(long id)
        {
            try
            {
                return (NoteEntity)iNoteRl.GetNotesById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
