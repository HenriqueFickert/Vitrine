﻿using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<PagedList<Produto>> GetPaginationAsync(ParametersProduto parametersProduto);

        bool ValidarId(Guid id);
    }
}