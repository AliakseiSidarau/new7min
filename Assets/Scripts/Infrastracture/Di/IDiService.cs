using System.Collections.Generic;

namespace System
{
    public interface IDiService
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}