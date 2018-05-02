using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTableSample.Models
{
    public class DataTable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public Student[] data { get; set; }
    }
}