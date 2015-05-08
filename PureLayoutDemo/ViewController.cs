using System;
using PureLayout;
using UIKit;
using CoreGraphics;

namespace PureLayoutDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            var red = new UIView();
            var blue = new UIView(); 

            blue.BackgroundColor = UIColor.Blue; 
            red.BackgroundColor = UIColor.Red;

            this.View.Add(red);
            this.View.Add(blue);

            blue.AutoCenterInSuperview();
            blue.AutoSetDimensionsToSize(new CGSize(50, 50));

            red.AutoPinEdge(ALEdge.Top, ALEdge.Bottom, blue);
            red.AutoPinEdge(ALEdge.Left, ALEdge.Right, blue);
            red.AutoMatchDimension(ALDimension.Width, ALDimension.Width, blue);
            red.AutoMatchDimension(ALDimension.Height, ALDimension.Height, blue);

           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

