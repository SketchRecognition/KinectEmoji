using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectEmoji
{
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

        public static bool isMouthPoints(int i)
        {
            return Array.Exists(MouthPoints, element => element == i);
        }
    }
}
