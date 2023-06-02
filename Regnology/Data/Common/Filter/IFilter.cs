using X.PagedList;

namespace Regnology.Data
{
    public interface IFilter<T,V>
    {
        public IPagedList<T> Filter(V request);
    }
}
