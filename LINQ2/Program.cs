
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
              List<string> OneAKSTitles = new List<string>()
                { 
                  "Container Apps PoC",
                  "help understanding containers",                            
                  "architect for AKS or Container app",                  
                  "Azure Container App Demo",
                  "Azure ContainerApp Demo",
                  "ACA",                      
                  "Help us decide AKS or ARO.",
                  "Cloud Native Deep Dive with customer (Serverless, Containers, AKS)",
                  "OneStream Kubernetes on Azure",
                  "APIM"
                  };
            Console.WriteLine("Hello World!");
            string OneAskClassification = "";
           
            int CloudNativeCount = 0; // aks, aro, aca, container, cloud native, k8s, kubernetes
            List<string> CN_SingleTerms = new List<string>()
                { "AKS",
                  "ARO",
                  "ACA",
                  "container",
                //   "container app",
                //   "ContainerApp",   
                  "k8s",              
                  "kubernetes"
                  };

            List<string> CN_AKSTerms = new List<string>()
                { "AKS","kubernetes","Kubernetes","k8s"};
            List<string> CN_ACATerms = new List<string>()
                { "ACA","container app","ContainerApp"};          

            foreach (string Title in OneAKSTitles)
            {
                OneAskClassification = "Not Set Yet!";
                CloudNativeCount = 0;
                foreach (string CNTerm in CN_SingleTerms)
                {
                    if (Title.Contains(CNTerm, StringComparison.CurrentCultureIgnoreCase))
                    {
                        // you made it this far so count it as a CN terms and capture which ever term we found
                        CloudNativeCount++;
                        OneAskClassification = CNTerm;

                        // if count is greater than 1, we call it CN and are done
                        if (CloudNativeCount > 1)
                            break;

                        // Tagging processing
                        // s is the
                        if (Title.Contains("container", StringComparison.CurrentCultureIgnoreCase))
                            if (Title.Contains("container app", StringComparison.CurrentCultureIgnoreCase))
                                OneAskClassification = "ACA";
                            else  
                                if (Title.Contains("ContainerApp", StringComparison.CurrentCultureIgnoreCase))
                                    OneAskClassification = "ACA";
                                else
                                    OneAskClassification = "Cloud Native";                                          
                        
                        if (CN_ACATerms.Any(s => s.Equals(CNTerm, StringComparison.CurrentCultureIgnoreCase)))
                                OneAskClassification = "ACA";
                        
                        if (CN_AKSTerms.Any(s => s.Equals(CNTerm, StringComparison.CurrentCultureIgnoreCase)))
                            OneAskClassification = "AKS";                     
                        
                        string repattern = @"(cloud).(native)";
                        if (Regex.IsMatch(CNTerm,repattern,RegexOptions.IgnoreCase))
                            OneAskClassification = "Cloud Native";

                       
                    }

                } // terms
                if (CloudNativeCount > 1)
                    OneAskClassification = "Cloud Native";

                Console.WriteLine("final value: " + OneAskClassification + ". Count: " + CloudNativeCount+", "+Title);

            } // Titles

        } // main

    } // End Class = Program




} // End Namespace




