using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    public class KeyStrokeSerializer
    {
        public static List<KeyStroke> Load(string file)
        {
            return File.ReadAllLines(file)
                .Select(l => KeyStroke.FromString(l))
                .ToList();
        }

        public static void Save(string file, List<KeyStroke> strokes)
        {
            File.WriteAllLines(file, strokes
                .Select(s => s.ToString()));
        }
    }
}
