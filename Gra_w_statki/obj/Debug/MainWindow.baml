   M S B A M L   `   `   `  ����G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  5   	       Gra_w_statki.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Gra_w_statki     5   	   -   5          � Title$  Gra w statki��5   	   $	��700��6   $
��1100��6+   $	��600��5	   	   $	��600��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ��  �� Padding$ 20q�6   ��5   
   �� 5       �� ImageSource$) #/ImageResources/ship_background.jpg��6    �� Opacity$	 0.6Q�6K   ._�5   
   �  � RowDefinitions 5      �� 5      $��2* �6    �� 5      $	��10* �6     � ColumnDefinitions 5      �� 5      $	��10* �6#   �� 5      $��3* �6#   .+�5!      �� $
��Left=�6   .+�5"      �� -   5         ��Name$ X��5"      $��40��6%   
�������$��2��6C   $��10q�6L   $��14(�6X   �� 5$      -   5        $ Y��5$      $��40��6%   
�������$��2��6C   $��2q�6L   $��14(�6W   �� 5&      -   5        $��20��5&   .   $��2q�6:   $��SPrawdz��6E   �� 5(      -   5         ��Name$	 cos��5(      
������6)   5+      �� 5.      $��2��6   ._�5/      ]� .+�54      �� -   5        $ Title��54       $��Gra w statki��6/   $��Center=�6C   $��36(�6`   $��Center=�6n   55      57      � 5:      $��10q�6   $��1��6   $��1��6/    5<      �� 5=      $
��auto �6$   �� 5>      $��* �6$   �� 5?      $
��auto �6$   �� 5@      $
��auto �6$   .+�5E      �  5F      �� 5G      $��* �6+   �� 5H      $��* �6+   .+�5J      �� $��1 1 1 0q�6   $��Rozmowa��6.   $��0��6@   $��40��6P   �� 5K      $��1 1 1 0q�6   $��Przebieg��6.   $��1��6A   $��40��6Q   5L      �� 5N      -   5        $ tb_Czat��5N      $��0 0 0 10q�6+   	 �� TextWrapping$
	 Wrap=�6=   $��1q�6Q   $��14(�6]   $��1��6k   $
��auto��6x   $��Andrzej: Witaj stefanie!��6�   
 J� Opacity$

 0.75Q�6�   �� 5P      $��3��6   $��20(�6)   $��Wiadomość:��67   �� 5Q      -   5        $ 	tb_ToSend��5Q      $��Witaj Andrzeju!��6-   $��3��6E   $��16(�6R   $
��auto��6a   6o   5R       � 5T      -	   5          �Name$ WindowFrame��5T      $

 0.85Q�6)   $��0��68   $��1��6H     � NavigationUIVisibility$ Hidden=�6U   $��0 10 5 0q�6u   5V      5W      5Y      