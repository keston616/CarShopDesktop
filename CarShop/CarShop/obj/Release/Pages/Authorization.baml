   M S B A M L   `   `   `  ???? B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop      CarShop.Authorization   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:CarShop       N? 
Background
  ????? N? Title$ Authorization?? ? 	Resources  ?? 
TargetType ?? Property ?? Value?? %u   '??       ?? " ??.???  ? ??$ 17(???  ? ??
 ???????  ? ??$ 35????  ? ??$ Center=?.???  ? ColumnDefinitions ?? $	??490 ??? $??1* ??? $	??490 ?.+???  ?? Orientation$ Vertical=?$??1??$??0,80,0,0q?$??Stretch=?.+??? $??АВТОРИЗАЦИЯ??$??3,0,0,0q?$
??Left=?$??23(??? -    ??Name$ 	emailName??$??E-mail??$??0,25,0,0q?.?? ??%9   '??       ?? " ??.???  ?@??CornerRadius$ 1??.???? -   	 ??Name$	 emailWar??$0??*Пользователь не найдет??$y?Hidden=?
???  ??$??11(??? -   
 ??Name$
 
passBorder??$y?Visible=?
???   ?$??35?? ?? CornerRadius$ 1??$	??0.2q?$??0,22,0,0q?._?? .+?G? -    G?Name$ passwordfield??$??0q?$y?Hidden=?$??15(?$??25??$??0,2,0,0q?$??Center=? ??%   'G?       ?? " G??? -   $ 
passHelper??$??Пароль??
???????.???? -   $	 PassWar??$%??Пароль не верный ??$y?Hidden=?
???  ??$??11(??? -   $??
ВОЙТИ??$??39??$??0,22,0,0q?
???q?<?$??15(??? -   $	 fieladNullWar??$(??"Заполните все поля??$y?Hidden=?
???  ??$??11(?