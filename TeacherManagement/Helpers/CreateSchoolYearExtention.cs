using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherManagement.Helpers
{
    public class CreateSchoolYearExtention
    {
        private static int NumberOfYear = 10;
        public static IList<string> CreateSchoolYear()
        {
            IList<string> listYear = new List<string>();

            int year = DateTime.Now.Year + 1;
            for (int i = 0; i < NumberOfYear; i++)
            {
                listYear.Add((year - 1).ToString() + "-" + year.ToString());
                year--;
            }
            return listYear;
        }
    }
}