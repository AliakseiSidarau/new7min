using System.Collections.Generic;

namespace Core.Di
{
    public interface IDiService
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}