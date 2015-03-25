using UnityEngine;
using System.Collections;
using System.IO;


public class Menu : MonoBehaviour {

// INITIALISATION DES VARIABLES

	private bool menu_editeur = false;
	private bool menu_principal=true;         
	private bool menu_jouer=false;
	private bool menu_paramètres=false;
	private bool menu_cartes=false;
	private bool tuto = false; 
	private bool musique = false;
	private bool sons = false;
	private string s_carte = "carte 1";
	private string s_musique = "Musique On";
	private string s_sons = "Sons On";
	private bool menu_options = false;
	private int i_difficulte=1;
	private string s_difficulte="Difficulté : Facile";
	private string s_tuto="Tuto On";
	public GUIStyle customButton;


	// coordonnées des boutons

	private int l1=60;   //Large
	private int l2=40;	 //Fin
	private int h1=125;  //hauteur 
	private int h2=185;
	private int h3=245;
	private int h4=305;
	private int c1=245;   //première colonne
	private int c2=485;   //deuxième colonne
	private int lo=200;   //longueur

	// variables relatives aux cartes

	private bool p1=false;
	private bool p2=false;
	private bool p3=false;
	private bool p4=false;
	private bool p5=false;
	private bool p6=false;
	private bool p7=false;



	void Start() {
		if (System.IO.File.Exists("carte 1.txt"))
		{
			p1 = true;
		}
		if (System.IO.File.Exists("carte 2.txt"))
		{
			p2 = true;
		}
		if (System.IO.File.Exists("carte 3.txt"))
		{
			p3 = true;
		}
		if (System.IO.File.Exists("carte 4.txt"))
		{
			p4 = true;
		}
		if (System.IO.File.Exists("carte 5.txt"))
		{
			p5 = true;
		}
		if (System.IO.File.Exists("carte 6.txt"))
		{
			p6 = true;
		}
		if (System.IO.File.Exists("carte 7.txt"))
		{
			p7 = true;
		}
	}


	// Permet de personaliser les bouton
	
	void OnGUI () {

		GUI.color = new Color (2, 1, 0, 1);       // changer les paramètres de la fonction change la couleur


		// MENU PRINCIPAL



				if (menu_principal == true) {

						// Ferme les autres menus
						
						menu_paramètres = false;   
						menu_cartes = false;
						menu_options = false;
		
						GUI.Box (new Rect (220, 70, 490, 305), "SPACE PIRATES !");     // Inclure le logo à la place de Space Pirates !
		
		
						if (GUI.Button (new Rect (c1, h1, lo, l1), "Jouer")) {   // Custom button permet de personaliser le bouton, à partir
								// de l'inspector 

								if (menu_jouer == true) { 

										menu_jouer = false;


			
								} else
										menu_jouer = true;

						}

						if (GUI.Button (new Rect (c1, 205, lo, l1), "Options")) {   

								// ouvre le menu des options

								menu_options = true;  

 
						}

						if (GUI.Button (new Rect (c1, 285, lo, l1), "Crédit")) {  

								// Ouvre les crédits
 
						}
				}




	// MENU OPTIONS



			if (menu_options == true) {

				// Ferme les autres menus

				menu_principal=false;  
				menu_cartes=false;
				menu_paramètres=false;
				menu_jouer=false;
				menu_editeur=false;
					
				GUI.Box (new Rect (220, 70, 490, 305), "Options");


				if (GUI.Button (new Rect (c1, h1, lo, l1), s_musique)) {

					if (musique==true) {
						musique=false;             // Fait passer musique à off si il était on, et inversement
					}else musique=true;
					
					if (s_musique=="Musique On"){
						s_musique="Musique Off";
					}else s_musique="Musique On";

				}

				if (GUI.Button (new Rect (c2, h1, lo, l1), s_sons)) {

					if (sons==true) {
						sons=false;             // Fait passer sons à off si il était on, et inversement
					}else sons=true;
					
					if (s_sons=="Tuto On"){
						s_sons="Tuto Off";
					}else s_sons="Tuto On";

				}
				if (GUI.Button (new Rect (c1, 285, lo, l1), "Retour")) {  


					// Réouvre le menu principal

					menu_options=false;
					menu_principal=true;

					
					
					
				}
			}


			if (menu_jouer == true) { 

					if (GUI.Button (new Rect (c2, 205, lo, l1), "Partie Rapide")) {  

							// Lance le jeu avec les paramètres par défault
							// fonction pour lancer la scène avec passage de paramètres

					}

					if (GUI.Button (new Rect (c2, 285, lo, l1), "Paramètres")) {  

							// Ouvre le menu Paramètres

							menu_paramètres = true;

					}

			}
	


	// MENU PARAMETRES


		if (menu_paramètres==true) {


			// Ferme les autres menus

			menu_principal=false;  
			menu_cartes=false;
			menu_options=false;
			menu_jouer=false;	
			menu_editeur=false;

			GUI.Box (new Rect (220, 70, 490, 305), "Paramètres");


			if (GUI.Button (new Rect (c1, h1, lo, l1), s_difficulte)) {  // Facile, normal, difficile 


				// Modifie la difficulté, et l'affichage

				if (i_difficulte==1){
					i_difficulte=2;
					s_difficulte="Difficulté : Normal";         
				}else if  (i_difficulte==2){
					i_difficulte=3;
					s_difficulte="Difficulté : Difficile";
				}else if (i_difficulte==3){
					i_difficulte=1;
					s_difficulte="Difficulté : Facile";
				}
				 
				
			}

			if (GUI.Button (new Rect (c1, 205, lo, l1), "Choisir carte")) {  
				
				// Modifie la carte
				// Récupère les cartes dans un fichier, pas d'aperçus pour le moment.
				//Ouvre le menu cartes

				menu_cartes=true; 
				
			}

			if (GUI.Button (new Rect (c1, 285, lo, l1), s_tuto)) {  // Changer le texte affiché sur le bouton en fonction de la variable tuto

				if (tuto==true) {
					tuto=false;             // Fait passer tuto à off si il était on, et inversement
				}else tuto=true;

				if (s_tuto=="Tuto On"){
					s_tuto="Tuto Off";
				}else s_tuto="Tuto On";



				
			}

			if (GUI.Button (new Rect (c2, 205, lo, l1), "Lancer la partie")) {  
				
				// Lance la partie avec les paramètres modifiés
				
			}

			if (GUI.Button (new Rect (c2, 285, lo, l1), "Retour")) {  
				
				menu_paramètres=false;  // Ferme le menu paramètre
				menu_principal=true;	// Ouvre le menu Principal
				menu_editeur=false;
			}


		}




	// MENU CARTES

		if (menu_cartes == true) {

			// Ferme les autres menus

			menu_principal = false;  
			menu_paramètres = false;
			menu_editeur = false;
			menu_options = false;

			GUI.Box (new Rect (220, 70, 490, 305), "Choix de la carte");


			if (p1 == true) {

				if (GUI.Button (new Rect (c1, h1, lo, l2), "Carte 1")) {  

					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 1";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;

				}
			}
			else if (GUI.Button (new Rect (c1, h1, lo, l2), "Créer une nouvelle carte!"))
			{
				s_carte = "Carte 1";
				savingSettings(false);
				Application.LoadLevel("Creator");					
			}

			if (p2 == true) {
			
				if (GUI.Button (new Rect (c1, h2, lo, l2), "Carte 2")) {  

					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 2";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;
				
				}
			} else if (GUI.Button (new Rect (c1, h2, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 2";
				savingSettings(false);
				Application.LoadLevel("Creator");					

		
			}

			if (p3 == true) {
					if (GUI.Button (new Rect (c1, h3, lo, l2), "Carte 3")) {  

						// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
						s_carte = "Carte 3";
						// Ouvre le menu d'édition de carte et ferme les autres menus
						menu_principal = false;  
						menu_paramètres = false;
						menu_editeur = true;
						menu_options = false;
						menu_cartes = false;
						
				}
			} else if (GUI.Button (new Rect (c1, h3, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 3";
				savingSettings(false);
				Application.LoadLevel("Creator");					
			}

			if (p4 == true) {

				if (GUI.Button (new Rect (c2, h1, lo, l2), "Carte 4")) {  
			
					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 4";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;
				
				}
			} else if (GUI.Button (new Rect (c2, h1, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 4";
				savingSettings(false);
				Application.LoadLevel("Creator");					

			}

			if (p5 == true) {
				if (GUI.Button (new Rect (c2, h2, lo, l2), "Carte 5")) {  
		
					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 5";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;

				}
			} else if (GUI.Button (new Rect (c2, h2, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 5";
				savingSettings(false);
				Application.LoadLevel("Creator");					

			}

			if (p6 == true) {
				
				if (GUI.Button (new Rect (c2, h3, lo, l2), "Carte 6")) {  
					
					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 6";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;

				}
			} else if (GUI.Button (new Rect (c2, h3, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 6";
				savingSettings(false);
				Application.LoadLevel("Creator");					

			}

			if (p7 == true) {
				
				if (GUI.Button (new Rect (c2, h4, lo, l2), "Carte 7")) {  
					
					// Change la valeur de s_editeur afin de changer le nom du menu qui va s'ouvrir
					s_carte = "Carte 7";
					// Ouvre le menu d'édition de carte et ferme les autres menus
					menu_principal = false;  
					menu_paramètres = false;
					menu_editeur = true;
					menu_options = false;
					menu_cartes = false;

				}

			} else if (GUI.Button (new Rect (c2, h4, lo, l2), "Créer une nouvelle carte!")) {
				s_carte = "Carte 7";
				savingSettings(false);
				Application.LoadLevel("Creator");					

			}
					
			if (GUI.Button (new Rect (c1, h4, lo, l2), "Retour")) {  
				
						menu_paramètres = true; 
						menu_cartes = false;

		
				}

		}

	// MENU EDITEUR DE CARTE



		if (menu_editeur == true) {

			GUI.Box (new Rect (220, 70, 490, 305), s_carte);
	
			if (GUI.Button (new Rect (365, h1, lo, l2), "Editer")) { 


				// Ouvre l'éditeur de carte
				savingSettings(true);
				Application.LoadLevel("Creator");					



			}

			if (GUI.Button (new Rect (365, h2, lo, l2), "Supprimer")) { 

				Debug.Log(s_carte);
			// Supprime la carte
				if (s_carte=="Carte 1")
				{
					File.Delete("Carte 1.txt");
					p1=false;
				}
				if (s_carte=="Carte 2")
				{
					File.Delete("Carte 2.txt");
					p2=false;
				}
			if (s_carte=="Carte 3")
				{
					File.Delete("Carte 3.txt");
					p3=false;
				}
			if (s_carte=="Carte 4") 
				{
					File.Delete("Carte 4.txt");
					p4=false;
				}
			if (s_carte=="Carte 5") 
				{
					File.Delete("Carte 5.txt");
					p5=false;
				}
			if (s_carte=="Carte 6") 
				{
					File.Delete("Carte 6.txt");
					p6=false;
				}
			if (s_carte=="Carte 7") 
				{
					File.Delete("Carte 7.txt");
					p7=false;
				}

				menu_cartes = true;
				
				menu_principal = false;  
				menu_paramètres = false;
				menu_editeur=false;
				menu_options=false;

			}
			if (GUI.Button (new Rect (365, h3, lo, l2), "Sélectionner")) { 

			// Enregistre la carte dans le fichier paramètre
				savingSettings(true);

				menu_cartes = true;
				
				menu_principal = false;  
				menu_paramètres = false;
				menu_editeur=false;
				menu_options=false;


			}
			if (GUI.Button (new Rect (365, h4, lo, l2), "Retour")) { 

			// retourne au menu des cartes

			menu_cartes = true;

			menu_principal = false;  
			menu_paramètres = false;
			menu_editeur=false;
			menu_options=false;


			}
		}
	}

	void savingSettings(bool load)
	{
		TextWriter writer;
		string fileName = "settings.txt";
		writer = new StreamWriter (fileName);
		writer.WriteLine (s_carte);
		writer.WriteLine (load);

		writer.Close (); 
	}
}