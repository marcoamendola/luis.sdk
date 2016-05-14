using Luis.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.SDK.ClientLibrary.Tests.Fixtures
{

    public class ObjectRemover : IDisposable
    {
        public delegate Task RemoveAsync(string id);

        private readonly List<string> _registeredIds = new List<string>();
        private readonly RemoveAsync _remover;

        public ObjectRemover(RemoveAsync remover)
        {
            _remover = remover;
        }
        public void Register(string id)
        {
            _registeredIds.Add(id);
        }

        public void Dispose()
        {
            foreach (var id in _registeredIds)
            {
                try
                {
                    _remover(id).Wait();
                }
                catch { }
            }
        }


    }
}
