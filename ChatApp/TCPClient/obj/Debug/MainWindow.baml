   M S B A M L   `   `   `  ����D  @TCPClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TCPTCP  5   	       TCP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:TCP     5   	     � Title$  TCP/IP Client��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   �� $��Server:��6   $
��Left=�6"   $��	79,61,0,0q�6=   $	��Top=�6P   $��2��6h   �� 5   
   -   5        $��txtIP��5      $
��Left=�6    $��
139,65,0,0q�6;    �� TextWrapping$
 Wrap=�6O   $��192.168.178.46:7891��6c   $	��Top=�6~   $	��508��6�   $��2��6�   �� 5   
   -   5        $��
btnConnect��5      $��Connect��6#   $
��Left=�65   $��587,332,0,0q�6P   $	��Top=�6e   $��60��6}   $��2��6�   6�   �� 5   
   -   5        $��txtInfo��5      $
��Left=�6!   $��
139,99,0,0q�6<   $
 Wrap=�6P   $��TextBox��6e   " �� VerticalScrollBarVisibility$ Visible=�6t    �� 
IsReadOnly . $	��Top=�6�   $	��508��6�   $	��168��6�   $��2��6�   �� 5   
   -   5        $��btnSend��5      $
��Send��6    $
��Left=�6/   $��508,332,0,0q�6J   $	��Top=�6_   $��60��6w   $��2��6�   6�   �� 5   
   $��Message:��6   $
��Left=�6#   $��
79,281,0,0q�6>   $	��Top=�6R   $��2��6j   �� 5   
   -   5        $��
txtMessage��5      $
��Left=�6$   $��139,285,0,0q�6?   $
 Wrap=�6T   $��TextBox��6h   $	��Top=�6w   $	��508��6�   $��2��6�   5      5      