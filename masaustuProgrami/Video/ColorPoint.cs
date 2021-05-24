using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masaustuProgrami.Video
{
    public class ColorPoint
    {

        #region Variables

        Point point;

        Color color;
        #endregion

        #region Constructor
        public ColorPoint(Point point,Color color)
        {
            this.color = color;
            this.point = point;
        }
       
      

        #endregion 
    }

}
