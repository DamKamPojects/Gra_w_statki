   M S B A M L   `   `   `  ����G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  5      %    Gra_w_statki.SerwerOrClientPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Gra_w_statki     5        N� Title$  SerwerOrClientPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   .+�5   
   �� $N��HWybierz czy chcesz stworzyć nową grę czy dołączyć do istniejącej:��6   $��Center=�6]   $��Center=�6z   $��48(�6�   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   $��20q�6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ SerwerButton��5      $��1��6D   $��40 20 20 40q�6Q   $��Stwórz nową grę��6g   $��36(�6�   
�������$
��Bold"�6�   �� 5      -   5        $ ClientButton��5   %   $��1��6   $��1��6T   $��20 20 40 40q�6a   $��Dołącz do gry��6v   $��36(�6�   
�������$
��Bold"�6�   5       5#      5$      