   M S B A M L   `   `   `  ����H  DMagazineOfSCP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MagazineOfSCPMagazineOfSCP  5   	       MagazineOfSCP.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MagazineOfSCP     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          � Title$  
MainWindow��5   	   $	��700��6   $	��650��6,    � Icon$ /Unknow.jpg��6;    � WindowStartupLocation$ CenterScreen=�6k   $	��696��5	   	   $
��1110��6    � 	Resources 5         SolidColorBrushColor1��%+   &	        ��5   
   	#FF986666��69   5      .��5      � ���	#FFC7B7B7 � ShowGridLines$ False��6"   .+�5   
   �� $0��*C:\Users\IDK\Pictures\SCP\backmagazine.jpg��6   $
��Fill=�6D    J� OpacityMask �	#FF883333$��3��6k   $��3��6   �� 5   
   -   5         ��Name$ exit_btn��5      $��Button��6#   ���	#FF986666 �� IsCancel$
 True��6c   $��2��6u   $��0��6�   $��	0,27,0,27q�6�   �� 5   
   -   5         ��Name$ viewscp��5      $��1��6%   $��1��65   $��3��6J   $��Stretch=�6[   $��Stretch=�6~   $��0,86,0,0q�6�   ��5      �� 5      .R�5      � 	 � Orientation$	 Vertical=�6!   $��Stretch=�68   $��Stretch=�6V   
 � UseLayoutRounding$
 False��6r   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�6�   $
��True��6�   5      5      �� 5   
   -   5        $ add_btn��5      $��2��6"   $��Добавить��62   $��2��6F   $��	0,34,0,34q�6i   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFBAC17C��6#    � Offset$ 1Q�65   5      5      � 5    
   $��2��6   $��1��6    .+�5!      �� -   5        $ 
basket_btn��5!      $��Корзина��6)   $��0��6;   ��5"      �� 5#      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5$      � $ 	#FF090B0C��6'   � 5%      $ 	#FF93967C��6'   $ 1Q�69   � 5&      $ 	#FF0C0F0F��6'   $ 0.943Q�69   � 5'      $ 	#FFADAD2D��6'   $ 0.687Q�69   � 5(      $ 	#FF959594��6'   $ 0.413Q�69   � 5)      $ 	#FFA9A9A8��6'   $ 0.148Q�69   5*      5,      �� 5-      -   5         ��Name$ price_tb��5-      $��1��6*   $
��Wrap=�68   ���	#FF29BF24
������ $
��Bold"�6|   $��Arial Black)�6�   $��16(�6�   �� 5.      -   5         ��Name$ name_tb��5.       �� TextWrapping$
 Wrap=�6'   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя_Объекта��6;    % !MaterialDesignFloatingHintTextBox#��[ 6h   $��/couriernew.ttf)�6�   $��2��6�   ���	#FFE81E1E �� TextDecorations$ 	Underline{�6�   $
��Bold"�6   ���	#FFD4D3C564   � RowDefinitions 50      �� 51      $
��auto �6    �� 52      $
��auto �6    �� 53      $
��auto �6    55      � 56   
   $��1��6   $��0��6   $��Right=�6,   .+�57      �� -   5        $ default_btn��57      $��Default��6*   $��0��6<   ��58      �� 59      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5:      � $ Black��6'   $ 0.678Q�65   � 5;      $ 	#FF503131��6'   $ 1Q�69   � 5<      $ 	#FFB34646��6'   $ 0.113Q�69   � 5=      $ 	#FF616769��6'   $ 0.443Q�69   5>      5@      �� 5A      -	   5         ��Name$ class_cb��5A      $��1��6)   $
��Left=�69   $��20q�6T   $��Center=�6a   $	��120��6|   ���	#FF8494C5$
��Bold"�6�   .@�5B      �� $��Безопасный��6   �� 5C      $��Евклид��6   �� 5D      $��
Кетер��6   �� 5E      $��Таумиэль��6   �� 5F      5G      	� 5H      -
   5         	�Name$ down_rb��5H      $��2��6+   $��По убыванию��6;   $��Right=�6Q   $��20q�6m   $��Center=�6z   
�������$
��Bold"�6�   6�   	� 5I      -   5        $ up_rb��5I      $��3��6)   $!��По возрастанию��69   $��Right=�6R   $��20q�6n   $��Center=�6{   
�������$
��Bold"�6�   6�    � ColumnDefinitions 5J      �� 5K      $
��auto �6#   �� 5L      $
��auto �6#   �� 5M      $
��auto �6#   �� 5N      $
��auto �6#   5P       5Q   
   �� 5R      $	��43* �6   �� 5S      $
��249* �6   �� 5T      $	��50* �6    5V   
   �� 5W      $	��67* �6   �� 5X      $
��403* �6   �� 5Y      $	��85* �6   5\      5]      