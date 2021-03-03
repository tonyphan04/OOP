using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class BonusItem : Objects, IFly
    {       
        public BonusItem(Bitmap bitmap, float x, float y) : base(bitmap,x,y)
        {
            Object_Kind = ObjectKinds.BonusItem;
        }
        public BonusItem(Bitmap bitmap) : base(bitmap)
        {
            X = SplashKit.Rnd(0, 600);
            Y = 0;

            if (X < 0)
            {
                X = 0;
            }
            else if (X > 600 - Width)
            {
                X = 600 - Width;
            }
        }
        public bool Collision(Objects obj)
        {
            return SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite);
        }
        public void MoveDown(float MoveDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + MoveDown);
        }       
        public void TakeAffect(Aircraft a)
        {         
            a.Lives += 1;          
        }
    }
}
