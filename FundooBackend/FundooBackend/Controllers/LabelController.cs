using businesslayer.Interface;
using commonlayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using repolayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBl labelBl;
        private readonly IMemoryCache memoryCache;
        FundooContext fundooContext;
        private readonly IDistributedCache distributedCache;

        public LabelController(ILabelBl labelBl, IMemoryCache memoryCache, FundooContext fundooContext, IDistributedCache distributedCache)
        {
            this.labelBl = labelBl;
            this.memoryCache = memoryCache;
            this.fundooContext = fundooContext; ;
            this.distributedCache = distributedCache;
        }

        [HttpPost("createLabel")]
        public IActionResult CreateLabel(long noteid, string label)
        {
            try
            {
                long id = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
                var result = labelBl.CreateLabel(id, noteid, label);

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
