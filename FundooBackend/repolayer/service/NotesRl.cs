using commonlayer.Model;
using Microsoft.Extensions.Configuration;
using repolayer.Context;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repolayer.service
{
    public class NotesRl : INoteRl
    {
        FundooContext fundooContext;

        public NotesRl(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public NoteEntity CreateNote(CreateNote note, long id)
        {

            try
            {

                NoteEntity noteEntity = new NoteEntity();
                noteEntity.userid = id;
                noteEntity.title = note.title;
                noteEntity.description = note.description;

                fundooContext.NotesTable.Add(noteEntity);

                int result = fundooContext.SaveChanges();

                if (result > 0)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }
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
                //var noteCheck = fundooContext.NotesTable.SingleOrDefault(e => e.noteid == id);
                //var noteList = fundooContext.NotesTable.Where(e => e.noteid == id).ToList();

                try
                {

                    if (id != null)
                    {
                        NoteEntity note = fundooContext.NotesTable.Where(e => e.noteid == id).FirstOrDefault();

                        if (note.isDeleted == false)
                        {
                            note.isDeleted = true;
                        }
                        else if (note.isDeleted == true)
                        {
                            note.isDeleted = false;
                        }

                        fundooContext.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                   
                }
                catch (Exception)
                {

                    throw;
                }

                //if (noteList != null)
                //{
                //    return fundooContext.NotesTable.SingleOrDefault(d=> d.isDeleted== true);

                //}
                //else
                //{
                //    return fundooContext.NotesTable.SingleOrDefault(d => d.isDeleted == false);
                //}
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
                //var DataList = fundooContext.NotesTable.Where(x => x.noteid==id && x.isDeleted != true).ToList();

                if (title != null && description != null)
                {
                    NoteEntity note = fundooContext.NotesTable.Where(e => e.noteid == id).FirstOrDefault();
                    note.title = title;
                    note.description = description;
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public IEnumerable<NoteEntity> GetAllNotes()
        {
            try
            {
                return fundooContext.NotesTable.Where(x => x.isDeleted == false).ToList();
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
                return fundooContext.NotesTable.Where(x => x.noteid == id).FirstOrDefault();
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

                if (id != null)
                {
                    NoteEntity note = fundooContext.NotesTable.Where(e => e.noteid == id && e.isDeleted != true).FirstOrDefault();

                    if (note.isArchived == false)
                    {
                        note.isArchived = true;
                    }
                    else if (note.isArchived == true)
                    {
                        note.isArchived = false;
                    }

                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool PinNote(long id)
        {
            try
            {

                if (id != null)
                {
                    NoteEntity note = fundooContext.NotesTable.Where(e => e.noteid == id && e.isDeleted != true).FirstOrDefault();
                    if (note.isPinned == false)
                    {
                        note.isPinned = true;
                    }
                    else if (note.isPinned == true)
                    {
                        note.isPinned = false;
                    }
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool PermanentDelete(long id)
        {
            try
            {
                
                try
                {

                    if (id != null)
                    {
                        NoteEntity note = fundooContext.NotesTable.Where(e => e.noteid == id).FirstOrDefault();
                        fundooContext.Remove(note);
                        fundooContext.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {

                    throw;
                }

             
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
