﻿using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Structs;
using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Application.Interfaces.Base
{
    public interface IApplicationBase<TEntity, TView, TPost, TPut, TStatus>
               where TView : class where TPost : class where TPut : class where TEntity : EntityBase where TStatus : PutStatusDto
    {
        Task<IEnumerable<TView>> GetAllAsync();

        Task<TView> GetByIdAsync(Guid id);

        Task<EntityToDto<TEntity, TPut>> MapStructById(Guid id);

        Task<TView> PostAsync(TPost post);

        Task<TView> PutAsync(TPut put);

        Task<TView> DeleteAsync(Guid id);

        Task<TView> PutStatusAsync(TStatus status);

        Task<bool> ExisteNaBaseAsync(Guid id);

        Task MapStructSaveChangesAsync(EntityToDto<TEntity, TPut> dtoStruct);
    }
}