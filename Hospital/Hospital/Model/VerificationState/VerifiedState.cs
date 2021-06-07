using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class VerifiedState : IVerificationState
    {
        MedicineService medicineService = new MedicineService();

        public VerifiedState()
        {

        }

        public void Verify(Medicine medicine)
        {
            return;
        }

        public void Reject(Medicine medicine)
        {
            medicine.Verification = VerificationType.rejected;
            medicineService.Update(medicine);
        }
    }
}
