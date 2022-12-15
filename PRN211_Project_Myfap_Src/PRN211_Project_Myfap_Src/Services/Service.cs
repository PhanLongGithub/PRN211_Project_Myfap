namespace PRN211_Project_Myfap_Src.Services
{
    public abstract class Service<T>
    {
        public abstract List<T> getList();

        public abstract T getById(int id);

        public abstract void update(int id);

        public abstract bool delete(int id);

        public abstract void Create(T model);
    }
}
