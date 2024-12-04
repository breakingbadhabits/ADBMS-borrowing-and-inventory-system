using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherSample
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }

        // Clear session when the user logs out
        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
        }
    }

}
