using AutoMapper;
using CustomerCloud.Entities;
using CustomerCloud.Repository;
using System;

namespace CustomerCloud.Logic
{
    public class BaseLogic<TEntity, TDTO> : ILogic<TDTO> where TEntity : class, IEntity
    {
        private Repository<TEntity> _repo;
        private IMapper _mapConfig;

        public BaseLogic()
        {
            _mapConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TEntity, TDTO>();
                    cfg.CreateMap<TDTO, TEntity>();
                }).CreateMapper();
            _repo = new Repository<TEntity>();
        }

        public void Create(TDTO item)
        {
            TEntity entity = _mapConfig.Map<TEntity>(item);
            _repo.Create(entity);
        }

        public void Delete(Guid Id)
        {
            _repo.Delete(Id);
        }

        public TDTO Read(Guid Id)
        {
            return _mapConfig.Map<TDTO>(_repo.Read(Id));
        }

        public void Update(TDTO item)
        {
            TEntity entity = _mapConfig.Map<TEntity>(item);
            _repo.Update(entity);
        }
    }
}
