   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AgencyAgency  5          Agency.SupplyPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Agency     5      -   5          N� Title$  
SupplyPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��25 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ supplyDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�6y      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��5   N   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6Z     5      -   5        PriceColumn��$	 Цена��5   T   $

 Auto 6b    6:   �� *Price+6b     5      -   5        AqentIdColumn��$	 Id Агента��5   X   $

 Auto 6k    6<   �� *	AgentId+6k     5      -   5        ClientIdColumn��$	 Id Клиента��5   Z   $

 Auto 6n    6=   �� *
ClientId+6n     5      -   5        
nameColumn��$	 Имя��5   R   $

 Auto 6_    69   �� *name+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 Auto 6)      CellTemplate 5      �� 5      .R�5      ��  ��Name$ BtnEdit��6=   -   5        $ ��Редактировать��5   %   6N   5      5         5!      $

 Auto 6)    5"      �� 5#      .R�5$      �� $ BtnDel��67   -	   5        $��Удалить��5$   %   6G   5%      5'      5)      � 5*   
    K� ZIndex$ -2��6   
�������$��2��63   $��2��6@   �� 5+   
   -
   5        $ BtnAdd��5+   $   $��Добавить��6   $��2��64   $��0��6A   $
��Left=�6Q   $	��125��6l   6x   5,      5-      