   M S B A M L   `   `   `  ????B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop  5   	       CarShop.MainWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CarShop     5   	     ? WindowStartupLocation$  CenterScreen=?5	   	    ? Title$ 
MainWindow??5
   	   $	??700??6   $
??1400??6)    ? 	Resources 5         	TextStyle ?? 
TargetType ?? Property ?? Value?? 5   
   %\   &	        ?? 5      " ??5      .?5      ??  ? ??$
 14.5(?5      5      5      .??5      ?? $??Hidden=?6   $??Disabled=?5      .??5   
   ?  ? RowDefinitions 5      ?? 5      $??90 ?6    ?? 5      $??50 ?6    $??50??6,   ?? 5      $
??251* ?6    .+?5      ?? -   5        $	??220??5      $??30,0,0,0q?5      $??Center=?5       $
??Left=?5!      $??0??5"      $??/Images/logo.png??5#      ?? 5$      -   5         ??Name$ 	CartField??5%      $??0??5$       ?? Orientation$ 
Horizontal=?5&      $??Right=?5(      $??Center=?5)      $??0,0,60,0q?5*      .+?5+      ?? $??/Images/retail.png??6   $??50??5,      ?? 5-      $ Vertical=?6   $??Center=?5.      $??10,0,0,0q?5/      .+?50      ?? $??Моя корзина??6    $??14(?51       ?? 52      -   5        	 ??Name$	 shoppingСart??52       $??15(?53      ???#004eff$(??"Ваша корзина пуста??55      56      57      ?? 58      $??1??6   ???#0000806%   ?? 5;      -   5        $ AdminButton??5;      $ 
Horizontal=?5<      $??1??5=      $y?Hidden=?5>      $??	100,0,0,0q?5?       5@      
 ?? 	Resources??%d  '??       ?? 5A      " ??6   .?5B      ??  ? ??$ 15(?65   ?? 5C       ? ??$ 28??63   ?? 5D       ? ??$	 140??62   ?? 5E       ? ??
 ?????67   ?? 5F       ? ?? ?#00008067   
 5G      ???? 5H      '??       " ??6$   .?5I   "   ??  ?@??CornerRadius$ 3??6A   5J      5K      5L      5M      .+?5N      ?? -   5        $??Товары??5N      6*   ?? 5O      -   5        $??Продажи??5O      $??20,0,0,0q?6+   6=   5P      ? 5R      -   5         ?Name$ 
searchGrid??5R      
???????$??1??5T      $	??700??5U      $??40??5V       ? ColumnDefinitions 5W      ?? 5X      $??40 ?6'   ?? 5Y      .+?5[      ?? $??/Images/Search-ico.png??6   $??4,0,0,0q?5\      $??13??5]      $??0??5^      $??Center=?5_      ?? 5`      -   5         ??Name$ 	searchBox??5`      $??4,0,0,0q?5a      $??15(?5b      $??0q?5c      
??????????#0000$??Center=?5h      $2??,Введите название товара??5i      $??1??5j      $??Stretch=?5k      62   5l      ? 5m      $??1??6   $??0,0,60,0q?5n      $??Right=?5o      .+?5p      ?? -	   5        $	 authAccount??5p      
???????$??Center=?5r      #??[  5s      ?? 5t      -
   5        
???????.?5t   C   
Войти6J    | ?? 5v      -   5        
???????.?5v   J   Регистрация6W   5w      ?? 5x      -   5        $	 personalAccount??5x      
???????$y?Hidden=?5z      $??Center=?5{      #??[  5|      ?? 5}      -   5        
???????.?5}   M   Личный кабинет6]    | ?? 5      -   5        
???????.?5   C   
Выйти6J   5?      5?       ? 5?      -   5          ?Name$ 	PageFrame??5?      $??2??6'     ? Source$+ %/Pages/MainRecommendationProduct.xaml??5?        ? NavigationUIVisibility$ Hidden=?5?      ?? 5?      -   5        $	??200??5?      $?? 1??5?      $
??Left=?5?      $??	100,0,0,0q?5?      ._?5?      ?? -   5        $ CategoryStack??5?      $ 
Horizontal=?5?      .+?5?      ?? $??/Images/menu.png??6   $??0,0,0,0q?5?      $??25??5?      ?? 5?      
???????$
??15.5(?5?       $??Center=?5?      $??15,0,0,2q?5?       $#??Каталог товаров??5?       5?      5?      ?? 5?      -   5         ??Name$ listProduct??5?      $y?Hidden=?5?      $	??258??5?      $??
60,0,0,100q?5?      
?????? $??2??5?   1   $??0q?5?      
?????? $
??Left=?5?      ??5?      ?? 5?      .R?5?      ? $??Stretch=?6    ???#F5F5F5$	??258??5?   $   $??35??5?   $   $??-9,-9,-10,-8q?5?   $   .+?5?      9? -   5        $??0q?5?   '   
???????$	??0.5q?5?   +   ???#F5F5F5???#1719FD$??Stretch=?5?   +   ??5?   +   ?? *Name+.??5?   "   ?? ??6*   ?? *Subcategories+??5?   &   ?? 5?   *   .R?5?   .   ?? -   5        $	??258??5?   6   ._?5?   2   ?? $??15(?6R   $??Center=?5?   4   $??30??5?   4   $??WordEllipsis=?5?   4   $??30,6,0,0q?5?   4   ??5?   <   ?? *Name+5?   4   5?   /   5?   +   5?   #   5?      5?      5?      5?      5?      5?      5?      