using System.Collections.Generic;
using MyE.Entity;

namespace MyE.Service.implementation
{
    public class RoleService : IRoleService
    {
        private IRoleService roleRepository;
        public RoleService(IRoleService roleRepository)
        {
           this.roleRepository = roleRepository;
        }

         public bool Delete(int id)
        {
      return this.roleRepository.Delete(id);
        }

        public Role Get(int id)
        {
          return this.roleRepository.Get(id);
        }

        public IEnumerable<Role> GetAll()
        {
         return this.roleRepository.GetAll();
        }

        public bool Save(Role entity)
        {
          return this.roleRepository.Save(entity);
        }

        public bool Update(Role entity)
        {
          return this.roleRepository.Update(entity);
        }
    }
}