   M S B A M L   `   `   `  ����G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  5      '    !Gra_w_statki.SerwerConnectionPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Gra_w_statki     5        N� Title$  SerwerConnectionPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   �� $��Stwórz nową grę!��6   $��Center=�6,   $��Center=�6I   $��48(�6d   �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5      �� $��Podaj nazwę gracza:��6   $��24(�63   $
��Bold"�6A   $��Center=�6S   �� 5      -   5         ��Name$ tb_PlayerName��5       �� TextAlignment$ Center=�6.   $��30(�6E   $��	0 10 0 10q�6S   $��48��6f   $��2q�6r   $	��280��6~    �� 	MaxLength$ 12��6�   6�   5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5       �� -   5         ��Name$ ConnectButton��5    2   $��2��6   $��1��6"   $��30q�6e   $��Połącz��6q   $��32(�6�   $
��Bold"�6�   
�������6�   �� 5"      -   5        $ 
BackButton��5"   2   $��2��6   $��0��6"   $��30q�6_   $��Wstecz��6k   $��32(�6|   $
��Bold"�6�   
�������6�   5#      5%      5&      