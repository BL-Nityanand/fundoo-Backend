using businesslayer.Interface;
using commonlayer.Model;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.service
{
    public class CollaboratorBl : ICollaboratorBl
    {
        ICollaboratorRl collaborator;
        public CollaboratorBl(ICollaboratorRl collaborator)
        {
            this.collaborator = collaborator;
        }
        public CollaboratorEntity AddCollaborator(CollaboratorModel collaborator1, long noteid, long userId)
        {
            try
            {
                return collaborator.AddCollaborator(collaborator1, noteid, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
