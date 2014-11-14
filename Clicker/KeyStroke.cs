using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    public class KeyStroke
    {
        public List<Microsoft.Test.Input.Key> MsTestKeys { get; set; }

        public override string ToString()
        {
            return string.Join(" + ", MsTestKeys.Select(k => k.ToString()));
        }

        public static KeyStroke FromString(string text)
        {
            return new KeyStroke 
            { 
                MsTestKeys = string.IsNullOrEmpty(text) ? 
                    new List<Microsoft.Test.Input.Key>() :
                    text
                        .Split('+')
                        .Select(p => (Microsoft.Test.Input.Key)Enum.Parse(typeof(Microsoft.Test.Input.Key), p.Trim()))
                        .ToList()
            };
        }

        public KeyStroke Clone()
        {
            return new KeyStroke { MsTestKeys = MsTestKeys };
        }
    }
}
