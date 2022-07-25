using commonlayer.Model;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.Interface
{
    public interface ICollaboratorBl
    {
        public CollaboratorEntity AddCollaborator(CollaboratorModel collaborator, long noteid, long userId);
    }
}
