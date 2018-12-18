using System;

using UIKit;

namespace ARDemo
{
    public partial class ARViewController : UIViewController
    {
        public ARViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SceneView.DebugOptions = ARKit.ARSCNDebugOptions.ShowFeaturePoints | ARKit.ARSCNDebugOptions.ShowWorldOrigin;


            SceneView.Session.Run(new ARKit.ARWorldTrackingConfiguration()
            {
                PlaneDetection = ARKit.ARPlaneDetection.Horizontal,
                LightEstimationEnabled = true,
                AutoFocusEnabled = true,
                WorldAlignment = ARKit.ARWorldAlignment.Gravity
            }, ARKit.ARSessionRunOptions.ResetTracking);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

