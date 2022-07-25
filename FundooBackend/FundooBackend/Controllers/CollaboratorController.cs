using businesslayer.Interface;
using commonlayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        ICollaboratorBl iCollaborator;

        public CollaboratorController(ICollaboratorBl iCollaborator)
        {
            this.iCollaborator = iCollaborator;
        }

        [HttpPost("addCollaborator")]


        public IActionResult AddCollaborator(CollaboratorModel collaborator, long noteid)
        {
            try
            {
                long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
                var result = iCollaborator.AddCollaborator(collaborator, noteid, id);

                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Note updated Successfully!!!",
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

        [HttpPost("deleteCollaborator")]


        public IActionResult DeleteCollaborator( long collbId)
        {
            try
            {
                long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
                var result = iCollaborator.AddCollaborator(collbId);

                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Note updated Successfully!!!",
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
    }
}
