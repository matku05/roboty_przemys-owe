   M S B A M L   `   `   `  ����  Manipulatory    Manipulatory.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $��755.255��6   $��914.582��6-   .��5      � .+�5   
   �� $
��Left=�6   $	��716��60   $	��Top=�6=   $	��908��6U   .@�5      �� $��
Connection��6   .��5      � -   5         �Name$ lb_nr_portu��5      ���	#FFE5E5E5$��0,-11,-0.4,10.2q�6C   .+�5	      �� -   5         ��Name$ 
bt_connect��5	      $��CONNECT��61   $
��Left=�6C   $��80��6^   $��
58,265,0,0q�6j   $	��Top=�6~   $	��191��6�   6�   �� 5
      -   5        $ bt_disconnect��5
      $��
DISCONNECT��64   $
��Left=�6I   $��80��6d   $��651,265,0,0q�6p   $	��Top=�6�   $	��191��6�   6�   �� 5      -   5         ��Name$ 
cb_nr_port��5      $
��Left=�63   $��
58,133,0,0q�6N   $	��Top=�6b   $	��784��6z   .@�5      �� .��6'   COM16-   �� 5      .��6'   COM26-   �� 5      .��6'   COM36-   �� 5      .��6'   COM46-   �� 5      .��6'   COM56-   �� 5      .��6'   COM66-   �� 5      .��6'   COM76-   �� 5      .��6'   COM86-   �� 5      .��6'   COM96-   �� 5      .��6'   COM106.   5      �� 5      $��SELECT THE PORT NUMBER��6   $
��Left=�6=   $��
349,87,0,0q�6X   $	��Top=�6l   $	��382��6�   �� 5      -   5         ��Name$ 	tb_status��5      $
��Left=�61   $	��134��6L   $��
58,446,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��784��6�   5      5      �� 5      $��Control XYZ��6   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $��7* �6+   �� 5      $	��47* �6+   �� 5       $
��397* �6+   .+�5"      �� -   5        $ 	bt_x_left��5"      $��2��60   $	��- X��6D   $��1��6R   $
��Left=�6b   $��77��6}   $��40.4,48,0,0q�6�   $	��Top=�6�   $	��164��6�   6�   �� 5#      -   5        $ 
bt_x_right��5#      $	��+ X��61   $��2��6?   $
��Left=�6O   $��77��6j   $��
576,48,0,0q�6v   $	��Top=�6�   $	��164��6�   6�   �� 5$      -   5        $ 	bt_y_left��5$      $��2��60   $	��- Y��6D   $��1��6R   $
��Left=�6b   $��77��6}   $��40.4,210,0,0q�6�   $	��Top=�6�   $	��164��6�   6�   �� 5%      -	   5        $ 
bt_y_right��5%      $	��+ Y��61   $��2��6?   $
��Left=�6O   $��77��6j   $��576,210,0,0q�6v   $	��Top=�6�   $	��164��6�   6�   �� 5&      -
   5        $ 	bt_z_left��5&      $��2��60   $	��- Z��6D   $��1��6R   $
��Left=�6b   $��77��6}   $��40.4,367,0,0q�6�   $	��Top=�6�   $	��164��6�   6�   �� 5'      -   5        $ 
bt_z_right��5'      $	��+ Z��61   $��2��6?   $
��Left=�6O   $��77��6j   $��576,367,0,0q�6v   $	��Top=�6�   $	��164��6�   6�   �� 5(      -   5        $ bt_gc��5(      $��2��6,   $	��- C��6@   $��1��6N   $
��Left=�6^   $��77��6y   $��40.4,524,0,0q�6�   $	��Top=�6�   $	��164��6�   6�   �� 5)      -   5        $ bt_go��5)      $	��+ C��6,   $��2��6:   $
��Left=�6J   $��77��6e   $��576,524,0,0q�6q   $	��Top=�6�   $	��164��6�   6�   �� 5*      -   5        $ bt_disconnect2��5*      $��
DISCONNECT��65   $��2��6J   $
��Left=�6Z   $��56��6u   $��248,545,0,0q�6�   $	��Top=�6�   $	��196��6�   6�   5+      5,      �� 5-      $��Android��6   .��5.      � ���	#FFE5E5E5.+�5/      �� -   5        $ tb_connect_android��5/      $
��Left=�6:   $	��108��6U   $��323,191,0,0q�6b   $
 Wrap=�6w   $	��Top=�6�   $	��232��6�   �� 50      -   5        $ 	bt_SERVER��50      $��START SERVER ��60   $
��Left=�6H   $��58��6c   $��304,362,0,0q�6o   $	��Top=�6�   $	��251��6�   6�   �� 51      -   5        $ CB_ip_adress��51      $
��Left=�65   $��42��6P   $��
323,75,0,0q�6\   $	��Top=�6p   $	��202��6�   .@�52      �� .��6'   89.79.51.23665   �� 53      .��6'   192.168.2.102.67   �� 54      .��6'   192.168.2.10166   55      �� 56      -   5        $ bt_server_stop��56      $��server stop��65   $
��Left=�6K   $��51��6f   $��624,191,0,0q�6r   $	��Top=�6�   $	��188��6�   6�   57      58      59      5;      5<      