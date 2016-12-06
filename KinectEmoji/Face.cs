using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectEmoji
{
    class MyPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public MyPoint()
        {
            x = 0; y = 0; z = 0;
        }

        public MyPoint(double ix, double iy, double iz)
        {
            x = ix; y = iy; z = iz;
        }

        public override String ToString()
        {
            return String.Format("({0:F2}, {1:F2}, {2:F2})", x, y, z);
        }
    }

    class FacePoint
    {
        public int index { get; }
        public String name { get; }
        public MyPoint point = new MyPoint();

        public FacePoint(int i, String n)
        {
            index = i;
            name = n;
        }

        public override string ToString()
        {
            return String.Format("{0}({1}): {2}", name, index, point.ToString());
        }
    }

    class Face
    {
        public const int EyeLeft = 0;
        public const int LefteyeInnercorner = 210;
        public const int LefteyeOutercorner = 469;
        public const int LefteyeMidtop = 241;
        public const int LefteyeMidbottom = 1104;
        public const int RighteyeInnercorner = 843;
        public const int RighteyeOutercorner = 1117;
        public const int RighteyeMidtop = 731;
        public const int RighteyeMidbottom = 1090;
        public const int LefteyebrowInner = 346;
        public const int LefteyebrowOuter = 140;
        public const int LefteyebrowCenter = 222;
        public const int RighteyebrowInner = 803;
        public const int RighteyebrowOuter = 758;
        public const int RighteyebrowCenter = 849;
        public const int MouthLeftcorner = 91;
        public const int MouthRightcorner = 687;
        public const int MouthUpperlipMidtop = 19;
        public const int MouthUpperlipMidbottom = 1072;
        public const int MouthLowerlipMidtop = 10;
        public const int MouthLowerlipMidbottom = 8;
        public const int NoseTip = 18;
        public const int NoseBottom = 14;
        public const int NoseBottomleft = 156;
        public const int NoseBottomright = 783;
        public const int NoseTop = 24;
        public const int NoseTopleft = 151;
        public const int NoseTopright = 772;
        public const int ForeheadCenter = 28;
        public const int LeftcheekCenter = 412;
        public const int RightcheekCenter = 933;
        public const int Leftcheekbone = 458;
        public const int Rightcheekbone = 674;
        public const int ChinCenter = 4;
        public const int LowerjawLeftend = 1307;
        public const int LowerjawRightend = 1327;

        public static readonly int [] MouthPoints = {MouthLeftcorner, MouthRightcorner, MouthUpperlipMidbottom, MouthLowerlipMidtop};

        public MyPoint pMouthLeftcorner = new MyPoint();

        public List<FacePoint> _trackedPoints = new List<FacePoint>();

        public Face()
        {
            _trackedPoints.Add(new FacePoint(MouthLeftcorner, "MouthLeftcorner"));
            _trackedPoints.Add(new FacePoint(MouthRightcorner, "MouthRightcorner"));
        }

        public static bool isMouthPoints(int i)
        {
            return Array.Exists(MouthPoints, element => element == i);
        }

        public void addData(int i, float x, float y, float z)
        {
            foreach(var p in _trackedPoints)
            {
                if (p.index == i)
                {
                    p.point.x = x;
                    p.point.y = y;
                    p.point.z = z;
                }
            }
            /*
            if (i == MouthLeftcorner)
            {
                pMouthLeftcorner.x = x;
                pMouthLeftcorner.y = y;
                pMouthLeftcorner.z = z;
            }
            */
            //var p = new MyPoint(x, y, z);
        }

        public String dump_str()
        {
            String tmp = "";
            foreach(var p in _trackedPoints)
            {
                tmp += String.Format("{0}\n", p.ToString());
            }
            //return String.Format("MouthLeftcorner: {0}", pMouthLeftcorner.ToString());
            return tmp;
        }
    }
}
