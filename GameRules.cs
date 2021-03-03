using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class GameRules
    {
        private List<IFly> flyObj;
        private List<IFly> _toRemove;
        private List<Projectile> projectile;
        public GameRules()
        {
            flyObj = new List<IFly>();
            projectile = new List<Projectile>();
        }
        public void ResetCollector()
        {
            _toRemove = new List<IFly>();
        }
        public void RemoveObj()
        {
            foreach (IFly obj in _toRemove)
            {
                flyObj.Remove(obj);
            }
        }
        public void AddItem()
        {
            if (SplashKit.Rnd(0, 50000) % 50000 == 0)
            {
                BonusItem buff = new BonusItem(SplashKit.LoadBitmap("heart4","heart4.png"));
                flyObj.Add(buff);             
            }
        }
        public void AddObstacle()
        {
            if (SplashKit.Rnd(0, 10000) % 10000 == 0)
            {
                Obstacle m = new Meteorite(SplashKit.LoadBitmap("meteorite2", "meteorite2.png"),SplashKit.Rnd(0, 600), 0);
                flyObj.Add(m);
            }
            if(SplashKit.Rnd(0, 5000) % 5000 == 0)
            { 
                Obstacle m = new Stone(SplashKit.LoadBitmap("stone2", "stone2.png"), SplashKit.Rnd(0, 600), 0);
                flyObj.Add(m);
            }
        }
        public void DrawItem()
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is BonusItem )
                {
                    obj.Draw();
                }            
            }
        }
        public void DrawObstacle()
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is Obstacle)
                {
                    obj.Draw();
                }
            }
        }
        public void AddProjectile(Aircraft a)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                projectile.Add(a.CreateProjectile());
            }
        }
        public void DrawProjectile()
        {
            foreach (Projectile pr in projectile)
            {
                pr.Draw();               
            }
        }
        public void MoveItem()
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is BonusItem)
                {
                    obj.MoveDown(0.05F);
                }
            }
        }
        public void MoveObstacle()
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is Obstacle && obj.GetType() == typeof(Meteorite))
                {
                    obj.MoveDown(0.1F);
                }
                if (obj is Obstacle && obj.GetType() == typeof(Stone))
                {
                    obj.MoveDown(0.05F);
                }
            }
        }
        public void MoveProjectile()
        {
            foreach (Projectile pr in projectile)
            {
                if (pr.Object_Kind == ObjectKinds.Aircraft && pr.GetType() == typeof(Projectile))
                {
                    pr.MoveDown(-0.1F);
                }
            }
        }
        public void Healing(Aircraft a)
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is BonusItem)
                {
                    BonusItem item = obj as BonusItem;

                    if (item.Collision(a))
                    {
                        item.TakeAffect(a);
                        _toRemove.Add(item);
                    }
                }
            }
        }
        public void CheckObstacle(Aircraft a)
        {
            foreach(IFly obj in flyObj)
            {
                if (obj is Obstacle)
                {
                    Obstacle ob = obj as Obstacle;                 
                    if (ob.Lives<= 0)
                    {
                        ob.Alive = false;
                        a.Score += 1;
                    }

                    if (ob.Alive == false)
                    {
                        _toRemove.Add(ob);
                    }
                }
            }
        }
        public void Collision(Aircraft a)
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is Obstacle)
                {
                    Obstacle o = obj as Obstacle;
                    if (o.Collision(a))
                    {
                        o.TakeEffect(a);
                        _toRemove.Add(o);
                    }
                }
            }
        }
        public void CollisionProjectile(Aircraft a)
        {
            foreach (IFly obj in flyObj)
            {
                if (obj is Obstacle)
                {
                    Obstacle o = obj as Obstacle;
                    foreach (Projectile pr in projectile)
                    {
                        if (o.Collision(pr))
                        {
                            o.Lives -= pr.Damage;
                            o.Alive = false;
                            _toRemove.Add(o);
                        }
                        if (o.Alive == false)
                        {
                            a.Score += 1;
                        }
                    }
                    
                }
            }
        }
        public void Check()
        {
            foreach(IFly obj in flyObj)
            {
                if (obj.Y > SplashKit.ScreenHeight())
                {
                    _toRemove.Add(obj);
                }
            }
        }
    }
}
