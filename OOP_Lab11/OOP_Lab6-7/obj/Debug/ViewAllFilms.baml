   M S B A M L   `   `   `  ����E  AOOP_Lab6-7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:OOP_Lab6_7
OOP_Lab6_7  5   	       OOP_Lab6_7.ViewAllFilms   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:OOP_Lab6_7     5   	     � Title$  ViewAllFilms��5   	   $	��528��6   $
��1000��6+   $	��528��5	   	   $	��732��6    � WindowStartupLocation$ CenterScreen=�6(    � Icon$e _C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab6-7\OOP_Lab6-7\Resources\logo_black.png��5
   	   .��5      � -   5        $��mainGrid��5         blackBackground#���   6    � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $
��3.5* �6   6.   .+�5   
   � -   5        $��leftMenu��5      $��1��5      $��0��6     yellowBackground#���  5       5      �� 5      $
��1.2* �6    60   �� 5       $��1* �6    6.   �� 5!      $��1* �6    6.   �� 5"      $��1* �6    6.   �� 5#      $��1* �6    6.   �� 5$      $��1* �6    6.   �� 5%      $
��1.4* �6    60   .+�5:         OOP_Lab6_7.UserControl1  -   5          Name$ 	searchBox��5:   9   $	��140��6!   $��25��6-   $��0��5;   !   $	��Top=�6.   $��0 5 0 0q�6F   5<      �� 5=      -   5        $��searchButton��5=      $	��140��6)   $��30��65   $��Bottom=�5>      $��0��5?   0   $��0 0 0 5q�6=     templateSearch#���  5@       � Cursor$
 Hand��6A   5A      �� 5D      -   5        $��	addButton��5D      $��1��6&   $	��140��63   $��30��5E        templateAdd#���  5F      5G      �� 5J      -   5        $��redactButton��5J      $��2��6)   $	��140��66   $��30��5K        templateRedact#���  5L      5M      �� 5O      -   5        $��addScheduleButton��5O      $��3��6.   $	��140��6;   $��30��5P        templateAddSchedule#���  5Q      5R      �� 5T      -   5        $��deleteButton��5T      $��4��6)   $	��140��66   $��30��5U        templateDel#���  5V      5W      �� 5Y      -	   5        $��
showButton��5Y      $��5��6'   $	��140��64   $��30��5Z        templateAll#���  5[      5\      �� 5`      -
   5        $��comboBoxFilterSelect��5a      $��6��5b      $��0��6   $��Center=�5c      $	��Top=�6.   $��0 10 0 0q�5d      $	��130��5e      $��25��6   .@�5f      ��   	genAction#���  6   6G   �� 5g       	 	genComedy#��� 	 6   6G   �� 5h       
 genDrama#��� 
 6   6F   �� 5i        genMelodrama#���  6   6J   �� 5j        genFantastic#���  6   6J   �� 5k        
genFantasy#���  6   6H   �� 5l        genThriller#���  6   6I   �� 5m        	genHorror#���  6   6G   �� 5n       
 genWar#���  6   6D   �� 5o        genKids#���  6   6E   5p      �� 5t      -   5        $��filterButton��5t      $��7��6)   $	��140��66   $��30��5u      $��Bottom=�5w      $��0 0 0 10q�5x        templateFilter#���  5y      5z      5|      �� 5   
   -   5        $
��back��5      $��40��5�      $��40��6   $
��Left=�5�      $��10q�6,   $��5q�5�       �� IsCancel . ��5�      Z� ��5�      Z� .��5�      �� $��/back-arrow.png��6   6/   5�      �� 5�   
   -   5        $��logoViewAll��5�      $��/logo_png_crop.png��5�      $��0��6,   $��2��5�      $��13q�6$     logoShowOnLoad#���  5�   #   5�      �� 5�   
   -   5        $��	tableView��5�      $��1��6$   $��1��61   #���   5�       �� View 5�      �� 5�      .P�5�      �� 	 �� Width$		 130��6&     filmName#���  62   
 �� CellTemplate
 5�      �� 5�      .R�5�   "   �� $
��Wrap=�5�   ,   $��16(�5�   ,   ���#99aab5$��10,0,0,0q�5�   ,   ��5�   ,   �� *Title+5�   @   5�      5�      �� 5�      $		 125��6&     director#���  62   
 5�      �� 5�      .R�5�   "   �� $
��Wrap=�5�   ,   $��16(�5�   ,   ���#99aab5$��10,0,0,0q�5�   ,   ��5�   ,   �� *
Director+5�   @   5�      5�      �� 5�      $		 170��6&    	 genre#���  62   
 5�      �� 5�      .R�5�   "   �� $
��Wrap=�5�   ,   $��16(�5�   ,   ���#99aab5$��10,0,0,0q�5�   ,   ��5�   ,   �� *Genre+5�   @   5�      5�      �� 5�      $	 90��6&     duration#���  61   
 5�      �� 5�      .R�5�   "   �� $
��Wrap=�5�   ,   $��16(�5�   ,   ���#99aab5$��10,0,0,0q�5�   ,   ��5�   ,   �� *
Duration+5�   @   5�      5�      �� 5�      $	 90��6&    
 rating#���  61   
 5�      �� 5�      .R�5�   "   �� $
��Wrap=�5�   ,   $��16(�5�   ,   ���#99aab5$��10,0,0,0q�5�   ,   ��5�   ,   �� *Rating+5�   @   5�      5�      �� 5�      $		 150��6&    	 photo#���  62   
 5�      �� 5�      .R�5�   "   �� $��50��5�   (   $��50��5�   (   $��30 0 0 0q�5�   (   $��Center=�5�   (   ��5�   (   �� *Photo+5�   G   5�      5�      5�      5�      5�      5�      