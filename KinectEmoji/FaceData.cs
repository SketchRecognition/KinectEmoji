using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectEmoji
{
    class FaceData
    {
        private TimeSpan span = TimeSpan.FromSeconds(2);
        private LinkedList<FaceNormal> _normal_list = new LinkedList<FaceNormal>();
        private LinkedList<FaceHD> _hd_list = new LinkedList<FaceHD>();

        public void addNormalData(FaceNormal f)
        {
            _normal_list.AddLast(f);
            while (f.time.Subtract(_normal_list.First().time) > span)
            {
                _normal_list.RemoveFirst();
            }
        }

        public void addHDData(FaceHD f)
        {
            _hd_list.AddLast(f);
            while (f.time.Subtract(_hd_list.First().time) > span)
            {
                _hd_list.RemoveFirst();
            }
        }

        public String dump_str()
        {
            String str = "";
            str += String.Format("_normal_list: {0}\n", _normal_list.Count);
            str += String.Format("_hd_list: {0}\n", _hd_list.Count);
            return str;
        }
    }
}
