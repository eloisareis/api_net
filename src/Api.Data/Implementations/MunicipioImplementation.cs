using System;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.Uf)
                                 .FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(m => m.Uf)
                                 .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
