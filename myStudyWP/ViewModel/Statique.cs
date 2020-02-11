using myStudyWP.Models;
using myStudyWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStudyWP.ViewModel
{
    static class Statique
    {
        public static ClasseViewModel _ClasseViewModel = new ClasseViewModel();
        public static PostViewModel _PostViewModel = new PostViewModel();
        public static TodoViewModel _TodoViewModel = new TodoViewModel();
        public static TodoCommentViewModel _TodoCommentViewModel = new TodoCommentViewModel();
        public static EventCommentViewModel _EventCommentViewModel = new EventCommentViewModel();
        public static PostCommentViewModel _PostCommentViewModel = new PostCommentViewModel();
        public static LikeViewModel _LikeViewModel = new LikeViewModel();
        public static EventViewModel _EventViewModel = new EventViewModel();
        public static DoneViewModel _DoneViewModel = new DoneViewModel();
        public static ParticipateViewModel _ParticipateViewModel = new ParticipateViewModel();
        public static UpsessionViewModel _UpsessionViewModel = new UpsessionViewModel();
        public static ReportViewModel _sViewModel = new ReportViewModel();
        public static User _LoggedUser = new User();
        public static TodayViewModel _TodayViewModel = new TodayViewModel();
    }
}
