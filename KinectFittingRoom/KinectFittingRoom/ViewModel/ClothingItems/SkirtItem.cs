﻿using System.Windows.Media.Media3D;
using Microsoft.Kinect;

namespace KinectFittingRoom.ViewModel.ClothingItems
{
    class SkirtItem : ClothingItemBase
    {
        private const double RegularProportionHipWidthToHeight = 0.2;
        #region .ctor
        /// <summary>
        /// Constructor of Skirt object
        /// </summary>
        /// <param name="model">3D model</param>
        public SkirtItem(Model3DGroup model)
            : base(model)
        {
            JointToTrackPosition = JointType.HipCenter;
            LeftJointToTrackAngle = JointType.HipLeft;
            RightJointToTrackAngle = JointType.HipRight;
        }
        #endregion .ctor
        /// <summary>
        /// Fit width of model to width of body
        /// </summary>
        /// <param name="skeleton">The skeleton</param>
        /// <param name="sensor">Kinect sensor</param>
        /// <param name="width">Kinect image width</param>
        /// <param name="height">Kinect image heigh</param>
        public override void GetBasicWidth(Skeleton skeleton, KinectSensor sensor, double width, double height)
        {
            var head = KinectService.GetJointPoint(skeleton.Joints[JointType.Head], sensor, width, height); ;
            var footRight = KinectService.GetJointPoint(skeleton.Joints[JointType.FootRight], sensor, width, height);
            var t = Model.Children[0].Bounds.SizeX * ModelSizeRatio;
            _heightScale = _widthScale = (footRight.Y - head.Y) * (RegularProportionHipWidthToHeight / t);
        }
    }
}
