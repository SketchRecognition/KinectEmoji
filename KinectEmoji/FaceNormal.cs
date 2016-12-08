using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect.Face;
using WindowsPreview.Kinect;

namespace KinectEmoji
{
    class FaceNormal
    {
        public DetectionResult eyeLeftClosed { get; }
        public DetectionResult eyeRightClosed { get; }
        public DetectionResult happy { get; }
        public DetectionResult lookingAway { get; }
        public double yaw { get; }
        public double pitch { get; }
        public double roll { get; }

        public FaceNormal(FaceFrameResult result)
        {
            eyeLeftClosed = result.FaceProperties[FaceProperty.LeftEyeClosed];
            eyeRightClosed = result.FaceProperties[FaceProperty.RightEyeClosed];
            happy = result.FaceProperties[FaceProperty.Happy];
            lookingAway = result.FaceProperties[FaceProperty.LookingAway];

            Vector4 rotQuaternion = result.FaceRotationQuaternion;
            double x = rotQuaternion.X;
            double y = rotQuaternion.Y;
            double z = rotQuaternion.Z;
            double w = rotQuaternion.W;

            pitch = Math.Atan2(2 * ((y * z) + (w * x)), (w * w) - (x * x) - (y * y) + (z * z)) / Math.PI * 180.0;
            yaw = Math.Asin(2 * ((w * y) - (x * z))) / Math.PI * 180.0;
            roll = Math.Atan2(2 * ((x * y) + (w * z)), (w * w) + (x * x) - (y * y) - (z * z)) / Math.PI * 180.0;
        }

        public String resultToStr(DetectionResult r)
        {
            if (r == DetectionResult.Yes) {
                return "Yes";
            } else if (r == DetectionResult.Maybe)
            {
                return "Maybe";
            } else if (r == DetectionResult.No)
            {
                return "No";
            } else if (r == DetectionResult.Unknown)
            {
                return "Unknown";
            }
            return "Error";
        }

        public String dump_str()
        {
            String str = "";
            str += String.Format("eyeLeftClosed: {0}\n", resultToStr(eyeLeftClosed));
            str += String.Format("eyeRightClosed: {0}\n", resultToStr(eyeRightClosed));
            str += String.Format("happy: {0}\n", resultToStr(happy));
            str += String.Format("lookingAway: {0}\n", resultToStr(lookingAway));
            str += String.Format("yaw: {0:F2}\n", yaw);
            str += String.Format("pitch: {0:F2}\n", pitch);
            str += String.Format("roll: {0:F2}\n", roll);
            return str;
        }
    }
}
