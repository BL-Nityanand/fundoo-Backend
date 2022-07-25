using businesslayer.Interface;
using commonlayer.Model;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.service
{
    public class LabelBl : ILabelBl
    {
        ILabelRl labelRl;

        public LabelBl(ILabelRl labelRl)
        {
            this.labelRl = labelRl;
        }
        public LabelEntity CreateLabel(long userid, long noteid, string label)
        {
            try
            {
                return labelRl.CreateLabel(userid, noteid, label);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
