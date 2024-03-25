namespace juliasVigenereChiffer
{
    class Program
    {
        //Mainmetod
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("LOADING...");
                Console.ReadKey();
                Console.WriteLine("Skriv in nyckelord.");
                string userinput = Console.ReadLine();
                char[] keyword = userinput.ToCharArray(); //delar in användardatan till nyckelordet som ska användas
                int[] numericRefKey = new int[keyword.Length]; //siffrorna som respresenterar bokstäverna i nyckelordet


                for (int i = 0; i < keyword.Length; i++)
                {
                    numericRefKey[i] = (int)keyword[i]; //här tilldelas siffrorna som respresenterar nyckelordets tecken
                }

                Console.WriteLine("Skriv in det du önskar kryptera.");
                userinput = Console.ReadLine();
                char[] secret = userinput.ToCharArray(); //arrayen av tecknena som ska omvandlas

                int[] numericRefSecret = new int[secret.Length]; //talen som respresenterar tecknena i secret
                int[] keyIndexes = new int[secret.Length]; //index för nyckeltalen
                int[] newOutputIndex = new int[secret.Length]; //indexen som räknas ut mha modulus
                char[] output = new char[secret.Length]; //outputen, kommer från outputIndex


                for (int i = 0; i < secret.Length; i++)
                {
                    numericRefSecret[i] = (int)secret[i]; //de tal som respresenterar den okrypterade datans tecken, ska omvandlas!!!
                }


                for (int i = 0; i < secret.Length; i++)
                {
                    int j = i % numericRefKey.Length; //kollar vilket index i nyckeln som ska kryptera tecknet

                    newOutputIndex[i] = numericRefSecret[i] + numericRefKey[j]; //nytt index
                    output[i] = (char)newOutputIndex[i]; //output tecknet vi får mha numret

                }
                Console.WriteLine("Krypterad data:");
                foreach (char c in output) //skriver ut varje tecken som finns i output
                {

                    Console.Write(c); //skriver ut alla tecken
                }


                int[] reverseOutputIndex = new int[secret.Length];
                char[] reverseOutput = new char[secret.Length];


                for (int i = 0; i < secret.Length; i++)
                {
                    int j = (int)(output[i]);
                    reverseOutputIndex[i] = j - numericRefKey[i];
                    reverseOutput[i] = (char)(reverseOutputIndex[i]);

                }
                Console.WriteLine("");
                Console.WriteLine("Ursprunglig data:");
                foreach (char c in reverseOutput) //skriver ut varje tecken som finns i reverseOutput
                {

                    Console.Write(c); //skriver ut alla tecken
                }
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
