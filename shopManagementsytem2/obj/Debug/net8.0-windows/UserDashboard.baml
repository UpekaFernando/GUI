   M S B A M L   `   `   `  ����O  KshopManagementsytem2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:shopManagementsytem2shopManagementsytem2  5   	   (    "shopManagementsytem2.UserDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:shopManagementsytem2     5   	     � Title$  UserDashboard��5   	   $	��450��6   $	��800��6,   .��5	      � ��5
   
   �� 5       �� ImageSource$N HC:\Users\User\OneDrive\Desktop\CLONED\GUI\shopManagementsytem2\login.jpg��6    j� Stretch$ UniformToFill=�6p   .+�5   
   ��  J� Opacity$	 0.9Q�6   .@�5      �� $
��Home��6   .��5      � $	 0.9Q�6   .+�5      �� $<��6Welcome, [User Name]! Explore shops around the campus.��6    $��18(�6^   $
��Bold"�6l   $��20q�6~   �� 5      -   5        $��
20,50,20,0q�5      $	��Top=�62   $��30��6J   $��5q�6V   
�������$%��Search for a shop or product...��5   0   5   :   �� 5       �� Orientation$ Vertical=�6!   $��20,100,20,0q�68   .+�5      �� $��Nearby Shops��6$   $��16(�68   $
��Bold"�6F   �� 5      -   5         ��Name$ listBoxNearbyShops��5   "   $	��150��6>   $��0,10,0,0q�6K   5      5       5!      5"      �� 5%      $��Nearby Shops��6   .��5&      �� $
��Auto=�6   .��5'      �� $ Vertical=�6!   $��10q�68   $	 0.9Q�6D   .+�5(      �� $��Nearby Shops��6$   $��16(�68   $
��Bold"�6F   $��0,0,0,10q�6X   �� 5)      -   5        $ listBoxAllShops��5)   "   5+      5,      5-      5.      �� 51      $��Offers/Discounts��6   .��52      � $	 0.9Q�6   .+�53      �� $��Special Offers��6    $��16(�66   $
��Bold"�6D   $��10q�6V   �� 54      $��10,40,10,10q�6   .@�55      �� $��20% off at The Food Hub��6&   �� 56      $)��#Buy 1 Get 1 Free at Campus Supplies��6&   �� 57      $(��"10% off on groceries at Fresh Mart��6&   58      59      5:      �� 5=      $��	Favorites��6   .��5>      � $	 0.9Q�6   .+�5?      �� $��Your Favorite Shops��6    $��16(�6;   $
��Bold"�6I   $��10q�6[   5A      5B      �� 5E      $��Profile��6   .��5F      � $��2,0,-2,0q�6   $	 0.9Q�6)    � ColumnDefinitions 5G      �� 5H      $
��140* �6+   �� 5I      $��7* �6+   �� 5J      $
��250* �6+   .+�5M      �� $B��<D:\GUI\GUI\desktop application\shopmanegement\profilepic.png��6   $	��100��6b   $	��100��6n   $
��Left=�6{   $	��Top=�6�   $��	53,20,0,0q�6�   $
}�True��5N      $��Uniform=�60   $��2��6B   �� 5Q       �� TextAlignment$ Center=�6    $
��User��67   $��18(�6C   $
��Bold"�6Q   $
��Left=�6c   $��
84,140,0,0q�6~   $��2��6�   �� 5T      $��Balance: Rs 1500��6    $��16(�68   $
��Left=�6F   $��
59,180,0,0q�6a   $��2��6u   �� 5W      -   5        $��Top Up Balance��5W      $	��150��66   $��40��6B   $
��Left=�6N   $	��Top=�6i   $��
28,220,0,0q�6�   ���#0078D7
�������$��2��5X   _   �� 5Y      -   5        $��Logout��5Y      $	��100��6.   $��30��6:   $��Right=�6F   $	��Top=�6b   $��
0,352,22,0q�6z    J� RenderTransformOrigin$ 2.393,10.187&�5Z   $   $��2��6I   �� 5]      $ 
Horizontal=�6!   $��Right=�6:   $	��Top=�6V   $��	0,10,10,0q�6n   $��2��6�   5_      5`      �� 5c      $��Order History��6   .��5d      � $	 0.9Q�6    5e      �� 5f      $
��257* �6+   �� 5g      $
��140* �6+   .+�5i      �� $��Order History��6    $��16(�65   $
��Bold"�6C   $��10,10,10,10q�6U   $��2��6j   �� 5j      -   5        $ listBoxOrderHistory��5j      $��10,40,10,10q�6;   $��2��6�   5l      �� 5m      -   5        $��Clear Order History��5m      $	��150��6;   $��40��6G   $��Right=�6S   $��Bottom=�6o   $��	0,0,10,10q�6�   $��1��5n   =   5o      5p      5q      5r      5s      