﻿

#pragma checksum "C:\Users\mouhame\SkyDrive\MyStudy\V1.0.0.1 don't touch_v12\V1.0.0.1 don't touch_v11\V1.0.0.1 don't touch_v11\MyStudyAPI\myStudyWP\Views\SessionView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D9D934F634DE1321808DA8BAB04B22C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myStudyWP.Views
{
    partial class SessionView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 15 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DeleteComment_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 16 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.EditCommen_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 81 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.AddTodo_evnt;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 91 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.AllTodos_ItemClick_1;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 94 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Holding += this.Grid_Holding;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 47 "..\..\Views\SessionView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btEdite_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


