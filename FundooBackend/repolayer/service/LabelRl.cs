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
    public class LabelRl : ILabelRl
    {
        FundooContext fundooContext;

        private readonly IConfiguration config;

        public LabelRl(FundooContext fundooContext, IConfiguration config)
        {
            this.fundooContext = fundooContext;
            this.config = config;
        }

        public LabelEntity CreateLabel( long userid, long noteid, string label)
        {
            //NoteEntity checkId = fundooContext.NotesTable.Where(x => x.noteid == noteid).FirstOrDefault();
            try
            {
                var user = fundooContext.Users.FirstOrDefault(x => x.userid == userid);
                var note = fundooContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);

                LabelEntity labelEntity = new LabelEntity()
                {
                    user = user,
                    note = note
                    
                };
                
                labelEntity.label = label;
         

                fundooContext.Labels.Add(labelEntity);

                int result = fundooContext.SaveChanges();

                if (result > 0)
                {
                    return labelEntity;
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

    }
}
