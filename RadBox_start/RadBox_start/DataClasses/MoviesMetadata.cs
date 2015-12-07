using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.DataClasses
{
    public class MoviesMetadata
    {
        public bool Seen { get; set; }
        public TimeSpan Position { get; set; }
        public string Path { get; set; }

        public MoviesMetadata(string path)
        {
            Path = path;
            Seen = false;
            Position = new TimeSpan(0);
        }
    }
}
