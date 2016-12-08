﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPreview.Kinect;
using Windows.Storage;

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

        public async void save()
        {
            String qq = "ffffwww";
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(qq);
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var dataFolder = await local.CreateFolderAsync("DataFolder",
    CreationCollisionOption.OpenIfExists);

            // Create a new file named DataFile.txt.
            var file = await dataFolder.CreateFileAsync("DataFile.txt",
            CreationCollisionOption.ReplaceExisting);

            // Write the data from the textbox.
            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }

            //string[] lines = { "aa", "bb" };
            //StreamWriter w = new StreamWriter
            //System.IO.Path
            //string path = "QQ";
            //StreamWriter w = new StreamWriter("qq.txt", false);
            //StreamWriter file = File.CreateText(@"C:\Users\Public\test.txt");

        }

        public bool isHappy()
        {
            double threshold = 0.5;
            int total = _normal_list.Where(e => e.happy == DetectionResult.Yes).Sum(e => 1);
            return ((double)total / _normal_list.Count) > threshold;
        }
        
        public bool isWink()
        {
            return isLeftEyeClosed() && isRightEyeOpen() || isLeftEyeOpen() && isRightEyeClosed();
        }

        public bool isLeftEyeClosed()
        {/*
            DetectionResult r = _normal_list.Last().eyeLeftClosed;
            if (r == DetectionResult.Yes)
            {
                return true;
            }*/
            
            //return false;
            double threshold = 0.4;
            int total = _normal_list.Where(e => e.eyeLeftClosed == DetectionResult.Yes).Sum(e => 1);
            return ((double)total / _normal_list.Count) > threshold;
        }

        public bool isLeftEyeOpen()
        {
            double threshold = 0.4;
            int total = _normal_list.Where(e => e.eyeLeftClosed == DetectionResult.No).Sum(e => 1);
            return ((double)total / _normal_list.Count) > threshold;
        }

        public bool isRightEyeClosed()
        {
            double threshold = 0.4;
            int total = _normal_list.Where(e => e.eyeRightClosed == DetectionResult.Yes).Sum(e => 1);
            return ((double)total / _normal_list.Count) > threshold;
        }

        public bool isRightEyeOpen()
        {
            double threshold = 0.4;
            int total = _normal_list.Where(e => e.eyeRightClosed == DetectionResult.No).Sum(e => 1);
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

        public bool isNodHead()
        {
            double threshold = 40;

            double max = _normal_list.Max(e => e.pitch);
            double min = _normal_list.Min(e => e.pitch);
            return Math.Abs(max - min) > threshold;
        }

        public bool isSwayHead()
        {
            double threshold = 50;

            double max = _normal_list.Max(e => e.roll);
            double min = _normal_list.Min(e => e.roll);
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
