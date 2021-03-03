using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class Aircraft : Objects
    {
        private int _lives  = 3;
        private int _score = 0;
        private int _defaultDamage = 1;
        private Bitmap _aircraftImage = SplashKit.LoadBitmap("aircraft2","aircraft2.png");
        private Bitmap _projectileImage = SplashKit.LoadBitmap("hadoken", "hadoken.png");

        public int Lives { get => _lives; set => _lives = value; }
        public int Score { get => _score; set => _score = value; }
        public int DefaultDamage { get => _defaultDamage; set => _defaultDamage = value; }
        public Bitmap AircraftImage { get => _aircraftImage; set => _aircraftImage = value; }
        public Bitmap ProjectileImage { get => _projectileImage; set => _projectileImage = value; }

        public Aircraft(Bitmap bitmap, float x, float y) : base(bitmap,x,y)
        {
            Object_Kind = ObjectKinds.Aircraft;          
        }
        
        public Aircraft() : base()
        {
            DefaultImage = _aircraftImage;
            _sprite = new Sprite(DefaultImage);
            SplashKit.SpriteSetX(_sprite, SplashKit.MouseX() - Width / 2);
            SplashKit.SpriteSetY(_sprite, SplashKit.MouseY() - Height / 2);         
        }
        public Projectile CreateProjectile()
        {
            Projectile p = new Projectile(_projectileImage, SplashKit.MouseX() - Width / 2 + _projectileImage.Width, SplashKit.MouseY() - Height / 2);
            p.Damage = 1;
            p.Object_Kind = ObjectKinds.Aircraft;

            return p;
        }

        public void Move()
        {
            float x = SplashKit.MouseX() - Width / 2;
            float y = SplashKit.MouseY() - Height / 2;

            if (x > 600 - DefaultImage.Width) // 600 = Screen's width
            {
                x = 600 - DefaultImage.Width; 
            }
            else if (x < 0)
            {
                x = 0;
            }

            if (y > 800 - DefaultImage.Height) // 800 = Screen's height 
            {
                y = 800 - DefaultImage.Height;
            }
            else if (y < 0)
            {
                y = 0;
            }
            // new position of the aircraft
            SplashKit.SpriteSetX(ObjectSprite, x);    
            SplashKit.SpriteSetY(ObjectSprite, y);    
        }
    }   
}
