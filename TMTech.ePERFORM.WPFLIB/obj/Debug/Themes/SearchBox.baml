   M S B A M L   `   `   `  ����O  KTMTech.Shared.WPFLIB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TMTech.Shared.WPFLIB.ControlsTMTech.Shared.WPFLIB.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SearchTextBox_Background  �� Color  SearchTextBox_Border ! SearchTextBox_BorderMouseOver �� 
StartPoint �� EndPoint � Color � Offset , (SearchTextBox_SearchIconBorder_MouseOver 0 ,SearchTextBox_SearchIconBackground_MouseOver , (SearchTextBox_SearchIconBorder_MouseDown " SearchTextBox_SearchIconBorder & "SearchTextBox_SearchIconBackground  SearchTextBox_Foreground  	 SearchTextBox_LabelTextColor 0
 ,SearchTextBox_SearchIconBackground_MouseDown1    +TMTech.Shared.WPFLIB.Controls.SearchTextBox �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� Padding �Name � ColumnDefinitions �� RelativeSource �� Path ��Name ��Name ��Name J� Opacity �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value �� 
SourceName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local+clr-namespace:TMTech.Shared.WPFLIB.Controls  5      %�  &	        &	 !     &	 B     &	     &	 0    &	 -    &	 �    &	 �    &	     &		 $    &	
 B    '   ?    7  7   7  7 	 7  7   7  7  7  7  7  7 
 �� 5      $  #ffffff��67   �� 5
      $  #cccccc��63   �� 5      $	 0,0&�6@   $	 0,1&�6Q   .��5   
   � $ 	#FF5C97C1��6   $
 0.05Q�6)   � 5   
   $ 	#FFB9D7EB��6   $
 0.07Q�6)   � 5   
   $ 	#FFC7E2F1��6   $ 1Q�6)   5      �� 5      $  Orange��6G   �� 5      $	 0,0&�6O   $	 0,1&�6`   .��5    
   � $ 	#FFE7F5FD��6   $ 0Q�6)   � 5!   
   $ 	#FFD2EDFC��6   $	 0.5Q�6)   � 5"   
   $ 	#FFB6E3FD��6   $
 0.51Q�6)   � 5#   
   $ 	#FF9DD5F3��6   $ 1Q�6)   5$      �� 5&      $	 0,0&�6K   $	 0,1&�6\   .��5'   
   � $ 	#FFFFFFFF��6   $ 0Q�6)   � 5(   
   $ 	#FFE5F4FC��6   $ 1Q�6)   5)      �� 5+      $  White��6=   �� 5,      $  White��6A   �� 5.      $  #444444��67   �� 5/      $
  Gray��6;   �� 51      $	 0,0&�6O   $	 0,1&�6`   .��52   
   � $ 	#FFE7F5FD��6   $ 0Q�6)   � 53   
   $ 	#FFD2EDFC��6   $	 0.5Q�6)   � 54   
   $ 	#FFB6E3FD��6   $
 0.51Q�6)   � 55   
   $ 	#FF9DD5F3��6   $ 1Q�6)   56      �� 5=      "   61   .�5>   
   ��  � ��8   6'   �� 5?   
    � ��8  6'   �� 5@   
    � ��8  6(   �� 5A   
    � ��$ 1q�6,   �� 5B   
    �@J�SnapsToDevicePixels . 60   �� 5C   
    �@  	LabelText$ Search��6&   �� 5D   
    �@�FocusVisualStyle 6-   Z� �� 5E   
    � ��$ Center=�65   �� 5F   
    �@  LabelTextColor8  6+   �� 5H   
    � �� 5I      �� 5J      "   6"   .R�5K      �� $	 Border��6   $
 2q�6-   #��z��69   #��z��6c   #��z��6�   ._�5L      � $ 
LayoutGrid��6    5M      �� 5N   "   $��* �63   �� 5O   "   ��63   ��  �� *TemplatedParent+$ ActualHeight�.+�5R      �� $ PART_ContentHost��6+   $��0��6E   �� 5T      $ 	LabelText��6$   $��0��67   $��Center=�5W   $   $��2,0,0,0q�5X   $   $��Italic$�66   ��5U   $   ��  �� *TemplatedParent+$ LabelTextColor���5V   $   ��  �� *TemplatedParent+$ 	LabelText�5X   6   �� 5Z      $	 PART_SearchIconBorder��6%   $��1��6D   $��1q�6T   $
 1q�5[   %   $��Stretch=�5\   %   $��Stretch=�5]   %   8�� 8�� ._�5`   "   �� $ 
SearchIcon��6(   $��Uniform=�6<   $��10��6O   $��15��6Z   $��Center=�6f   $	 0.5Q�6�   $��Center=�6�   $:��4/TMTech.Shared.WPFLIB;component/Images/Search_16.png��6�   5a      5b      5c       5e      P� 5f       �@  HasText . . �5g      �� $ 	LabelText��6;    � y�$ Hidden=�6R   5h      ]� 5j       5k      �� 5l   "    �@  HasText . 6?   �� 5m   "    �@  
SearchMode$ Instant=�6B   ./�5o      �� $ 
SearchIcon��67    � ��$9 3/TMTech.Shared.WPFLIB;component/Images/Close_16.png��6O   5p      ]� 5r       5s      �� 5t   "   $ PART_SearchIconBorder��6C    �@J�IsMouseOver . 6f   �� 5u   "    �@  HasText . 6?   ./�5w      �� $ PART_SearchIconBorder��6<   8   � ��6_   �� 5x      $ PART_SearchIconBorder��6;   8   � ��6^   5y      ]� 5{       5|      �� 5}   "   $ PART_SearchIconBorder��6C    �@J�IsMouseOver . 6f   �� 5~   "    �@  HasText . 6?   ./�5�      �� $ PART_SearchIconBorder��6<   8   � ��6_   �� 5�      $ PART_SearchIconBorder��6;   8 	  � ��6^   5�      ]� 5�       5�      �� 5�   "   $ PART_SearchIconBorder��6C    �@J�IsMouseOver . 6f   �� 5�   "    �@  IsMouseLeftButtonDown . 6M   �� 5�   "    �@  HasText . 6?   ./�5�      �� $ PART_SearchIconBorder��68    �@��Padding$ 2,0,0,0q�6[   �� 5�      $ PART_SearchIconBorder��6<   8 
  � ��6_   �� 5�      $ PART_SearchIconBorder��6;   8   � ��6^   5�      5�      5�      5�      5�      