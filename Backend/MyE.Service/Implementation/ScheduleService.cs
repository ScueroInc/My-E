using System.Collections.Generic;
using MyE.Entity;

namespace MyE.Service.implementation
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleService scheduleRepository;
        public ScheduleService(IScheduleService scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }
         public bool Delete(int id)
        {
           return  this.scheduleRepository.Delete(id);
        }

        public Schedule Get(int id)
        {
            return this.scheduleRepository.Get(id);
        }

        public IEnumerable<Schedule> GetAll()
        {
           return this.scheduleRepository.GetAll();
        }

        public bool Save(Schedule entity)
        {
           return  this.scheduleRepository.Save(entity);
        }

        public bool Update(Schedule entity)
        {
            return this.scheduleRepository.Update(entity);
        }
    }
}