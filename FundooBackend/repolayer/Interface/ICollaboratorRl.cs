using commonlayer.Model;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repolayer.Interface
{
    public interface ICollaboratorRl
    {
        public CollaboratorEntity AddCollaborator(CollaboratorModel collaborator, long noteid, long userId);
    }
}
