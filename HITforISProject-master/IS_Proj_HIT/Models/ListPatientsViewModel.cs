using IS_Proj_HIT.Models.ViewModels;
using isprojectHiT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_Proj_HIT.Models.ViewModels
{
    public class ListPatientsViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public int ReligionId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Religion> Religions { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public Patient patientvm { get; set; }
        public Religion religionvm { get; set; }

    }
}
