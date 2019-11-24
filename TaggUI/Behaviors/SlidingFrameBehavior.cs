using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaggUI.Behaviors
{
    public class SlidingFrameBehavior : Behavior<View>
    {

        protected override void OnAttachedTo(View bindable)
        {
            /*
             * Swipe gesture
             */
            var upSwipeGesture = new SwipeGestureRecognizer() { Direction = SwipeDirection.Up };
            var downSwipeGesture = new SwipeGestureRecognizer() { Direction = SwipeDirection.Down };
            upSwipeGesture.Swiped += SwipeGestureOnSwiped;
            downSwipeGesture.Swiped += SwipeGestureOnSwiped;
            bindable.GestureRecognizers.Add(upSwipeGesture);
            bindable.GestureRecognizers.Add(downSwipeGesture);

            //base
            base.OnAttachedTo(bindable);
        }

        private void SwipeGestureOnSwiped(object sender, SwipedEventArgs e)
        {
            var view = (View)sender;
            _ = AnimateSlide(view, e.Direction);

        }

        private bool _isAnimating;
        private const double CollapsedHeight = .25;
        private const double ExpandedHeight = 1;

        private async Task AnimateSlide(View view, SwipeDirection direction)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            double changeDelta = 0;
            switch (direction)
            {
                case SwipeDirection.Up:
                    changeDelta = .05;
                    break;
                case SwipeDirection.Down:
                    changeDelta = -.05;
                    break;
            }

            double height = AbsoluteLayout.GetLayoutBounds(view).Height;

            while ((height + changeDelta <= ExpandedHeight) && (height + changeDelta >= CollapsedHeight))
            {
                height += changeDelta;
                AbsoluteLayout.SetLayoutBounds(view, new Rectangle(0, 1, 1, height));
                await Task.Delay(15);
            }

            _isAnimating = false;
        }
    }
}
