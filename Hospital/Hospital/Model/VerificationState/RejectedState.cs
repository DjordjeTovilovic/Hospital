using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class RejectedState : IVerificationState
    {
        MedicineService medicineService = new MedicineService();

        public RejectedState()
        {

        }

        public void Verify(Medicine medicine)
        {
            medicine.Verification = VerificationType.rejected;
            medicineService.Update(medicine);
        }

        public void Reject(Medicine medicine)
        {
            return;
        }
    }
}
