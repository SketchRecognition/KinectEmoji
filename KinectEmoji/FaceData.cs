using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPreview.Kinect;

namespace KinectEmoji
{
    class FaceData
    {
        private TimeSpan span = TimeSpan.FromSeconds(1);
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

        public bool isHappy()
        {
            /*
            DetectionResult r = _normal_list.Last().happy;
            if (r == DetectionResult.Yes)
            {
                return true;
            }

            return false;
            */

            double threshold = 0.5;
            int total = _normal_list.Where(e => e.happy == DetectionResult.Yes).Sum(e => 1);
            return ((double)total / _normal_list.Count) > threshold;
        }

        public bool isMouthOpen()
        {
            double threshold = 0.6;
            return _hd_list.Last().feature_mouthRatio() > threshold;
        }

        public bool isShakeHead()
        {
            double threshold = 60;
            double max = _normal_list.Max(e => e.yaw);
            double min = _normal_list.Min(e => e.yaw);
            return Math.Abs(max - min) > threshold;
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
