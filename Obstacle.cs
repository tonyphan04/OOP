using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class Obstacle : Objects, IFly
    {
        private int _lives;

        public int Lives { get => _lives; set => _lives = value; }
        public Obstacle(Bitmap bitmap, float x, float y) : base(bitmap,x,y)
        {
            Object_Kind = ObjectKinds.Obstacle;
        }
        public Obstacle(Bitmap bitmap) : base(bitmap)
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
        public void MoveDown(float MoveDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + MoveDown);
        }
        public bool Collision(Objects obj)
        {
            return (SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite));        
        }
        public virtual void TakeEffect(Aircraft a) { }
    }
}
