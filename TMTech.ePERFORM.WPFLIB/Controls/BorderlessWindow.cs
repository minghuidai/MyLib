using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinInterop = System.Windows.Interop;

namespace TMTech.Shared.WPFLIB.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TMTech.ePERFORM.WPF.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TMTech.ePERFORM.WPF.Controls;assembly=TMTech.ePERFORM.WPF.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ePerformTMTechWindow/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = "PART_WindowTitle", Type = typeof(Label))]
    [TemplatePart(Name = "PART_StatusBar", Type = typeof(Label))]    
    public class BorderlessWindow : BorderlessWindowBasic
    {
        static BorderlessWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderlessWindow), new FrameworkPropertyMetadata(typeof(BorderlessWindow)));
        }


        #region Dependency properties
        /// <summary>
        /// Set and get title bar background
        /// </summary>
        //public static DependencyProperty TitleBarBackgroundProperty = DependencyProperty.Register("TitleBarBackground", typeof(Brush), typeof(BorderlessWindow), new PropertyMetadata(Brushes.White));
        //public Brush TitleBarBackground
        //{
        //    get { return (Brush)GetValue(TitleBarBackgroundProperty); }
        //    set { SetValue(TitleBarBackgroundProperty, value); }
        //}

        /// <summary>
        /// Set and get title bar foreground color.
        /// </summary>
        public static DependencyProperty TitleBarForegroundProperty = DependencyProperty.Register("TitleBarForeground", typeof(Brush), typeof(BorderlessWindow), new PropertyMetadata(Brushes.Black));
        public Brush TitleBarForeground
        {
            get { return (Brush)GetValue(TitleBarForegroundProperty); }
            set { SetValue(TitleBarForegroundProperty, value); }
        }


        /// <summary>
        /// Set or get status bar background
        /// </summary>
        public static DependencyProperty StatusBarBackgroundProperty = DependencyProperty.Register("StatusBarBackground", typeof(Brush), typeof(BorderlessWindow), new PropertyMetadata(Brushes.White));
        public Brush StatusBarBackground
        {
            get { return (Brush)GetValue(StatusBarBackgroundProperty); }
            set { SetValue(StatusBarBackgroundProperty, value); }
        }



        /// <summary>
        /// Gets or set the status bar foreground
        /// </summary>
        public static DependencyProperty StatusBarForegroundProperty = DependencyProperty.Register("StatusBarForeground", typeof(Brush), typeof(BorderlessWindow), new PropertyMetadata(Brushes.Black));
        public Brush StatusBarForeground
        {
            get { return (Brush)GetValue(StatusBarForegroundProperty); }
            set { SetValue(StatusBarForegroundProperty, value); }
        }




        public static DependencyProperty IconVisibilityProperty = DependencyProperty.Register("IconVisibility", typeof(Visibility), typeof(BorderlessWindow), new PropertyMetadata(Visibility.Visible));
        public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }


        /// <summary>
        /// Defines the statusbar visibility
        /// </summary>
        public static DependencyProperty StatusBarVisibilityProperty = DependencyProperty.Register("StatusBarVisibility", typeof(Visibility), typeof(BorderlessWindow), new PropertyMetadata(Visibility.Visible));
        public Visibility StatusBarVisibility
        {
            get { return (Visibility)GetValue(StatusBarVisibilityProperty); }
            set { SetValue(StatusBarVisibilityProperty, value); }
        }



        /// <summary>
        /// Status property
        /// </summary>
        public static DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(BorderlessWindow));
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        #endregion





        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BorderlessWindow(bool canResize = true) :base(canResize)
        {
        }
        #endregion
    }


}
