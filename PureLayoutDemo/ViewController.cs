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

            var cons = blue.AutoPinEdgesToSuperviewEdgesWithInsets(new UIEdgeInsets(100, 10, 0, 10), ALEdge.Bottom);
            blue.AutoSetDimensionsToSize(new CGSize(50, 50));
            var middleViewOriginY = 100;
            var middleViewTopSpaceLayoutConstant = cons[0].Constant;
            var pan = new UIPanGestureRecognizer(new Action<UIPanGestureRecognizer>(r =>
                    {
//                    if panGesture.state == UIGestureRecognizerState.Ended {
//                        UIView.animateWithDuration(0.4, delay: 0, options: UIViewAnimationOptions.CurveEaseInOut, animations: { () -> Void in
//                            self.middleView.frame.origin.y = self.middleViewOriginY
//                        }, completion: { (success) -> Void in
//                            if success {
//                                self.middleViewTopSpaceLayout.constant = self.middleViewTopSpaceLayoutConstant
//                            }
//                        })
//                        return
//                        }
//                    let y = panGesture.translationInView(self.view).y
//                        middleViewTopSpaceLayout.constant = middleViewTopSpaceLayoutConstant + y
                        if (r.State == UIGestureRecognizerState.Ended)
                        { 
                            UIView.AnimateNotify(.4, 0, UIViewAnimationOptions.CurveEaseInOut,
                                () =>
                                {
                                    blue.Frame = new CGRect(blue.Frame.X, middleViewOriginY, blue.Frame.Width, blue.Frame.Height);
                                },
                                s =>
                                { 
                                    if (s)
                                        cons[0].Constant = middleViewTopSpaceLayoutConstant;
                                }); 
                        }
                        var y = r.TranslationInView(View).Y;
                        cons[0].Constant = middleViewTopSpaceLayoutConstant + y;
                    }));
            blue.AddGestureRecognizer(pan);

//            red.AutoPinEdge(ALEdge.Top, ALEdge.Bottom, blue);
//            red.AutoPinEdge(ALEdge.Left, ALEdge.Right, blue);
//            red.AutoMatchDimension(ALDimension.Width, ALDimension.Width, blue);
//            red.AutoMatchDimension(ALDimension.Height, ALDimension.Height, blue);

           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

