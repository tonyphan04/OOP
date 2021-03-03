using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SplashKitSDK;

namespace AircraftOne
{
    public class Program
    {     
        public static void Main()
        {
            Bitmap background = SplashKit.LoadBitmap("background1", "background1.png");
            Aircraft a = new Aircraft();
            GameRules gr = new GameRules();
            
            new Window("Aircraft One", 600, 800);

            while (!SplashKit.WindowCloseRequested("Aircraft One")) 
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (a.Lives > 0)
                {
                    SplashKit.DrawBitmap(background, 0, -100);
                    SplashKit.DrawText("Lives:" + a.Lives, Color.White, 5, 10);
                    SplashKit.DrawText("Score:" + a.Score, Color.White, 5, 30);
                    a.Draw();
                    a.Move();
                    SplashKit.HideMouse();
                    gr.ResetCollector();
                    gr.AddItem();
                    gr.DrawItem();
                    gr.MoveItem();
                    gr.AddObstacle();
                    gr.DrawObstacle();
                    gr.MoveProjectile();
                    gr.MoveObstacle();
                    gr.DrawProjectile();
                    gr.AddProjectile(a);
                    gr.Healing(a);
                    gr.Collision(a);
                    gr.CollisionProjectile(a);
                    if (a.Lives <= 0)
                    {
                        a.Alive = false;
                    }

                    if (a.Alive == false)
                    {
                        a.Lives -= 1;
                        a.ProjectileImage = SplashKit.LoadBitmap("hadoken", "hadoken.png");
                        a.X = SplashKit.MouseX();
                        a.Y = SplashKit.MouseY();
                        a.Alive = true;
                    }
                    gr.CheckObstacle(a);
                    gr.Check();
                    gr.RemoveObj();
                }
                else
                {
                    SplashKit.DrawText("Game Over", Color.Black, 300, 100);
                    SplashKit.ShowMouse();
                }

                
                SplashKit.RefreshScreen();
            } 
        }

    }

}
