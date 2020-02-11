using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStudyWP.Models;

namespace myStudyWP.ViewModel
{
    class ReportViewModel
    {
        public ObservableCollection<Report> ReportollectionItems { get; set; }

    public ReportViewModel()
        {
            ReportollectionItems = new ObservableCollection<Report>();
        }

    public void InsertReports(List<Report> Reports, double width)
        {
            ReportollectionItems.Clear();

            foreach (Report report in Reports)
            {
                report.itemWidth = width;
                ReportollectionItems.Add(report);
            }
        }
    }
}
