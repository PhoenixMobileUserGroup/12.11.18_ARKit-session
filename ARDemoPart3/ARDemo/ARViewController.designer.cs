// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ARDemo
{
    [Register ("ARViewController")]
    partial class ARViewController
    {
        [Outlet]
        ARKit.ARSCNView SceneView { get; set; }

        [Action ("LeftButtonTapped:")]
        partial void LeftButtonTapped (Foundation.NSObject sender);

        [Action ("RightButtonTapped:")]
        partial void RightButtonTapped (Foundation.NSObject sender);

        [Action ("RotateLeftTapped:")]
        partial void RotateLeftTapped (Foundation.NSObject sender);

        [Action ("RotateRightTapped:")]
        partial void RotateRightTapped (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (SceneView != null) {
                SceneView.Dispose ();
                SceneView = null;
            }
        }
    }
}
