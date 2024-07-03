namespace P3C8
{
    public class CompteBancaire
    {
        private string titulaire;
        private int numeroDuCompte;
        private double compteCourant;
        private double compteEpargne;
        
        public CompteBancaire(string titulaire, int numeroDuCompte, double compteCourant, double compteEpargne)
        {
            this.titulaire = titulaire;
            this.numeroDuCompte = numeroDuCompte;
            this.compteEpargne = compteEpargne;
            this.compteCourant = compteCourant;
        }
        public string Titulaire
        {
            get { return titulaire; }
            set { titulaire = value; }
        }
        public int NumeroDuCompte
        {
            get { return numeroDuCompte; }
        }
        public double CompteCourant
        {
            get { return compteCourant; }
        }
        public double CompteEpargne
        {
            get { return compteEpargne; }
        }
        public void DépotCompteCourant(double montant)
        {
            this.compteCourant += montant;
        }
        public void RetraitCompteCourant(double montant)
        {
            this.compteCourant -= montant;
        }
        public void DépotCompteEpargne(double montant)
        {
            this.compteEpargne += montant;
        }
        public void RetraitCompteEpargne(double montant)
        {
            this.compteEpargne -= montant;
        }
    }
}
