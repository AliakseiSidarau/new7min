using System.Collections.Generic;
using Zenject;

namespace System
{
    public class DiService: IDiService
    {
        public DiContainer Container = ProjectContext.Instance.Container;

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }
    }
}