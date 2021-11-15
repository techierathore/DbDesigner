namespace DbDesigner.UI.Services
{
    public interface IManageService<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(string aRequestUri);
        Task<List<TEntity>> GetAllSubsAsync(string aRequestUri, long aId);
        Task<List<TEntity>> GetAllByStringAsync(string aRequestUri, string aValue);
        Task<TEntity> GetSingleAsync(string aRequestUri, long aId);
        Task<TEntity> GetIntSingleAsync(string aRequestUri, int aId);
        Task<TEntity> SaveAsync(string aRequestUri, TEntity aObj);
        Task<TEntity> UpdateAsync(string aRequestUri, TEntity aObj);
    }
}
