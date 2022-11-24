
using System;
using System.Collections.Generic;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string OneAskClassification = "";
            bool StringExists = false;
            int CloudNativeCount = 0; // aks, aro, aca, container, cloud native, k8s, kubernetes
            List<string> CN_SingleTerms = new List<string>()
                { "AKS",
                  "ARO",
                  "ACA",
                  "container",
                  "container app",
                  "ContainerApp",
                 // "containers",
                  "kubernetes"
                  };

            List<string> CN_AKSTerms = new List<string>()
                { "AKS","kubernetes","Kubernetes","k8s","K8S","k8S","K8s"};

            List<string> OneAKSTitles = new List<string>()
                { "Container Apps PoC",
                  "Azure Container App Demo",
                  "Azure ContainerApp Demo",
                  "ACA",
                  "containers",
                  "OneStream Kubernetes on Azure",
                  "Help us decide AKS or ARO.",
                  "Cloud Native Deep Dive with customer (Serverless, Containers, AKS)",
                  "OneStream Kubernetes on Azure",
                  "APIM"
                  };

            foreach (string Title in OneAKSTitles)
            {
                OneAskClassification = "Not Set Yet!";
                CloudNativeCount = 0;
                foreach (string CNTerm in CN_SingleTerms)
                {
                    if (StringExists = Title.Contains(CNTerm, StringComparison.CurrentCultureIgnoreCase))
                    {
                        OneAskClassification = CNTerm;

                        if (CN_AKSTerms.Any(s => s.Contains(CNTerm, StringComparison.CurrentCultureIgnoreCase)))
                            OneAskClassification = "AKS";

                        CloudNativeCount++;
                        if (CloudNativeCount > 1)
                            break;
                    }

                } // terms
                if (CloudNativeCount > 1)
                    OneAskClassification = "Cloud Native";

                Console.WriteLine("final value: " + OneAskClassification + ". Count: " + CloudNativeCount+", "+Title);

            } // Titles

        } // main

    } // End Class = Program




} // End Namespace




