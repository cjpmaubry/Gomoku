using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Program
    {
        static char[,] CreationMatriceJeu()
        {
            char[,] matrice = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matrice[i, j] = ' ';
                }
            }
            return matrice;
        } // Fonction qui génère une grille de gomoku c'est à dire une matrice de taille 19*19

        static void Affichage_Grille(char[,] matrice)
        {
            int compteur = 64;
            Console.WriteLine("----1---2---3---4---5---6---7---8---9---10--11--12--13--14--15");
            for (int indexlignes = 0; indexlignes < matrice.GetLength(0); indexlignes++)
            {
                compteur++;
                Console.WriteLine("----------------------------------------------------------------");
                if (compteur < 10)
                {
                    Console.Write(Convert.ToChar(compteur) + " -|");
                }
                else
                {
                    Console.Write(Convert.ToChar(compteur) + "-|");
                }

                for (int indexcolonnes = 0; indexcolonnes < matrice.GetLength(1); indexcolonnes++)
                {
                    if (matrice[indexlignes, indexcolonnes] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" X ");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("|");
                    }
                    if (matrice[indexlignes, indexcolonnes] == '0')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" 0 ");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("|");
                    }
                    if (matrice[indexlignes, indexcolonnes] == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("   ");
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------------------------");
        } // Fonction qui affiche la grille du morpion c'est à dire affiche une matrice de taille 3*3 avec les séparations

        static bool LigneDePoint(char[,] grille, char point, int nombre)
        {
            bool res = false;
            int compteur = 0;
            for (int i = 0; i < 15; i++)
            {
                compteur = 0;
                for (int j = 0; j < 15; j++)
                {
                    if (grille[i, j] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            return res;
        } //Fonction qui renvoie true s'il y a une ligne de N(nombre) d'un meme signe(point) aligné

        static bool ColonneDePoint(char[,] grille, char point, int nombre)
        {
            bool res = false;
            int compteur = 0;
            for (int i = 0; i < 15; i++)
            {
                compteur = 0;
                for (int j = 0; j < 15; j++)
                {
                    if (grille[j, i] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }//Fonction qui renvoie true s'il y a une colonne de N(nombre) d'un meme signe(point) aligné

        static bool DiagonaleDePoint(char[,] grille, char point, int nombre)
        {
            bool res = false;
            int compteur = 0;

            for (int k = 10; k >= 0; k--)
            {
                for (int i = 0; i < 15 - k; i++)
                {
                    if (grille[k + i, i] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            for (int k = 10; k > 0; k--)
            {
                for (int i = 0; i < 15 - k; i++)
                {
                    if (grille[i, k + i] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            for (int k = 4; k < 14; k++)
            {
                for (int i = 0; i <= k; i++)
                {
                    if (grille[i, k - i] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            for (int k = 0; k < 11; k++)
            {
                for (int i = 14; i >= k; i--)
                {
                    if (grille[14 - i + k, i] == point)
                    {
                        compteur++;
                    }
                    else
                    {
                        compteur = 0;
                    }
                    if (compteur == nombre)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }//Fonction qui renvoie true s'il y a une diagonale de N(nombre) d'un meme signe(point) aligné

        static bool EstGagne(char[,] grille, char point, int nombre)
        {
            bool res = false;
            if (LigneDePoint(grille, point, nombre) == true)
            {
                res = true;
            }
            if (ColonneDePoint(grille, point, nombre) == true)
            {
                res = true;
            }
            if (DiagonaleDePoint(grille, point, nombre) == true)
            {
                res = true;
            }

            return res;
        } // Fonction qui renvoie true s'il y a N(nombre) signe(point) aligné dans la grille de jeu

        static bool Vainqueur(char[,] grille, int nombre)
        {
            bool res = false;
            if (EstGagne(grille, 'X', 5) || EstGagne(grille, '0', 5))
            {
                res = true;
            }
            return res;
        }// Fonction qui renvoie true s'il y a un vainqueur parmi les 2 joueurs

        static int NombrePion(char[,] grille)
        {
            int compteur = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grille[i, j] != ' ')
                    {
                        compteur++;
                    }
                }
            }
            return compteur;
        }// Fonction qui compte le nombre de pion present sur le plateau de jeu

        static int Max(char[,] grille, int profondeur)
        {
            if (Vainqueur(grille, 5) == true || profondeur == 0)
            {
                return Valeur(grille, profondeur);
            }

            int max = -1000000;
            int tempo;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grille[i, j] == ' ')
                    {
                        int[] Coordonnee = { i, j };
                        if (CompteurDeVoisin(grille, Coordonnee) != 0)
                        {
                            grille[i, j] = 'X';
                            tempo = Min(grille, profondeur - 1);
                            if (tempo > max)
                            {
                                max = tempo;
                            }
                            grille[i, j] = ' ';
                        }
                    }
                }
            }
            return max;
        } // Fonction Max 

        static int Min(char[,] grille, int profondeur)
        {
            if (Vainqueur(grille, 5) == true || profondeur == 0)
            {
                return Valeur(grille, profondeur);
            }

            int min = 10000000;
            int tempo;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grille[i, j] == ' ')
                    {
                        int[] Coordonnee = { i, j };
                        if (CompteurDeVoisin(grille, Coordonnee) != 0)
                        {
                            grille[i, j] = '0';
                            tempo = Max(grille, profondeur - 1);
                            if (tempo < min)
                            {
                                min = tempo;
                            }
                            grille[i, j] = ' ';
                        }
                    }
                }
            }
            return min;
        } // Fonction Min 

        static int Valeur(char[,] grille, int profondeur) // Fonction qui attribut " un poid " en fonction de l'endroit ou l'IA peut mettre son pion. (Détermine si oui ou non c'est un bon choix)
        {


            if (Vainqueur(grille, 5) == true)
            {
                if (EstGagne(grille, '0', 5) == true)
                {
                    return -100000 + profondeur;
                }
                if (EstGagne(grille, 'X', 5) == true)
                {

                    return +100000 - profondeur;
                }

            }




            if (NombrePion(grille) == 120)
            {
                return 0;
            }
            return (EstimationMeilleurCoup(grille));

        }

        static int EstimationMeilleurCoup(char[,] grille)
        {
            int resultat = 0;
            int NbXaligne2 = NombreDePointGroupe(grille, 2, 'X');
            int NbXaligne3 = NombreDePointGroupe(grille, 3, 'X');
            int NbXaligne4 = NombreDePointGroupe(grille, 4, 'X');
            int Nb0aligne2 = NombreDePointGroupe(grille, 2, '0');
            int Nb0aligne3 = NombreDePointGroupe(grille, 3, '0');
            int Nb0aligne4 = NombreDePointGroupe(grille, 4, '0');


            resultat = -(NbXaligne2 * 10 + NbXaligne3 * 100 + NbXaligne4 * 1000) + (Nb0aligne2 * 10 + Nb0aligne3 * 100 + Nb0aligne4 * 1000);

            return resultat;
        }  // Fonction qui détermine "un poid du choix" si le jeu n'admet pas encore de vainqueur et n'est pas fini ( sert si la profondeur est faible )

        static int NombreDePointGroupe(char[,] grille, int nombre, char point)
        {
            int resultat = 0;
            int nbligne = NbPointGrLigne(grille, nombre, point);
            int nbcolonne = NbPointGrColonne(grille, nombre, point);
            int nbddiagonale = NbPointGrDiagonale(grille, nombre, point);
            resultat = nbligne + nbcolonne + nbddiagonale;
            return resultat;
        } // Foncton qui compte le nombre de pion groupe d'un joueur

        static int NbPointGrLigne(char[,] grille, int nombre, char point)
        {
            int compteur = 0;
            int compteur2 = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15 - nombre; j++)
                {
                    compteur2 = 0;
                    for (int k = 0; k < nombre; k++)
                    {
                        if (grille[i, j + k] == point)
                        {
                            compteur2++;
                        }
                        if ((grille[i, j + k] != point) && (grille[i, j + k] != ' '))
                        {
                            compteur2 = 0;
                        }
                        if (compteur2 == nombre)
                        {
                            compteur++;
                        }
                    }
                }
            }
            return compteur;
        }   // Foncton qui compte le nombre de pion groupe d'un joueur sur une ligne

        static int NbPointGrColonne(char[,] grille, int nombre, char point)
        {
            {
                int compteur = 0;
                int compteur2 = 0;
                for (int j = 0; j < 15; j++)
                {
                    for (int i = 0; i < 15 - nombre; i++)
                    {
                        compteur2 = 0;
                        for (int k = 0; k < nombre; k++)
                        {
                            if (grille[i + k, j] == point)
                            {
                                compteur2++;
                            }
                            if ((grille[i + k, j] != point) && (grille[i + k, j] != ' '))
                            {
                                compteur2 = 0;
                            }
                            if (compteur2 == nombre)
                            {
                                compteur++;
                            }
                        }
                    }
                }
                return compteur;
            }
        } // Foncton qui compte le nombre de pion groupe d'un joueur sur une colonne

        static int NbPointGrDiagonale(char[,] grille, int nombre, char point)
        {
            int compteur = 0;
            int compteur2 = 0;

            for (int k = 10; k >= 0; k--)
            {
                for (int i = 0; i <= 15 - k - nombre; i++)
                {
                    compteur2 = 0;
                    for (int index = 0; index < nombre; index++)
                    {
                        if (grille[k + i + index, i + index] == point)
                        {
                            compteur2++;
                        }
                        if ((grille[k + i + index, i + index] != point) && (grille[k + i + index, i + index] != ' '))
                        {
                            compteur2 = 0;
                        }
                        if (compteur2 == nombre)
                        {
                            compteur++;
                        }
                    }
                }
            }
            for (int k = 10; k > 0; k--)
            {
                for (int i = 0; i <= 15 - k - nombre; i++)
                {
                    compteur2 = 0;
                    for (int index = 0; index < nombre; index++)
                    {
                        if (grille[i + index, k + i + index] == point)
                        {
                            compteur2++;
                        }
                        if ((grille[i + index, k + i + index] != point) && (grille[i + index, k + i + index] != ' '))
                        {
                            compteur2 = 0;
                        }
                        if (compteur2 == nombre)
                        {
                            compteur++;
                        }
                    }
                }
            }
            for (int k = 4; k < 14; k++)
            {
                for (int i = 0; i <= k - nombre + 1; i++)
                {
                    compteur2 = 0;
                    for (int index = 0; index < nombre; index++)
                    {
                        if (grille[i + index, k - i - index] == point)
                        {
                            compteur2++;
                        }
                        if ((grille[i + index, k - i - index] != point) && (grille[i + index, k - i - index] != ' '))
                        {
                            compteur2 = 0;
                        }
                        if (compteur2 == nombre)
                        {
                            compteur++;
                        }
                    }
                }
            }
            for (int k = 0; k < 11; k++)
            {
                for (int i = 14; i >= k + nombre - 1; i--)
                {
                    compteur2 = 0;
                    for (int index = 0; index < nombre; index++)
                    {
                        if (grille[14 - i + index + k, i - index] == point)
                        {
                            compteur2++;
                        }
                        if ((grille[14 - i + index + k, i - index] != point) && (grille[14 - i + index + k, i - index] != ' '))
                        {
                            compteur2 = 0;
                        }
                        if (compteur2 == nombre)
                        {
                            compteur++;
                        }
                    }
                }
            }

            return compteur;
        } // Foncton qui compte le nombre de pion groupe d'un joueur sur les diagonales

        static void PlacerPion(char[,] grille, int choix, int tour)
        {
            char[] array = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };
            int ligne = 0;
            int colonne = 0;
            if (choix == 1)
            {
                Console.WriteLine("coordonnée ligne (de A à O):");
                int lig = Convert.ToChar(Console.ReadLine());
                for (int i = 0; i < array.Length; i++)
                {
                    if (lig == array[i])
                    {
                        ligne = i;
                    }
                }
                Console.WriteLine("coordonnée colonne (de 1 à 15):");
                colonne = Convert.ToInt32(Console.ReadLine()) - 1;
                grille[ligne, colonne] = 'X';
            }
            if (choix == 2)
            {
                if (tour != 2)
                {
                    Console.WriteLine("coordonnée ligne (de A à O):");
                    int lig = Convert.ToChar(Console.ReadLine());
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (lig == array[i])
                        {
                            ligne = i;
                        }
                    }
                    Console.WriteLine("coordonnée colonne (de 1 à 15):");
                    colonne = Convert.ToInt32(Console.ReadLine()) - 1;
                    grille[ligne, colonne] = '0';
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Placer le pion en dehors du carré 7x7 de centre H8");
                        Console.WriteLine("coordonnée ligne (de A à O):");
                        int lig = Convert.ToChar(Console.ReadLine());
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (lig == array[i])
                            {
                                ligne = i;
                            }
                        }
                        Console.WriteLine("coordonnée colonne (de 1 à 15):");
                        colonne = Convert.ToInt32(Console.ReadLine()) - 1;
                    } while ((ligne > 4 && ligne < 12) && (colonne > 4 && colonne < 12));
                    grille[ligne, colonne] = '0';
                }
            }
        } // Place le pion du joueur au bonne endroit suivant ces indications

        static void JouerIA(char[,] grille, int choix, int tour, int profondeur)
        {
            char[] array = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };
            if (choix == 1)
            {
                if (tour != 2)
                {
                    int min = -1000000;
                    int tmp = 0;
                    int maxi = 0;
                    int maxj = 0;

                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (grille[i, j] == ' ')
                            {
                                int[] Coordonnee = { i, j };
                                if (CompteurDeVoisin(grille, Coordonnee) != 0)
                                {
                                    grille[i, j] = 'X';
                                    tmp = Min(grille, profondeur - 1);
                                    if (tmp > min)
                                    {
                                        min = tmp;
                                        maxi = i;
                                        maxj = j;
                                    }
                                    grille[i, j] = ' ';
                                }
                            }
                        }
                    }
                    grille[maxi, maxj] = '0';
                    Console.WriteLine("\nPlacement du pion : " + array[maxi] + (maxj + 1));
                }
                else
                {
                    grille[0, 4] = '0';
                    Console.WriteLine("\nPlacement du pion : " + array[0] + (1));
                }
            }

            if (choix == 2)
            {
                int max = 1000000;
                int tmp = 0;
                int maxi = 0;
                int maxj = 0;

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (grille[i, j] == ' ')
                        {
                            int[] Coordonnee = { i, j };
                            if (CompteurDeVoisin(grille, Coordonnee) != 0)
                            {
                                grille[i, j] = '0';
                                tmp = Max(grille, profondeur - 1);
                                if (tmp < max)
                                {
                                    max = tmp;
                                    maxi = i;
                                    maxj = j;
                                }
                                grille[i, j] = ' ';
                            }
                        }
                    }
                }
                grille[maxi, maxj] = 'X';
                Console.WriteLine("\nPlacement du pion : " + array[maxi] + (maxj + 1));
            }
        } // Execute les algorithmes Min et Max et place sur le plateau le pion de l'IA suivant les resultats obtenu par les algos

        static int CompteurDeVoisin(char[,] Matrice, int[] Coordonnee)
        {
            int compteur = 0;
            for (int indexLigne = 0; indexLigne < 3; indexLigne++)
            {
                for (int indexColonne = 0; indexColonne < 3; indexColonne++)
                {
                    int CoordonneeLigne = (Coordonnee[0] - 1 + indexLigne);
                    int CoordonneeColonne = (Coordonnee[1] - 1 + indexColonne);

                    if ((Coordonnee[0] != CoordonneeLigne) || (Coordonnee[1] != CoordonneeColonne))
                    {
                        if ((CoordonneeLigne < 15) && (CoordonneeColonne < 15) && (CoordonneeLigne > -1) && (CoordonneeColonne > -1))
                        {

                            if (Matrice[CoordonneeLigne, CoordonneeColonne] != ' ')
                                compteur++;
                        }
                    }

                }
            }
            return compteur;
        } // Fonction qui compte le nombre de pion autour d'un pion donne

        static void Gomoku(char[,] grille)
        {
            // Initialisation
            int tour = 1;
            int profondeur = 3;
            int choix = -1;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("--------------------Jeux du Gomoku------------------------------");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Profondeur = " + profondeur);
            Console.WriteLine();
            Console.WriteLine();
            do
            {
                Console.WriteLine("Voulez vous jouer en premier ?");
                Console.WriteLine("Taper 1 pour OUI");
                Console.WriteLine("Taper 2 pour NON");
                choix = Convert.ToInt32(Console.ReadLine());
            } while ((choix != 1) && (choix != 2));

            switch (choix)
            {
                case 1:
                    while ((EstGagne(grille, 'X', 5) == false) && (EstGagne(grille, '0', 5) == false) && (NombrePion(grille) != 120))
                    {
                        Affichage_Grille(grille);
                        if (tour == 1)
                        {
                            Console.WriteLine("\nTour du Joueur :\n");
                            grille[7, 7] = 'X';
                            tour++;
                        }
                        else
                        {
                            if (tour % 2 != 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tour du Joueur :");
                                PlacerPion(grille, choix, tour);
                                tour++;
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tour de l'IA :");
                                JouerIA(grille, choix, tour, profondeur);
                                tour++;
                                Console.WriteLine();
                            }
                        }
                    }
                    Affichage_Grille(grille);
                    if (EstGagne(grille, 'X', 5) == true)
                    {
                        Console.WriteLine("\n\nLe joueur 1 gagne");
                    }
                    if (EstGagne(grille, '0', 5) == true)
                    {
                        Console.WriteLine("\n\nLe joueur 2 gagne");
                    }
                    break;

                case 2:
                    while ((EstGagne(grille, 'X', 5) == false) && (EstGagne(grille, '0', 5) == false) && (NombrePion(grille) != 120))
                    {
                        Affichage_Grille(grille);
                        if (tour == 1)
                        {
                            Console.WriteLine("\nTour de l'IA:\n");
                            grille[7, 7] = 'X';
                            tour++;
                        }
                        else
                        {
                            if (tour % 2 == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tour du Joueur :");
                                PlacerPion(grille, choix, tour);
                                tour++;
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tour de l'IA :");
                                JouerIA(grille, choix, tour, profondeur);
                                tour++;
                                Console.WriteLine();
                            }
                        }
                    }
                    Affichage_Grille(grille);
                    if (EstGagne(grille, 'X', 5) == true)
                    {
                        Console.WriteLine("\n\nLe joueur 1 gagne");
                    }
                    if (EstGagne(grille, '0', 5) == true)
                    {
                        Console.WriteLine("\n\nLe joueur 2 gagne");
                    }
                    break;
            }
        } // Programme  Gomoku,il gere les tours de jeu en lancant les  autres fonctions au bon moment

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.WindowHeight = 45;
            Console.WindowWidth = 100;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            do
            {
                //Menu
                Console.Clear();
                char[,] grille = CreationMatriceJeu();
                Gomoku(grille);
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
            Console.ReadKey();
        }
    }
}

