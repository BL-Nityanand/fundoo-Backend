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
    public class Collaborator : ICollaboratorRl
    {
        FundooContext fundooContext;
        public IConfiguration Config;
        public Collaborator(FundooContext fundooContext, IConfiguration Config)
        {
            this.fundooContext = fundooContext;
            this.Config = Config;
        }

        public CollaboratorEntity AddCollaborator(CollaboratorModel collaborator, long noteid, long userId)
        {

            try
            {
                var user = fundooContext.Users.FirstOrDefault(x => x.userid == userId);
                var note = fundooContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);

                CollaboratorEntity cEntity = new CollaboratorEntity
                {
                    users = user,
                    note = note
                };
                //CollaboratorEntity cEntity = new CollaboratorEntity();


                //cEntity.users = user;
                //cEntity.note = note;
                cEntity.email = collaborator.email;

                fundooContext.CollaboratorsTable.Add(cEntity);

                int result = fundooContext.SaveChanges();

                if (result > 0)
                {
                    return cEntity;
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
