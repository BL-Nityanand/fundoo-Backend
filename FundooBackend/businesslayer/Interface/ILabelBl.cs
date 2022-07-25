using commonlayer.Model;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.Interface
{
    public interface ILabelBl
    {
        public LabelEntity CreateLabel(long userid, long noteid, string label);
    }
}
