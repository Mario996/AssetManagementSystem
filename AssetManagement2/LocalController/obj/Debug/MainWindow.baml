   M S B A M L   `   `   `  ����J  FLocalController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LocalControllerLocalController  5   	        LocalController.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LocalController     5   	     � Title$  
MainWindow��5   	   $��470.692��6   $��810.324��6-   .��5	      � .+�5
   
   �� $��Stretch=�6   .@�5      �� $��
Controller��6   $	��390��6*   ��5      �� 5       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��5      �  � Color$ 	#FFF0F0F0��6'    � Offset$ 0Q�69   � 5      $ 	#FF7CC7C7��6'   $ 1Q�69   5      .��5      � ��5      �� 5       �� ImageSource$ 	slika.jpg��6%   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridController��5         
IsReadOnly .    SelectionMode$ Single=�6{   
�������	 J� Opacity$		 0.7Q�6�   ���	#FF1E3A51
   AutoGenerateColumns
 .  $
��Left=�6�   $	��263��6  $��	10,85,0,0q�6  $	��Top=�6"  $	��773��6:  ��6;   �� *LocalControllerList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *LocalControllerCode+6h     5      $ Perid��61   $ * 6k    6A   �� *LocalControllerPeriod+6k     5      $
 Type��61   $ * 6h    6?   �� *LocalControllerState+6h   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 100 65      CellTemplate 5   "   �� 5   &   .R�5   *   �� .+�5   .   �� $��Delete��65   -   5        $��Delete��5   b   $��33��6t   6�   �� 5    .   $��TurnON��65   -   5        $��Turn ON��5    b   $��33��6t   6�   �� 5!   .   $��TurnOFF��65   -   5        $��Turn OFF��5!   d   $��33��6w   6�   5"   +   5#   '   5%      5'      �� 5(      -   5        $��Add new controller��5(      $
��Left=�6Y   $��41��6t   $��599,361,0,0q�6�   $	��Top=�6�   $	��184��6�   $��Verdana)�6�   $��14(�6�   ���	#FFFDF9F9���	#FF343131��5)      �� 5*      $ 	dugme.jpg��6)    j� Stretch$ UniformToFill=�6A   5,      �� 5-      $		 0.7Q�6   
�������$��Controllers��6=   $
��Left=�6S   $��38��6n   $��
324,26,0,0q�6z   $	��Top=�6�   $	��118��6�   $��22(�6�   $��Sitka Heading)�6�   $��Italic$�6�   5.      5/      �� 50      $��Device��6   $	��400��6&   ��51      �� 52      $	 0,1&�6*   $	 0,0&�69   .��53      � $ 	#FFF0F0F0��6'   $ 0Q�69   � 54      $ 	#FF7CC7C7��6'   $ 1Q�69   55      .��57      � ��58      �� 59      $ 	slika.jpg��6%   .+�5;      �� $		 0.7Q�6   
�������$��
   Devices��6=   $
��Left=�6R   $��38��6m   $��
334,28,0,0q�6y   $	��Top=�6�   $	��118��6�   $��22(�6�   $��Sitka Heading)�6�   $��Italic$�6�     5<      -   5        $ dataGridDevice��5<       . $ Single=�6s   
�������$		 0.7Q�6�   ���	#FF1E3A51
 .  $
��Left=�6�   $	��263��6�   $��	10,83,0,0q�6  $	��Top=�6  $	��773��62  ��67   �� *LocalDeviceList+ 5=        5>      $
 Code��61   $ * 6d    6@   �� *LocalDeviceCode+6d     5?      $ Controller code��61   $ * 6y    6K   �� *LocalDeviceControllerCode+6y     5@      $
 Type��61   $ * 6c    6?   �� *LocalDeviceType+6c     5A      $ Value��61   $ * 6e    6@   �� *LocalDeviceValue+6e     5B      $ Sending Period��61   $ * 6o    6I   �� *LocalDevicePeriod+6o     5C      $ Limit��61   $ * 6e    6@   �� *LocalDeviceLimit+6e     5D      $ State��61   $ * 6e    6@   �� *LocalDeviceState+6e     5E      $	 100 65    5F   "   �� 5G   &   .R�5H   *   �� .+�5I   .   �� $��Delete��65   -   5        $��Delete��5I   ^   $��33��6p   �� 5J   .   $��TurnON��65   -   5        $��Turn ON��5J   X   $��33��6j   6x   �� 5K   .   $��TurnOFF��65   -	   5        $��Turn OFF��5K   Z   $��33��6m   6{   5L   +   5M   '   5O      5Q      �� 5R      -
   5        $��Add new device��5R      ���	#FFFDF9F9���	#FF343131$��Verdana)�6�   $��14(�6�   $
��Left=�6�   $��41��6�   $��596,361,0,0q�6�   $	��Top=�6�   $	��187��6�   ��5S      �� 5T      $ 	dugme.jpg��6)   $ UniformToFill=�6A   5V      5W      5X      5Y      5Z      5[      