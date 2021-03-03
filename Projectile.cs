using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class Projectile : Objects, IFly
    {
        private int _damage;
        
        public int Damage { get => _damage; set => _damage = value; }
        

        public Projectile(Bitmap bitmap, float x, float y) : base(bitmap,x,y)
        {
            
        }
        public void MoveDown(float MoveDown)
        {
            SplashKit.SpriteSetY(ObjectSprite, SplashKit.SpriteY(ObjectSprite) + MoveDown);
        }
        public bool Collision(Objects obj)
        {
            return (SplashKit.SpriteCollision(ObjectSprite, obj.ObjectSprite));
        }
       
    }
}
