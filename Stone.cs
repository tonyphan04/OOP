using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace AircraftOne
{
    public class Stone : Obstacle
    {
        public Stone(Bitmap bitmap, float x, float y) : base(bitmap, x, y)
        {
            Lives = 2;
        }
        public override void TakeEffect(Aircraft a)
        {
            a.Lives -= 1;
        }
    }
}
