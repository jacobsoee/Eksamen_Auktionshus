   M S B A M L   `   `   `  ����J  FAuktionshus_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Auktionshus_WPFAuktionshus_WPF  5   	   #    Auktionshus_WPF.AuctionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Auktionshus_WPF     5   	     � Title$  Ædelmetal Auktion��5   	   $	��450��6#   $	��600��60   .��5	      � .+�5
   
   �� -   5        $��SalesOfferLW��5
      $
��Left=�6'   $	��370��6B   $��	20,20,0,0q�6O   $	��Top=�6b   $	��299��6z    �� View 5      �� 5      .P�5      �� $
��Type��6%    �� Width$ 80��63    �� DisplayMemberBinding 6>   �� *	MetalType+�� 5      $��Mængde��6%   $ 60��65    6@   �� *Amount+�� 5      $��Deadline��6%   $	 155��67    6C   �� *
Deadline+ �� StringFormat$ dd/MM/yyyy HH:mm��5      5      �� 5   
   -   5        $��
PriceInput��5      $
��Left=�6$   $��23��6?   $��
370,60,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��94��6�    J� RenderTransformOrigin$ 0.799,0.722&�6�   �� 5   
   -   5         ��Name$ OfferButton��5      $	��Byd��6&   $
��Left=�64   $��
481,60,0,0q�6O   $	��Top=�6c   $��78��6{   $��23��6�   �� 5   
   -   5        $��PurchaseOfferLW��5      $
��Left=�6*   $	��273��6E   $��355,117,0,0q�6R   $	��Top=�6g   $	��219��6    5      �� 5      .P�5      �� $	��Bud��6%   $ 50��62   -   5        xD�� 5   =   �� *Amount+6e   �� 5      $��Køber��6%   $	 165��64    6@   �� *	Account+5      .@�5      �� $	��100��6   $	��100��6$    5      �� 5      .P�5      �� 5       5"      5#      �� 5$   
   -   5        $��	TimeLabel��5$      $�� ��6!   $
��Left=�6,   $��
381,88,0,0q�6G   $	��Top=�6[   �� 5%   
   $
��Tid:��6   $
��Left=�6   $��
352,88,0,0q�6:   $	��Top=�6N   5&      5'      