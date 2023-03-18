# Groupe_4_VR

## __Goupe Composé de Chêne Théophile et Cronier Clément.__

Le projet possède deux facettes. Les deux facettes sont accessibles librement depuis le menu. Il suffit de cliquer sur la facette souhaitée, et une téléportation s'effectuera.

![alt text](https://github.com/chenetheophile/Groupe_4_VR/blob/main/Img/Screen_menu.png)




Dans le mode libre, vous pouvez peindre librement avec le pinceau ou la balle. Pour changer la couleur, dans la main gauche, se trouve un sélecteur de couleur. Vous pouvez choisir de passer du pinceau à la balle en interagissant avec l'image du ballon/pinceau. Pour revenir au menu, il faut interagir avec l'icône du menu.

La balle est un objet que vous pouvez lancer sur la toile. Si vous avez perdu votre balle, en interagissant de nouveau avec le logo de balle, celle-ci sera remise à son emplacement d'origine. 

![alt text](https://github.com/chenetheophile/Groupe_4_VR/blob/main/Img/Screen_Libre.png)





Dans le Mini jeu, vous devez suivre le labyrinthe du début jusqu'à la fin. Le labyrinthe est choisi aléatoirement parmi__ 4 labyrinthes.__ Lorsque vous en réussissez un, un autre labyrinthe se met en place aléatoirement.

![alt text](https://github.com/chenetheophile/Groupe_4_VR/blob/main/Img/Screen_mini-jeu.png)


La complétion d'un labyrinthe vous rapporte un point. Lorsque vous touchez une autre couleur (que celle de votre pinceau ou le blanc de la toile), la partie s'arrête et vous êtes téléporté au menu. Dans le menu, vous trouverez le nombre de points que vous avez obtenu pendant la partie précédente.
![alt text](https://github.com/chenetheophile/Groupe_4_VR/blob/main/Img/Screen_menu_defait_MJ.png)




## __Disclaimer:__

Les fonctionnalités ont été testées sans casque VR. Ainsi, la balle, le pinceau, la palette, etc... ont été testé en simulation. Le lancer de balle n'étant pas pratique avec la simulation, nous ne savons pas si elle fonctionne comme l'on souhaite. Nous avons réussi à transmettre une vitesse en simulation et supposons qu'avec de vraies manettes, il n'y aura pas de soucis.

De même, pour les pinceaux. Nous avons constaté leurs fonctionnements en les déplaçant dans la scène pendant la simulation. Il peigne sur les toiles sans soucis. Nous en profitons pour signifier que nous avons réduit la distance minimale requise pour peindre dans les deux modes de jeu. __Il est désormais de 0.15 afin de simuler un vrai pinceau.__ (Le bout du pinceau doit entrer en contact avec la toile pour peindre.)

Pour les labyrinthes, nous ne savons pas si la détection du toucher de mur est suffisamment précise pour fonctionner correctement. 
