using System;

namespace Engine
{
    public class Gate : Location
    {
        public Location Destination{ get; set; }
        
        public Gate(string name, int id) : base(name, id)
        {
            Destination = null;
        }
    }
}

