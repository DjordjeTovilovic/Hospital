using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class NeedsVerificationState : IVerificationState
    {
        MedicineService medicineService = new MedicineService();

        public NeedsVerificationState()
        {

        }

        public void Verify(Medicine medicine)
        {
            medicine.Verification = VerificationType.verified;
            medicineService.Update(medicine);
        }

        public void Reject(Medicine medicine)
        {
            medicine.Verification = VerificationType.rejected;
            medicineService.Update(medicine);
        }
    }
}
