   M S B A M L   `   `   `  ����O  KTMTech.Shared.WPFLIB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TMTech.Shared.WPFLIB.ControlsTMTech.Shared.WPFLIB.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source1    +TMTech.Shared.WPFLIB.Controls.MessageDialog �� 
TargetType9   3TMTech.Shared.WPFLIB.Controls.BorderlessWindowBasic �� BasedOn �� Property �� Value �� 
TargetType �� Padding � RowDefinitions	   TitleBarBackground
 � ColumnDefinitions � Title �� Orientation0   *TMTech.Shared.WPFLIB.Controls.ChromeButton   ChromeButtonHighlight   ChromeButtonHighlight   ChromeButtonPadding   ChromeButtonMargin   MinimizeButtonVisibility   ChromeImageStyle   MaximizeButtonVisibility �� TextWrapping �� 
IsReadOnly J� SnapsToDevicePixels�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local+clr-namespace:TMTech.Shared.WPFLIB.Controls  5        5      �� 5   
   $7 1/TMTech.Shared.WPFLIB;component/Themes/Basic.xaml?�6   6[   �� 5	   
   $G A/TMTech.Shared.WPFLIB;component/Themes/BorderlessWindowBasic.xaml?�6   6k   %�  '         7 7   7   7   �� 5D      "   6   8   .�5E   
   ��  � ��$	 500��6%   �� 5F   
    � ��$	 300��6%   �� 5G   
    � ��$	 800��6&   �� 5H   
    � ��$	 200��6&   �� 5I   
    �@�SizeToContent$ WidthAndHeight=�6*   �� 5J   
    �@ ChromeButtonHighlight �#dddddd62   �� 5K   
     �@ MaximizeButtonVisibility$ 	Collapsed=�65   �� 5L   
     �@ MinimizeButtonVisibility$ 	Collapsed=�65   �� 5M   
    � ��$ 1q�6,   �� 5N   
    � �� �#9999996(   �� 5O   
    � �� 5P      �� 5Q      "   6"   .R�5R      �� $��PART_WindowBorder��6   #��z��66   #��z��6b   $ 0q�6�   ._�5T      � $��PART_RootGrid��6   #��z��64    5U      �� 5V   "   $
��Auto �60   �� 5W   "   $��* �60   �� 5X   "   $
��Auto �60   .+�5]      � $��PART_ChromeDrag��6#   #��z	 6:   $��0q�6l   
 5^   "   �� 5_   &   $��* �67   �� 5`   &   $
��Auto �67   .+�5c   "   �� .��5d   &   �� #��z 6,   $��18(�6N   $��10q�6\   5e   #   �� 5h   "   $��1��6-   $	��Top=�6=   $ 
Horizontal=�6U   .+�5i   &     $��PART_ChromeMinimize��69   # z 6T   #��z 6�   #��z 6�   #y�z 6�   ��5j   *   �� 5k   .   $B��</TMTech.Shared.WPFLIB;component/Images/ChromeMinimize_16.png��64   8�� 6�   5m   '     5o   &   $��PART_ChromeMaximize��69   # z 6T   #��z 6�   #��z 6�   #y�z 6�   ��5p   *   �� 5q   .   $��PART_ChromeMaxImage��64   $B��</TMTech.Shared.WPFLIB;component/Images/ChromeMaximize_16.png��6O   8�� 6�   5s   '     5u   &   $��PART_ChromeClose��69   # z 6Q   #��z 6�   #��z 6�   ��5v   *   �� 5w   .   $9��3/TMTech.Shared.WPFLIB;component/Images/Close_16.png��64   8�� 6�   5y   '   5{   #   5}      � 5�      $��1��6#    5�   "   �� 5�   &   $
��Auto �64   �� 5�   &   $��* �64   �� 5�   &   $
��Auto �64   .+�5�   "   �� $
��Auto=�6/   $��1��6R   .��5�   &   �� $��PART_MESSAGE��6.   $��15q�6B   $
��Left=�6N   $
 Wrap=�6i   $
��Auto��6}    .  . $��0q�6�   5�   #   �� 5�   "   $��PART_OK��6)   $��2��68   $��Center=�6E   $��Center=�6b   $��20q�6}   $��60��6�   .��6�   Ok6�   5�      5�      5�      5�      5�      5�      5�      