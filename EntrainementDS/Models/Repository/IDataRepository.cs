namespace EntrainementDS.Models.Repository
{
    public interface IDataRepository<TEntity, Tidentifier, Tkey>    // T générique   TEntity = Classe, Tidentifier = type de l'identifiant (int, string...) , Tkey = type de la clé de recherche (int, string...)
        : SearcheableRepository<TEntity, Tkey>,
          ReadableRepository<TEntity, Tidentifier>,
          WriteableRepository<TEntity>;

    public interface SearcheableRepository<TEntity, Tkey>
    {
        Task<TEntity?> GetByKeyAsync(Tkey str);
    }

    public interface ReadableRepository<TEntity, Tidentifier>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity?>> GetByIdAsync(Tidentifier id);
    }

    public interface WriteableRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
