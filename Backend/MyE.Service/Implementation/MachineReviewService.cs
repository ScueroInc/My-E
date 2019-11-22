using System.Collections.Generic;
using MyE.Entity;

namespace MyE.Service.implementation
{
    public class MachineReviewService : IMachineReviewService
    {
        private IMachineReviewService machineReviewRepository;
        public MachineReviewService(IMachineReviewService machineReviewRepository)
        {
            this.machineReviewRepository = machineReviewRepository;
        }
        public bool Delete(int id)
        {
           return this.machineReviewRepository.Delete(id);
        }

        public MachineReview Get(int id)
        {
           return this.machineReviewRepository.Get(id);
        }

        public IEnumerable<MachineReview> GetAll()
        {
           return this.machineReviewRepository.GetAll();
        }

        public bool Save(MachineReview entity)
        {
           return this.machineReviewRepository.Save(entity);
        }

        public bool Update(MachineReview entity)
        {
           return this.machineReviewRepository.Update(entity);
        }
    }
}