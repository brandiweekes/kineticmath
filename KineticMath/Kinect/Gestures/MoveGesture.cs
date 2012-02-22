﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;
using KineticMath.SubControls;

namespace KineticMath.Kinect.Gestures
{
    class MoveGesture : IGesture
    {
        private DateTime lastAction = DateTime.Now;
        private float timelength = 1;
        private float preSpineX = 0;
        private float currentSpineX = 0;
        float spineThreshould = 25;

        public delegate void MoveEventHandler(object sender, MoveEventArgs m);
        public event MoveEventHandler UserMoved;

        public void ProcessSkeleton(Skeleton skeleton)
        {
            Joint spine = skeleton.Joints[JointType.Spine].ScaleTo(640, 480, KinectSkeleton.k_xMaxJointScale, KinectSkeleton.k_yMaxJointScale);
            currentSpineX = spine.Position.X;
            float spineDx = currentSpineX - preSpineX;
            if (DateTime.Now.Subtract(lastAction) >= TimeSpan.FromSeconds(timelength))
            {
                if (spineDx > 0 && spineDx > spineThreshould)
                {
                    UserMoved(this, new MoveEventArgs(1));
                    System.Console.WriteLine("spineDx = " + spineDx);
                   
                }
                else if (spineDx < 0 && spineDx < -spineThreshould)
                {
                    UserMoved(this, new MoveEventArgs(-1));
                    System.Console.WriteLine("spineDx" + spineDx);
                
                }

                lastAction = DateTime.Now;
                preSpineX = currentSpineX;
            }
        }
    }
}