using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace AircraftOne
{
    public class Meteorite : Obstacle
    {
        public Meteorite(Bitmap bitmap, float x, float y) : base(bitmap,x,y)
        {          
            Lives = 4;
        }
        public override void TakeEffect(Aircraft a)
        {
            a.Lives -= 3;
        }
    }
}
