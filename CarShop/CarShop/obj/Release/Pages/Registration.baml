   M S B A M L   `   `   `  ???? B  >CarShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CarShopCarShop      CarShop.Registration   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:CarShop       N? 
Background
  ????? N? Title$ Registration?? ? 	Resources  ?? 
TargetType ?? Property ?? Value ?? 	Resources?? %?   '??       'G? ?     ?? " ??.???  ? ??$ 17(???  ? ??
 ???????  ? ??$ 35????  ? ??$ Center=? ???? '??       " ??.???  ?@??CornerRadius$ 2???? " G?.???  ? ??$ Center=?.???  ? ColumnDefinitions ?? $	??490 ??? $??1* ??? $	??490 ?.+???  ?? Orientation$ Vertical=?$??1??$??0,50,0,0q?$??Stretch=?.+??? $??РЕГИСТРАЦИЯ??$??3,0,0,0q?$
??Left=?$??23(??? -   	 ??Name$	 	emailName??$??E-mail??$??0,15,0,0q?.???? -   
 ??Name$
 emailWar??$1??+Данная почта уже занята??$y?Hidden=?
???  ??$??11(??? -   $	 
phonefield??$!??Номер телефона?? ?? 	MaxLength$ 11??$??0,2,0,0q?.??? $??0,17,0,0q?.+??? -   $	 passwordfield??$??Пароль??
???????.??G? -    G?Name$ 	password2??$??1q?$y?Hidden=?
???   ?$??17(?? $??0,17,0,0q?.+??? -   $	 passwordfield2??$%??Повторите пароль??
???????.??G? -   $ 	password1??$??1q?$y?Hidden=?
???   ?$??17(??? -   $
 WarPass??$y?Hidden=?$*??$Пароли не совподает??
???  ??$??11(??? -	   $	 surnamefield??$??Фамилия??$??0,5,0,0q?.???? -
   $	 	namefield??$??Имя??$??0,17,0,0q?.???? -   $	 middlenamefield??$??Отчество??$??0,17,0,0q?.???? -   $??РЕГИСТРАЦИЯ??$??39??$??0,30,0,0q?
???q?<?$??15(??? -   $
 fieladNullWar??$(??"Заполните все поля??$y?Hidden=?
???  ??$??11(?