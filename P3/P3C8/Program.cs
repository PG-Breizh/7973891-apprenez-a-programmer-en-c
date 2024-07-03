using System.Reflection.Metadata;
using System.Transactions;
using System;

namespace P3C8
{
    class Program
    {
        static void Main()
        {
            var compteBancaire = new CompteBancaire("Clyde", 1, 100, 0);
            gestion(compteBancaire);
        }
        static void gestion(CompteBancaire compteBancaire)
        {
            string? action;
            double montant;
            bool exitWhile = false;
            string transaction;
            List<string> transactions = new List<string>();

            do
            {
                Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
                action = Console.ReadLine();
                transaction = "";
                switch (action)
                {
                    case ("I"):
                        Console.WriteLine($"Le titulaire est {compteBancaire.Titulaire} et le numéro du compte est le {compteBancaire.NumeroDuCompte:D4}");
                        break;
                    case ("CS"):
                        Console.WriteLine($"Le solde du compte courant de {compteBancaire.Titulaire} est de {compteBancaire.CompteCourant:N2} euros");
                        break;
                    case ("CD"):
                        Console.Write("Quel montant souhaitez-vous déposer sur le compte courant ? ");
                        double.TryParse(Console.ReadLine(), out montant);
                        compteBancaire.DépotCompteCourant(montant);
                        transaction = $"Dépot de {montant:F2} euros sur le compte courant de {compteBancaire.Titulaire}";
                        break;
                    case ("CR"):
                        Console.Write("Quel montant souhaitez-vous retirer sur le compte courant ? ");
                        double.TryParse(Console.ReadLine(), out montant);
                        compteBancaire.RetraitCompteCourant(montant);
                        transaction = $"Retrait de {montant:F2} euros sur le compte courant de {compteBancaire.Titulaire}";
                        break;
                    case ("ES"):
                        Console.WriteLine($"Le solde du compte courant de {compteBancaire.Titulaire} est de {compteBancaire.CompteEpargne:N2} euros");
                        break;
                    case ("ED"):
                        Console.Write("Quel montant souhaitez-vous déposer sur le compte épargne ? ");
                        double.TryParse(Console.ReadLine(), out montant);
                        compteBancaire.DépotCompteEpargne(montant);
                        transaction = $"Dépot de {montant:F2} euros sur le compte épargne de {compteBancaire.Titulaire}";
                        break;
                    case ("ER"):
                        Console.Write("Quel montant souhaitez-vous retirer sur le compte épargne ? ");
                        double.TryParse(Console.ReadLine(), out montant);
                        compteBancaire.RetraitCompteEpargne(montant);
                        transaction = $"Retrait de {montant:F2} euros sur le compte épargne de {compteBancaire.Titulaire}";
                        break;
                    case ("X"):
                        StreamWriter streamWriter = new StreamWriter(@"C:\temp\transactions.txt");
                        foreach (var transactionString in transactions)
                        {
                            streamWriter.WriteLine(transactionString);
                        }
                        streamWriter.Close();
                        exitWhile = true;
                        break;
                    default:
                        afficheMenu();
                        break;
                }
                if (transaction != "")
                {
                    Console.WriteLine(transaction);
                    transactions.Add(transaction);
                }
            }
            while (!exitWhile);
        }
        static void afficheMenu()
        {
            Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
            Console.WriteLine(
"[I] Voir les informations sur le titulaire du compte\n" +
"[CS] Compte courant - Consulter le solde\n" +
"[CD] Compte courant - Déposer des fonds\n" +
"[CR] Compte courant - Retirer des fonds\n" +
"[ES] Compte épargne - Consulter le solde\n" +
"[ED] Compte épargne - Déposer des fonds\n" +
"[ER] Compte épargne - Retirer des fonds\n" +
"[X] Quitter");
        }
    }
}