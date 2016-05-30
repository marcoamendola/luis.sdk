using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests.Fixtures
{
    public static class Fixtures
    {
        public static void Initialize(this IFixture fixture) {
            AppFixtures.InitializeAppBuilder(fixture);
            IntentFixtures.InitializeIntentBuilder(fixture);
            EntityFixtures.InitializeEntityBuilder(fixture);
            ActionFixtures.InitializeActionBuilder(fixture);
        }
    }
}
