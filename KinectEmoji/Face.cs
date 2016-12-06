﻿using System;
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

        public MyPoint(double x = 0, double y = 0, double z = 0)
        {
            setValue(x, y, z);
        }

        public void setValue(double ix, double iy, double iz)
        {
            x = ix; y = iy; z = iz;
        }

        public override String ToString()
        {
            return String.Format("({0:F2}, {1:F2}, {2:F2})", x, y, z);
        }
    }

    class MyVector
    {
        public MyPoint start { get; }
        public MyPoint end { get; }

        public MyVector(MyPoint s, MyPoint e)
        {
            start = s; end = e;
        }

        public override String ToString()
        {
            return String.Format("({0} -> {1})", start.ToString(), end.ToString());
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
        public static readonly int[] TargetPoints = {
            MouthLeftcorner, MouthRightcorner, MouthUpperlipMidbottom, MouthLowerlipMidtop
        };
        public static readonly string[] TargetPointsName = {
            "MouthLeftcorner", "MouthRightcorner", "MouthUpperlipMidbottom", "MouthLowerlipMidtop"
        };
        public static Dictionary<int, int> IndexToPos = null;

        public MyPoint pMouthLeftcorner = new MyPoint();

        public List<MyPoint> _trackedPoints = new List<MyPoint>();

        static Face()
        {
            IndexToPos = new Dictionary<int, int>();
            for (int i = 0; i < TargetPoints.Length; ++i)
            {
                IndexToPos.Add(TargetPoints[i], i);
            } 
        }

        public Face()
        {
            for (int i = 0; i < TargetPoints.Length; ++i)
            {
                _trackedPoints.Add(new MyPoint());
            }
        }

        public static bool isMouthPoints(int i)
        {
            return Array.Exists(MouthPoints, element => element == i);
        }

        public void addData(int i, float x, float y, float z)
        {
            int value;
            if (IndexToPos.TryGetValue(i, out value))
            {
                _trackedPoints[value].setValue(x, y, z);
            }
        }

        public String dump_str()
        {
            
            String tmp = "";
            
            for (int i = 0; i < TargetPoints.Length; ++i)
            {
                tmp += String.Format("{0}({1}): {2}\n", TargetPointsName[i], TargetPoints[i], _trackedPoints[i].ToString());
            }
            //return String.Format("MouthLeftcorner: {0}", pMouthLeftcorner.ToString());
            /*
            MyVector v = new MyVector(_trackedPoints[0].point, _trackedPoints[1].point);
            tmp += String.Format("{0}\n", v.ToString());
            */
            return tmp;
        }
    }
}
