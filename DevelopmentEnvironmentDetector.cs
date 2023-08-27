using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public static class DevelopmentEnvironmentDetector
    {
        public static bool IsDevelopmentEnvironment()
        {
            bool isDevelopment = false;

#if DEBUG
            isDevelopment = true;
#endif

#if RELEASE
            isDevelopment = false;
#endif

            // You can add more conditions here to refine the detection further
            // For example, checking for environment variables, configuration settings, etc.

            return isDevelopment;
        }
    }
}
