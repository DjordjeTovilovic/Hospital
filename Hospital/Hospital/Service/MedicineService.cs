using Hospital.Model;
using Model;
using Repository;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Service
{
    public class MedicineService
    {
        private IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public MedicineService()
        {
            _medicineRepository = new MedicineRepository();
        }

        public List<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public List<Medicine> GetByVerification(VerificationType verification)
        {
            return _medicineRepository.GetByVerification( verification);
        }
        public List<Medicine> GetNotRejected()
        {
            return _medicineRepository.GetNotRejected();
        }

        public Medicine GetById(int id)
        {
            return _medicineRepository.GetById(id);
        }

        public Medicine GetByName(string name)
        {
            return _medicineRepository.GetByName(name);
        }

        public void Save(string name, string description)
        {
            int id = _medicineRepository.GenerateNewId();
            Medicine medicine = new Medicine(id, name, description, "")
            {
                Verification = VerificationType.needsVerification
            };
            _medicineRepository.Save(medicine);
        }

        public void Delete(int id)
        {
            _medicineRepository.Delete(id);
        }

        public void Update(int id, string name, VerificationType verification, string description)
        {
            Medicine medicine = GetById(id);
            medicine.Name = name;
            medicine.Verification = verification;
            medicine.Description = description;
            _medicineRepository.Update(medicine);
        }

        public void Update(Medicine medicine)
        {
            _medicineRepository.Update(medicine);
        }

        public void Verify(int id)
        {
            Medicine medicine = GetById(id);

            switch (medicine.Verification)
            {
                case VerificationType.needsVerification:
                    medicine.VerificationState = new NeedsVerificationState();
                    break;
                case VerificationType.verified:
                    medicine.VerificationState = new VerifiedState();
                    break;
                case VerificationType.rejected:
                    medicine.VerificationState = new RejectedState();
                    break;
            }

            medicine.VerificationState.Verify(medicine);
        }

        public void Reject(int id, string doctorComment)
        {
            Medicine medicine = GetById(id);
            medicine.DoctorComment = doctorComment;

            switch (medicine.Verification)
            {
                case VerificationType.needsVerification:
                    medicine.VerificationState = new NeedsVerificationState();
                    break;
                case VerificationType.verified:
                    medicine.VerificationState = new VerifiedState();
                    break;
                case VerificationType.rejected:
                    medicine.VerificationState = new RejectedState();
                    break;
            }

            medicine.VerificationState.Reject(medicine);
        }


        public int GenerateNewId()
        {
            return _medicineRepository.GenerateNewId();
        }
    }
}