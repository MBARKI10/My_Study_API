using myStudyWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    class UpsessionViewModel
    {
        public ObservableCollection<Upsession> upsessionCollectionItems { get; set; }

        public UpsessionViewModel()
        {
            upsessionCollectionItems = new ObservableCollection<Upsession>();
        }

        public void InsertUpsessions(List<Upsession> upsessions,double width)
        {
            upsessionCollectionItems.Clear();

            foreach (Upsession upsession in upsessions)
            {
                upsession.itemWidth = width;
                upsessionCollectionItems.Add(upsession);
            }
        }
    }
}
