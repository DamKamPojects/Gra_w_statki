   M S B A M L   `   `   `  ���� G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki      Gra_w_statki.LobbyPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Gra_w_statki       N� Title$  	LobbyPage��.��� 
������� � RowDefinitions �� $
��auto ��� $��* �.+��� $��Poczekalnia��$��Center=�$��36(�� $��1�� � ColumnDefinitions �� $��4* ��� $��4* �.+��� $��1��$��1��$��3��$��5q�
���   �� $��1��$��1�� �� $
��auto ��� $��* �.+� � -     �Name$ LobbyBoardFrame��$��1��$��1��  � NavigationUIVisibility$ Hidden=�$��	5 5 10 10q��� $��5q�$��24(�$��0��$��  Twoja plansza:��$��Center=��  �� $
��auto ��� $��2* ��� $��1* ��� $
��auto ��� $��2* ��� $��2* �.+��� $��0��$��0��$��2��$��5q�
���   ��� $��3��$��0��$��2��$��5 5 5 0q�
���   ��� $��5q�$��24(�$��0��$��Informacje o grze��$��Center=�� $��1�� �� $��* ��� $��* �.+��� $��Center=�$��Center=�.+��� $��5q�$��18(�$��0��$��Rozmiar planszy:��$��Center=��� -    ��Name$ tb_boardSize��$��5q�$��24(�$��0��$��10x10��$��Center=�$
��Bold"��� $��1��$��Center=�$��Center=�.+��� $��5q�$��18(�$��0��$��Ilość statków:��$��Center=��� -   $ tb_shipsAmount��$��5q�$��24(�$��0��$��Średnia��$��Center=�$
��Bold"��� -    ��Name$ 	ChangeMap��$��	30 6 30 6q�$#��Zmień rozstawienie okrętów��$��24(�$��2��
��������� $��5q�$��24(�$��3��$��Informacje o graczach��$��Center=�� $��4�� �� $��* ��� $��* � �� $
��0.8* ��� $��2* ��� $��2* ��� $��* �.+��� $��5q�$��24(�$��0��$��1.��$��Center=�$��Center=�$
��Bold"��� -   $ Player1Name��$��0��$��1��$��5q�$��22(�$��Andrzej��$��Center=�$
��Bold"�$��Center=��� -   $ Player1Status��$��0��$��2��$��5q�$��22(�$��Gotowy��$��Center=�$
��Bold"�$��Center=�A� -    A�Name$ Player1StausCircle��$��0��$��3��$��5q�$��40��$��40��
��� d ��� $��5q�$��24(�$��1��$��2.��$��Center=�$��Center=�$
��Bold"��� -   $ Player2Name��$��1��$��1��$��5q�$��22(�$��Stefan��$��Center=�$
��Bold"�$��Center=��� -	   $ Player2Status��$��1��$��2��$��5q�$��22(�$��	Niegotowy��$��Center=�$
��Bold"�$��Center=�A� -
   $ Player2StausCircle��$��1��$��5q�$��3��$��40��$��40��
���  ���� -   $ 
PlayButton��$��10q�$��Graj!��$��32(�$��5��
�������