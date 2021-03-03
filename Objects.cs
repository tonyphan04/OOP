using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class Objects
    {
        private bool _alive;    
        private Bitmap _defaultImage;  
        private ObjectKinds _objectKind;    
        protected Sprite _sprite;

        public float X { get => SplashKit.SpriteX(_sprite); set => SplashKit.SpriteSetX(_sprite, value); } 

        public float Y { get => SplashKit.SpriteY(_sprite); set => SplashKit.SpriteSetY(_sprite, value); }  

        public float Height { get => SplashKit.SpriteHeight(_sprite); }  

        public float Width { get => SplashKit.SpriteWidth(_sprite); }  

        public bool Alive { get => _alive; set => _alive = value; }

        public Bitmap DefaultImage { get => _defaultImage; set => _defaultImage = value; }

        public ObjectKinds Object_Kind { get => _objectKind; set => _objectKind = value; }

        public Sprite ObjectSprite { get => _sprite; }

        public Objects(Bitmap bitmap, float x, float y)
        {
            Alive = true;
            _defaultImage = bitmap;
            _sprite = SplashKit.CreateSprite(_defaultImage);

            SplashKit.SpriteSetX(_sprite, x);
            SplashKit.SpriteSetY(_sprite, y);
        }
        public Objects(Bitmap bitmap)
        {
            Alive = true;
            _defaultImage = bitmap;
            _sprite = SplashKit.CreateSprite(_defaultImage);
        }
        public Objects()
        {
            Alive = true;
        }

        public void Draw()
        {
            SplashKit.DrawSprite(_sprite);
        }
    }
}

