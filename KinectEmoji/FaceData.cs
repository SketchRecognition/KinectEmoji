using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectEmoji
{
    class FaceData
    {
        private LinkedList<FaceNormal> _normal_list = new LinkedList<FaceNormal>();
        private TimeSpan span = TimeSpan.FromSeconds(2);

        public void addNormalData(FaceNormal f)
        {
            _normal_list.AddLast(f);
            while (f.time.Subtract(_normal_list.First().time) > span)
            {
                _normal_list.RemoveFirst();
            }
        }

        public String dump_str()
        {
            String str = "";
            str += String.Format("_normal_list: {0}", _normal_list.Count);
            return str;
        }
    }
}
