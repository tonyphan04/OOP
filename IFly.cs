using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftOne
{
    interface IFly
    {       
        float X { get; set; }
        float Y { get; set; }
        float Height { get; }
        float Width { get; }
        ObjectKinds Object_Kind { get; set; }
        bool Collision(Objects obj);
        void Draw();
        void MoveDown(float MoveDown);

    }
}
