namespace EntrainementDS.Models.Repository
{
    public interface IDataRepository<TEntity, Tidentifier, Tkey>    // T générique   TEntity = Classe, Tidentifier = type de l'identifiant (int, string...) , Tkey = type de la clé de recherche (int, string...)
        : ISearcheableRepository<TEntity, Tkey>,
          IReadableRepository<TEntity, Tidentifier>,
          IWriteableRepository<TEntity>;

    public interface ISearcheableRepository<TEntity, Tkey>
    {
        Task<TEntity?> GetByKeyAsync(Tkey str);
    }

    public interface IReadableRepository<TEntity, Tidentifier>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Tidentifier id);
        Task<TEntity> GetByName(string str);
    }

    public interface IWriteableRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
