using System;
using UIKit;
using ARKit;
using SceneKit;

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

            //let's create a geometric object
            var box = SCNBox.Create(0.1f, 0.1f, 0.1f, 0);
            box.FirstMaterial.Diffuse.ContentColor = UIColor.Green;

            //let's add the box to a SCNNode 
            var newNode = new SCNNode();
            newNode.Geometry = box;
            newNode.Position = new SCNVector3(0, 0, -1);

            //Let's create a scene where this node will live in
            var scene = new SCNScene();
            scene.RootNode.Add(newNode);

            //set the scene in the sceneview to display it.
            SceneView.Scene = scene;

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

