using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
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
    [TemplatePart(Name = "PART_ChromeClose", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ChromeMaximize", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ChromeMaxImage", Type = typeof(Image))]
    [TemplatePart(Name = "PART_ChromeMinimize", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ChromeNormal", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ChromeDrag", Type = typeof(Grid))]
    //[TemplatePart(Name = "PART_ChromeResize", Type = typeof(ResizeGrip))]
    [TemplatePart(Name = "PART_WindowTitle", Type = typeof(Label))]
    [TemplatePart(Name = "PART_TitleStackPanel", Type = typeof(StackPanel))]
    [TemplatePart(Name = "PART_ChromeButtonPanel", Type = typeof(StackPanel))]    
    public class BorderlessWindowBasic : Window
    {
        static BorderlessWindowBasic()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderlessWindowBasic), new FrameworkPropertyMetadata(typeof(BorderlessWindowBasic)));
        }




        #region Dependency properties
        /// <summary>
        /// Set and get title bar background
        /// </summary>
        public static DependencyProperty TitleBarBackgroundProperty = DependencyProperty.Register("TitleBarBackground", typeof(Brush), typeof(BorderlessWindowBasic), new PropertyMetadata(Brushes.White));
        public Brush TitleBarBackground
        {
            get { return (Brush)GetValue(TitleBarBackgroundProperty); }
            set { SetValue(TitleBarBackgroundProperty, value); }
        }

        /// <summary>
        /// Set and get title bar foreground color.
        /// </summary>
        //public static DependencyProperty TitleBarForegroundProperty = DependencyProperty.Register("TitleBarForeground", typeof(Brush), typeof(BorderlessWindowBasic), new PropertyMetadata(Brushes.Black));
        //public Brush TitleBarForeground
        //{
        //    get { return (Brush)GetValue(TitleBarForegroundProperty); }
        //    set { SetValue(TitleBarForegroundProperty, value); }
        //}


        public static DependencyProperty ChromeButtonHighlightProperty = DependencyProperty.Register("ChromeButtonHighlight", typeof(Brush), typeof(BorderlessWindowBasic), new PropertyMetadata(Brushes.White));
        public Brush ChromeButtonHighlight
        {
            get { return (Brush)GetValue(ChromeButtonHighlightProperty); }
            set { SetValue(ChromeButtonHighlightProperty, value); }
        }


        public static DependencyProperty TitleContentProperty = DependencyProperty.Register("TitleContent", typeof(UIElement), typeof(BorderlessWindowBasic));
        public UIElement TitleContent
        {
            get { return (UIElement)GetValue(TitleContentProperty); }
            set { SetValue(TitleContentProperty, value); }
        }


        public static DependencyProperty MaximizeButtonVisibilityProperty = DependencyProperty.Register("MaximizeButtonVisibility", typeof(Visibility), typeof(BorderlessWindowBasic), new PropertyMetadata(Visibility.Visible));
        public Visibility MaximizeButtonVisibility
        {
            get { return (Visibility)GetValue(MaximizeButtonVisibilityProperty); }
            set { SetValue(MaximizeButtonVisibilityProperty, value); }
        }

        public static DependencyProperty MinimizeButtonVisibilityProperty = DependencyProperty.Register("MinimizeButtonVisibility", typeof(Visibility), typeof(BorderlessWindowBasic), new PropertyMetadata(Visibility.Visible));
        public Visibility MinimizeButtonVisibility
        {
            get { return (Visibility)GetValue(MinimizeButtonVisibilityProperty); }
            set { SetValue(MinimizeButtonVisibilityProperty, value); }
        }


        public static DependencyProperty ChromeButtonPaddingProperty = DependencyProperty.Register("ChromeButtonPadding", typeof(Thickness), typeof(BorderlessWindowBasic), new PropertyMetadata(new Thickness(8)));
        public Thickness ChromeButtonPadding
        {
            get { return (Thickness)GetValue(ChromeButtonPaddingProperty); }
            set { SetValue(ChromeButtonPaddingProperty, value); }
        }

        public static DependencyProperty ChromeButtonMarginProperty = DependencyProperty.Register("ChromeButtonMargin", typeof(Thickness), typeof(BorderlessWindowBasic), new PropertyMetadata(new Thickness(0)));
        public Thickness ChromeButtonMargin
        {
            get { return (Thickness)GetValue(ChromeButtonMarginProperty); }
            set { SetValue(ChromeButtonMarginProperty, value); }
        }

        #endregion



        #region Data
        private Button mChromeMax;
        private Image mChromeMaxImage;
        private Point mLeftMouseDownPoint;

        //private Uri mMaximizeImageURI = new Uri("/TMTech.Shared.WPFLIB;component/Images/ChromeMaximize_16.png");
        private static ImageSource mMaximizeImageSource = new ImageSourceConverter().ConvertFromString("pack://application:,,,/TMTech.Shared.WPFLIB;component/Images/ChromeMaximize_16.png") as ImageSource;
        private static ImageSource mNormalImageSource = new ImageSourceConverter().ConvertFromString("pack://application:,,,/TMTech.Shared.WPFLIB;component/Images/ChromeNormal_16.png") as ImageSource;
        //private Uri mNormalImageURI = new Uri("/TMTech.Shared.WPFLIB;component/Images/ChromeNormal_16.png");
        private bool mCanResize;




        /// <summary>
        /// Get the stack panel for the title
        /// </summary>
        public StackPanel TitleStackPanel
        {
            get
            {
                return (StackPanel)Template.FindName("PART_TitleStackPanel", this);
            }
        }
        
        #endregion



        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BorderlessWindowBasic(bool canResize = true)
        {
            //this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
            mCanResize = canResize;
            this.WindowStyle = System.Windows.WindowStyle.None;
            //this.AllowsTransparency = true;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Loaded += BorderlessWindowBasic_Loaded;

            //this.MouseMove += BorderlessWindow_MouseMove;
            this.SourceInitialized += BorderlessWindow_SourceInitialized;
        }

        void BorderlessWindow_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(WindowProc));
        }


        /// <summary>
        /// Execute after loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BorderlessWindowBasic_Loaded(object sender, RoutedEventArgs e)
        {
            var chromeClose = (Button)Template.FindName("PART_ChromeClose", this);
            chromeClose.Click += chromeClose_Click;


            mChromeMax = (Button)Template.FindName("PART_ChromeMaximize", this);
            mChromeMaxImage = (Image)Template.FindName("PART_ChromeMaxImage", this);
            mChromeMax.Click += chromeMaximize_Click;

            var chromeMin = (Button)Template.FindName("PART_ChromeMinimize", this);
            chromeMin.Click += chromeMinimize_Click;

            var chromeDrag = (Grid)Template.FindName("PART_ChromeDrag", this);
            chromeDrag.MouseLeftButtonDown += chromeDrag_MouseLeftButtonDown;
            chromeDrag.MouseMove += chromeDrag_MouseMove;


            if (mCanResize)
            {
                SetEventHandlerForResizePanel("PART_BottomResize");
                SetEventHandlerForResizePanel("PART_TopResize");
                SetEventHandlerForResizePanel("PART_LeftResize");
                SetEventHandlerForResizePanel("PART_RightResize");
                SetEventHandlerForResizePanel("PART_WindowBorder");
                SetEventHandlerForResizePanel("PART_TopLeftResize");
                SetEventHandlerForResizePanel("PART_TopRightResize");
                SetEventHandlerForResizePanel("PART_BottomLeftResize");
                SetEventHandlerForResizePanel("PART_BottomRightResize");
            }

        }


        #endregion


        
        #region chrome button handlers

    
        private void chromeDrag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                processMaximizedButtonClick();
            }
            else
            {
                mLeftMouseDownPoint = e.GetPosition(this);

                //if (this.WindowState == System.Windows.WindowState.Maximized)
                //{

                //    // get the screen where the window is located.
                //    var srn = ScreenHandler.GetCurrentScreen(this);

                //    // get window width
                //    double width = this.Width;


                //    // get mouse position
                //    var p = e.GetPosition(this);


                //    // mouse position portion wition the window
                //    double factor = p.X / width;

                //    this.WindowState = System.Windows.WindowState.Normal;
                //    this.Left = srn.WorkingArea.Left + p.X - this.Width * factor;
                //    this.Top = srn.WorkingArea.Top + 4;
                //}

                //this.DragMove();
            }
        }

        

        void chromeDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && MovedMinimumDistance(e))
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                {

                    // find the chrome button panel width
                    double chromeButtonPanelWidth = 0;
                    var stackPanel = Template.FindName("PART_ChromeButtonPanel", this) as StackPanel;
                    if (stackPanel != null)
                        chromeButtonPanelWidth = stackPanel.ActualWidth;


                    // get the screen where the window is located.
                    var srn = ScreenHandler.GetCurrentScreen(this);

                    // get window width
                    double width = this.Width;


                    // get mouse position
                    var p = e.GetPosition(this);


                    // mouse position portion wition the window
                    double factor = p.X / (width - chromeButtonPanelWidth);

                    this.WindowState = System.Windows.WindowState.Normal;
                    this.Left = srn.WorkingArea.Left + p.X - (this.Width - chromeButtonPanelWidth) * factor;
                    this.Top = srn.WorkingArea.Top + 4;

                    SetIcon();

                }

                this.DragMove();
            }
        }



        /// <summary>
        /// Detect the minimum distance movement required to dragdrop the window.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool MovedMinimumDistance(MouseEventArgs e)
        {
            var pos = e.GetPosition(this);
            double minDistance = SystemParameters.MinimumHorizontalDragDistance / 3;  // devide by 2 to make more sensitive
            return Math.Abs(pos.X - mLeftMouseDownPoint.X) > minDistance || Math.Abs(pos.Y - mLeftMouseDownPoint.Y) > minDistance;

        }

        

        private void chromeClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        void chromeMaximize_Click(object sender, RoutedEventArgs e)
        {
            processMaximizedButtonClick();
        }



        /// <summary>
        /// Changes the icons the button showing normal or max status.
        /// </summary>
        private void processMaximizedButtonClick()
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
                //RefreshWindowVisibility(this);

            }
            else if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }

            SetIcon();

        }



        private void chromeMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }


        #endregion


        
        #region Resize related.

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Attach this to the MouseDown event of your drag control to move the window in place of the title bar
        private void WindowDrag(object sender, MouseButtonEventArgs e) // MouseDown
        {
            ReleaseCapture();
            SendMessage(new WindowInteropHelper(this).Handle,
                0xA1, (IntPtr)0x2, (IntPtr)0);
        }


        //Attach this to the PreviewMousLeftButtonDown event of the grip control in the lower right corner of the form to resize the window
        private void WindowResize(object sender, MouseButtonEventArgs e) //PreviewMousLeftButtonDown
        {
            HwndSource hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;

            SendMessage(hwndSource.Handle, 0x112, (IntPtr)61448, IntPtr.Zero);
        }

        private void WindowNSResize(object sender, MouseButtonEventArgs e) //PreviewMousLeftButtonDown
        {
            HwndSource hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;

            var panel = sender as DockPanel;
            if (panel != null)
            {
                switch (panel.Name)
                {
                    case "PART_TopResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61443, IntPtr.Zero);
                        break;
                    case "PART_BottomResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61446, IntPtr.Zero);
                        break;
                    case "PART_LeftResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61441, IntPtr.Zero);
                        break;
                    case "PART_RightResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61442, IntPtr.Zero);
                        break;


                    // the following panels are not added yet.
                    case "PART_TopLeftResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61444, IntPtr.Zero);
                        break;
                    case "PART_TopRightResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61445, IntPtr.Zero);
                        break;
                    case "PART_BottomLeftResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61447, IntPtr.Zero);
                        break;
                    case "PART_BottomRightResize":
                        SendMessage(hwndSource.Handle, 0x112, (IntPtr)61448, IntPtr.Zero);
                        break;

                }
            }

        }





        // if we want to resize from all sides::
        // Here are the other wParam values, just assign new events to new UI Objects using these as needed 
        // private enum ResizeDirection { Left = 61441, Right = 61442, Top = 61443, TopLeft = 61444, TopRight = 61445, Bottom = 61446, BottomLeft = 61447, BottomRight = 61448, }


        #endregion

        

        #region Private methods            


        /// <summary>
        /// Set event handlers for specified dock panel
        /// </summary>
        /// <param name="partName"></param>
        private void SetEventHandlerForResizePanel(string partName)
        {
            var dockPanel = Template.FindName(partName, this) as DockPanel;
            if (dockPanel != null)
            {
                dockPanel.MouseLeftButtonDown += WindowNSResize;
                dockPanel.MouseEnter += chromeResize_MouseEnter;
                dockPanel.MouseLeave += chromeResize_MouseLeave;
            }
        }

        
        /// <summary>
        /// Set the icon for the button for Maximize and minimize
        /// </summary>
        void SetIcon()
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
                mChromeMaxImage.Source = mNormalImageSource;
            else
                mChromeMaxImage.Source = mMaximizeImageSource;

        }

        
        void chromeResize_MouseEnter(object sender, MouseEventArgs e)
        {
            //var resizeGrip = sender as ResizeGrip;
            //if (resizeGrip != null)
            //{
            //    this.Cursor = Cursors.SizeNWSE;
            //    return;
            //}

            var dockPanel = sender as DockPanel;
            if (dockPanel != null)
            {
                switch (dockPanel.Name)
                {
                    case "PART_BottomResize":
                    case "PART_TopResize":
                        this.Cursor = Cursors.SizeNS;
                        break;

                    case "PART_LeftResize":
                    case "PART_RightResize":
                        this.Cursor = Cursors.SizeWE;
                        break;

                    case "PART_TopLeftResize":
                    case "PART_BottomRightResize":
                        this.Cursor = Cursors.SizeNWSE;
                        break;

                    case "PART_TopRightResize":
                    case "PART_BottomLeftResize":
                        this.Cursor = Cursors.SizeNESW;
                        break;

                }
                return;
            }

            //var border = sender as Border;
            //if (border != null)
            //{
            //    this.Cursor = Cursors.SizeNS;         
            //}


        }


        void chromeResize_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        #endregion



        #region Solving oavelap taskbar problem when Window is maximized.

        /// <summary>
        /// POINT aka POINTAPI
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }



        /// <summary> Win32 </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }


        }



        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        /// <summary>
        /// 
        /// </summary>
        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);



        //A better way to get the handle to the window is to use the SourceInitialized event. This would also avoid calling ApplyTemplate everytime the window template is changedon the fly. Thanks to Hamid for pointing out the better solution. The attached project is now updated.
        //public override void OnApplyTemplate()
        //{
        //    System.IntPtr handle = (new WindowInteropHelper(this)).Handle;
        //    HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
        //}


        private static System.IntPtr WindowProc(System.IntPtr hwnd, int msg, System.IntPtr wParam, System.IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }


        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }


        #endregion

        


    }
}
