   M S B A M L   `   `   `  ����G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  5           Gra_w_statki.CreateMapPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Gra_w_statki     5        N� Title$  CreateMapPage��5	      .��5      � -   5         �Name$ MainGrid��5      
������� � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��4* �6   .+�5   
    � -   5          �Name$
 dupa��5      $	��200��6   $��40��6*   �� 5   
   $��1��6   $��1��6!   $��3��61   $��5q�6B   
���   �6M    � 5"   
   -   5        $ 
BoardFrame��5"      $��1��6%   $��1��65     � NavigationUIVisibility$ Hidden=�6B   $��	5 5 10 10q�6b   � 5&   
   $��5q�6   $��0��6   $��1��6*    5'      �� 5(      $
��auto �6    �� 5)      $
��auto �6    �� 5*      $��3* �6    �� 5+      $
��1.5* �6    .+�5.      �� $��0��6   $��Statki do rozstawienia:��6%    �� TextAlignment$ Center=�6D   $��24(�6[   $
��Wrap=�6i   �� 50      $��0��6   $��3��6%   $��0q�66   
���   �6A   � 54      $��1��6    55      �� 56      $��* �6'   �� 57      $��* �6'   �� 58      $��* �6'   �� 59      $��* �6'   .+�5<      �� $��2q�6   $��Rodzaj statku:��6'   $��Center=�6=   $��Center=�6Z   $��14(�6u   $
��Wrap=�6�   $ Center=�6�   �� 5>      $��2q�6   $��1��6'   $��Ilość:��67   $��Center=�6E   $��Center=�6b   $��14(�6}   $
��Wrap=�6�   $ Center=�6�   �� 5@      $��2q�6   $��2��6'   $��Roztawiono:��67   $��Center=�6J   $��Center=�6g   $��14(�6�   $
��Wrap=�6�   $ Center=�6�   �� 5B      $��2q�6   $��3��6'   $��Pozostało:��67   $��Center=�6I   $��Center=�6f   $��14(�6�   $
��Wrap=�6�   $ Center=�6�   5C      � 5E      -   5        $ ShipAmountInfoGrid��5E   S    � ShowGridLines . $��2��6(   ���#ccc$��3q�6G    5F      �� 5G      $��* �6'   �� 5H      $��* �6'   �� 5I      $��* �6'   �� 5J      $��* �6'    5M      �� 5N      $��* �6$   5P      � 5R      $��4��6    5W      �� 5X      $��* �6$   �� 5Y      $��2* �6$   .+�5[      �� -   5         ��Name$ ResetButton��5[      $��0��6H   $��	20 8 20 8q�6U   
�������$!��Resetuj ustawienie statków��6   �� 5\      -   5        $ ConfirmButton��5\      $��1��6M   $��8q�6Z   
�������$&�� Zatwierdź rozstawienie statków��6|   5_      5e      5f      5g      