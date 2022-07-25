using businesslayer.Interface;
using commonlayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class NotesController : ControllerBase
    {
        INoteBl noteBl;

        public NotesController(INoteBl noteBl)
        {
            this.noteBl = noteBl;
        }

        
        [HttpPost("addNote")]
        
        
        public IActionResult CreateNote(CreateNote note)
        {
            try
            {
                long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
                var result = noteBl.CreatNote(note, id);

                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Note Created Successfully!!!",
                        response = result
                    });

                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "something went wrong..",

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("trash")]

        public IActionResult DeleteNote(long id)
        {
            //id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
            bool isDeleteNote = noteBl.DeleteNote(id);

            if (isDeleteNote == true)
            {
                return this.Ok(new
                {
                    success = true,
                    message = "Note Deleted Successfully!!!",
                    
                });

            }
            else
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = "something went wrong..",

                });
            }
        }

        [HttpGet("getNotes")]
        public IActionResult GetAllNotes()
        {
            var getNotes = noteBl.GetAllNotes().ToList();
            var json = JsonConvert.SerializeObject(getNotes, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );

            if (getNotes != null)
            {
                return this.Ok(new
                {
                    success = true,
                    message = "All Notes fetched Successfully!!!",
                    response = json

                });

            }
            else
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = "something went wrong..",

                });
            }

        }

        [HttpGet("getNotesById")]
        public IActionResult GetNotesById(long id)
        {
            var getNotes = noteBl.GetNotesById(id);
            var json = JsonConvert.SerializeObject(getNotes, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );

            if (getNotes != null)
            {
                return this.Ok(new
                {
                    success = true,
                    message = "Notes fetched Successfully!!!",
                    response = json

                });

            }
            else
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = "something went wrong..",

                });
            }

        }

        [HttpPut("update")]

        public IActionResult UpdateNote(long id,string title, string description)
        {
            //long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
         
            var getNotes = noteBl.UpdateNote(id, title, description);

            try
            {
                if (getNotes == null)
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "try again",

                    });

                }

                return this.Ok(new
                {
                    success = true,
                    message = "Note has been updated",
                    result = getNotes

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("archive")]

        public IActionResult ArchiveNote(long id)
        {
            //long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);

            var getNotes = noteBl.ArchiveNote(id);

            try
            {
                if (getNotes == null)
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "try again",

                    });

                }

                return this.Ok(new
                {
                    success = true,
                    message = "Note has been Archived",
                    result = getNotes

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("pin")]

        public IActionResult PinNote(long id)
        {
            //long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);

            var getNotes = noteBl.PinNote(id);

            try
            {
                if (getNotes == null)
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "try again",

                    });

                }

                return this.Ok(new
                {
                    success = true,
                    message = "Note has been Pinned",
                    result = getNotes

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("delete")]

        public IActionResult PermanentDelete(long id)
        {
            //id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
            bool isDeleteNote = noteBl.PermanentDelete(id);

            if (isDeleteNote == true)
            {
                return this.Ok(new
                {
                    success = true,
                    message = "Note Deleted Successfully!!!",

                });

            }
            else
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = "something went wrong..",

                });
            }
        }
    }
}
