   M S B A M L   `   `   `  ����G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  5      !    Gra_w_statki.GameWindowPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Gra_w_statki     5        N� Title$  GameWindowPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��Bitwa!��6   $��Center=�6"   $��36(�6?   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��4* �6#   .+�5       � -   5          �Name$ 
BoardFrame��5      $��1��6)   $��1��69     � NavigationUIVisibility$ Hidden=�6F   $��	5 5 10 10q�6f   �� 5      $��1��6   $��1��6%   $��3��65   $��5q�6F   
���   �6Q   �� 5      $��1��6   $��0��6%   $��3��65   $��5q�6F   
���   �6Q   � 5!       5"      �� 5#      $
��auto �6$   �� 5$      $��7* �6$   �� 5%      $��2* �6$   .+�5)      �� $��5q�6   $��24(�6'   $��0��65   $��Gracz��6B   $��Center=�6O    � 5+      -   5        $ OurBoardFrame��5+      $��1��60   $��1��6@   $ Hidden=�6M   $��
10 5 10 10q�6m   � 5-      $��3��6    5.      �� 5/      $
��auto �6(   �� 50      $��* �6(   .+�53      �� $��2q�6    $��16(�6+   $��0��69   $&�� Pozostałe niezatopione okręty:��6F   $��Center=�6l   �� 54      -   5         ��Name$ OurShipsStackPanel��54   !   $��1��6=   $��Center=�6J   $��Center=�6g    �� Orientation$ 
Horizontal=�6�   55      56      � 58      $��1��6    59      �� 5:      $
��auto �6$   �� 5;      $��7* �6$   �� 5<      $��2* �6$   .+�5@      �� $��5q�6   $��24(�6'   $��0��65   $��
Przeciwnik��6B   $��Center=�6T    � 5B      -   5        $ EnemyBoardFrame��5B      $��1��62   $��1��6B   $ Hidden=�6O   $��
10 5 10 10q�6o   � 5D      $��3��6    5E      �� 5F      $
��auto �6(   �� 5G      $��* �6(   .+�5J      �� $��2q�6    $��16(�6+   $��0��69   $&�� Pozostałe niezatopione okręty:��6F   $��Center=�6l   �� 5K      -   5        $ EnemyShipsStackPanel��5K   !   $��1��6?   $��Center=�6L   $��Center=�6i   $ 
Horizontal=�6�   5L      5M      5N      �� 5P   
   $��Poddaj się��6   $��2��6&   $��5q�63   $	��200��6>   $��20��6J   5Q      5R      