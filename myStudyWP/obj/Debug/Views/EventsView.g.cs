﻿

#pragma checksum "C:\Users\mouhame\SkyDrive\MyStudy\V1.0.0.1 don't touch_v15\V1.0.0.1 don't touch_v12\V1.0.0.1 don't touch_v11\V1.0.0.1 don't touch_v11\MyStudyAPI\myStudyWP\Views\EventsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7F5B1EC7D28D0AAEDCA2EB77101AEA88"
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
    partial class EventsView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DeleteComment_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 15 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.EditCommen_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 79 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnAddEvent_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 36 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.AllEvents_ItemClick;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 39 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Holding += this.Grid_Holding;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 27 "..\..\Views\EventsView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btEdite_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

