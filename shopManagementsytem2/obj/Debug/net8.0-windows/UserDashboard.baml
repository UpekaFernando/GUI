   M S B A M L   `   `   `  ����O  KshopManagementsytem2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:shopManagementsytem2shopManagementsytem2  5   	   (    "shopManagementsytem2.UserDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:shopManagementsytem2     5   	     � Title$  UserDashboard��5      $	��450��6&   $	��800��63   .��5	      � .+�5   
   �� .@�5      �� $
��Home��6   .��5      � .+�5      �� $<��6Welcome, [User Name]! Explore shops around the campus.��6    $��18(�6^   $
��Bold"�6l   $��20q�6~   �� 5      -   5        $��
20,50,20,0q�5      $	��Top=�62   $��30��6J   $��5q�6V   
�������$%��Search for a shop or product...��5   0   5   :   �� 5       �� Orientation$ Vertical=�6!   $��20,100,20,0q�68   .+�5      �� $��Nearby Shops��6$   $��16(�68   $
��Bold"�6F   �� 5      -   5         ��Name$ listBoxNearbyShops��5   "   $	��150��6>   $��0,10,0,0q�6K   5      5      5      5      �� 5"      $��Nearby Shops��6   .��5#      �� $
��Auto=�6   .��5$      �� $ Vertical=�6!   $��10q�68   .+�5%      �� $��Nearby Shops��6$   $��16(�68   $
��Bold"�6F   $��0,0,0,10q�6X   �� 5&      -   5        $ listBoxAllShops��5&   "   5(      5)      5*      5+      �� 5.      $��Offers/Discounts��6   .��5/      � .+�50      �� $��Special Offers��6    $��16(�66   $
��Bold"�6D   $��10q�6V   �� 51      $��10,40,10,10q�6   .@�52      �� $��20% off at The Food Hub��6&   �� 53      $)��#Buy 1 Get 1 Free at Campus Supplies��6&   �� 54      $(��"10% off on groceries at Fresh Mart��6&   55      56      57      �� 5:      $��	Favorites��6   .��5;      � .+�5<      �� $��Your Favorite Shops��6    $��16(�6;   $
��Bold"�6I   $��10q�6[   5>      5?      �� 5B      $��Profile��6   .��5C      � $��2,0,-2,0q�6    � ColumnDefinitions 5D      �� 5E      $
��140* �6+   �� 5F      $��7* �6+   �� 5G      $
��250* �6+   .+�5J      �� $B��<D:\GUI\GUI\desktop application\shopmanegement\profilepic.png��6   $	��100��6b   $	��100��6n   $
��Left=�6{   $	��Top=�6�   $��	53,20,0,0q�6�   $
}�True��5K      $��Uniform=�60   $��2��6B   �� 5N       �� TextAlignment$ Center=�6    $
��User��67   $��18(�6C   $
��Bold"�6Q   $
��Left=�6c   $��
84,140,0,0q�6~   $��2��6�   �� 5Q      $��Balance: $50��6    $��16(�64   $
��Left=�6B   $��
59,180,0,0q�6]   $��2��6q   �� 5T      -   5        $��Top Up Balance��5T      $	��150��66   $��40��6B   $
��Left=�6N   $	��Top=�6i   $��
28,220,0,0q�6�   ���#0078D7
�������$��2��5U   _   �� 5X      $ 
Horizontal=�6!   $��Right=�6:   $	��Top=�6V   $��	0,10,10,0q�6n   $��2��6�   5Z      5[      �� 5^      $��Order History��6   .��5_      � .+�5`      �� $��Order History��6    $��16(�65   $
��Bold"�6C   $��10q�6U   �� 5a      -   5        $ listBoxOrderHistory��5a      $��10,40,10,10q�6;   5c      �� 5d      -   5        $��Clear Order History��5d      $	��150��6;   $��40��6G   $��Right=�6S   $��Bottom=�6o   $��10q�6�   5e      5f      5g      5h      5i      5j      