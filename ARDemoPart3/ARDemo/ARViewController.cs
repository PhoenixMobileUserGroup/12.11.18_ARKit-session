using System;
using UIKit;
using ARKit;
using SceneKit;

namespace ARDemo
{
    public partial class ARViewController : UIViewController
    {
        private SCNNode _ship;

        public ARViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //Let's create a scene where this node will live in
            var scene = SCNScene.FromFile("art.scnassets/ship");

            var ship = scene.RootNode.FindChildNode("ship", true);

            ship.Scale = new SCNVector3(0.1f, 0.1f, 0.1f);
            ship.Position = new SCNVector3(0, 0, -1);


            //let's do some matrix transformations
           //var translateMatrix = SCNMatrix4.CreateTranslation(-3f, 0, 0);
           //ship.Transform = SCNMatrix4.Mult(translateMatrix, ship.Transform);

            // var rotationMatrix = SCNMatrix4.CreateRotationY((float)Math.PI / 4);
            // ship.Transform = SCNMatrix4.Mult(rotationMatrix, ship.Transform);

            // var scaleMatrix = SCNMatrix4.Scale(1);
            // ship.Transform = SCNMatrix4.Mult(scaleMatrix, ship.Transform);

            //var action = SCNAction.RepeatActionForever(SCNAction.RotateBy(0, (float)Math.Sin(5), 0, 2));
            //ship.RunAction(action);

            _ship = ship;

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

        partial void LeftButtonTapped(Foundation.NSObject sender)
        {
            var translateMatrix = SCNMatrix4.CreateTranslation(1f, 0, 0);
            _ship.Transform = SCNMatrix4.Mult(translateMatrix, _ship.Transform);

        }

        partial void RightButtonTapped(Foundation.NSObject sender)
        {

            var translateMatrix = SCNMatrix4.CreateTranslation(-1f, 0, 0);
            _ship.Transform = SCNMatrix4.Mult(translateMatrix, _ship.Transform);

        }

        partial void RotateLeftTapped(Foundation.NSObject sender)
        {
            var rotationMatrix = SCNMatrix4.CreateRotationY(((float)Math.PI / 4));
            _ship.Transform = SCNMatrix4.Mult(rotationMatrix, _ship.Transform);
        }

        partial void RotateRightTapped(Foundation.NSObject sender)
        {
            var rotationMatrix = SCNMatrix4.CreateRotationY(-((float)Math.PI / 4));
            _ship.Transform = SCNMatrix4.Mult(rotationMatrix, _ship.Transform);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

