using commonlayer.Model;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repolayer.Interface
{
    public interface ILabelRl
    {
        public LabelEntity CreateLabel(long userid, long noteid, string label);
    }
}
