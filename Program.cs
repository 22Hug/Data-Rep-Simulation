namespace Data_Rep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Without input 

            //// Driver names
            //string[] driverNames = { "George Russell", "Max Verstappen", "Charles Leclerc", "Lewis Hamilton", "Kimi Antonelli", "Lando Norris", "Oscar Piastri", "Other Drivers" };

            //// Market implied probabilities (MUST add up to 1)
            //double[] probabilities = { 0.28, 0.21, 0.14, 0.11, 0.09, 0.09, 0.06, 0.08 };

            //// Store simulated wins 
            //int[] simWins = new int[driverNames.Length];

            //int sim = 1000000;
            //Random random = new Random();

            //for (int i = 0; i < sim; i++)
            //{
            //    double randValue = random.NextDouble();
            //    double cumulativeNum = 0;

            //    for (int j = 0; j < probabilities.Length; j++)
            //    {
            //        cumulativeNum = cumulativeNum + probabilities[j];

            //        if (randValue <= cumulativeNum)
            //        {
            //            simWins[j]++;
            //            break;
            //        }
            //    }
            //}

            //// Display results
            //Console.WriteLine("=== Championship Simulation Results ===\n");

            //for (int i = 0; i < driverNames.Length; i++)
            //{
            //    double winPerc = (double)simWins[i] / sim * 100;

            //    Console.WriteLine(driverNames[i]);
            //    Console.WriteLine("Simulated Wins: " + simWins[i]);
            //    Console.WriteLine("Simulated Win %: " + winPerc.ToString("F2") + "%");
            //    Console.WriteLine("------------------------------------");
            //}

            //with input

            Random rand = new Random();
            int sims = 0;
            int NumOfDrivers = 0;
            double TotalProb = 0.00;

            Console.WriteLine("F1 World Driver's Championship Simulator\n");

            //num of drivers
            Console.Write("Enter number of drivers: ");
            NumOfDrivers = Convert.ToInt32(Console.ReadLine());

            //strings
            string[] driverNames = new string[NumOfDrivers];
            double[] probabilities = new double[NumOfDrivers];
            int[] simulatedWins = new int[NumOfDrivers];

            //Enter driver's names and prob
            for (int i = 0; i < NumOfDrivers; i++)
            {
                Console.Write("\nEnter name of driver number " + (i + 1) + ": ");
                driverNames[i] = Console.ReadLine();

                Console.Write("Enter probability for " + driverNames[i] + " (e.g. 0.99 - to 2 d.p. for the best results): ");
                probabilities[i] = Convert.ToDouble(Console.ReadLine());
            }

            //total probability
            for (int i = 0; i < NumOfDrivers; i++)
            {
                TotalProb += probabilities[i];
            }

            Console.WriteLine("\nTotal Probability Entered: " + TotalProb);

            if (TotalProb > 1.001 || TotalProb < 0.999)
            {
                Console.WriteLine("Warning... Probabilities do not add up to 1.");

                for (int i = 0; i < NumOfDrivers; i++)
                {
                    probabilities[i] = probabilities[i] / TotalProb;
                }
            }

            // Ask for number of sims
            Console.Write("\nEnter number of simulations (The bigger the better) : ");
            sims = Convert.ToInt32(Console.ReadLine());

            // Run sim
            for (int i = 0; i < sims; i++)
            {
                double randValue = rand.NextDouble();
                double cumulative = 0;

                for (int j = 0; j < NumOfDrivers; j++)
                {
                    cumulative += probabilities[j];

                    if (randValue <= cumulative)
                    {
                        simulatedWins[j]++;
                        break;
                    }
                }
            }

            // Display results
            Console.WriteLine("\n=== Simulation Results ===\n");

            for (int i = 0; i < NumOfDrivers; i++)
            {
                double winPercentage = (double)simulatedWins[i] / sims * 100;

                Console.WriteLine(driverNames[i]);
                Console.WriteLine("Simulated Wins: " + simulatedWins[i]);
                Console.WriteLine("Simulated Win %: " + winPercentage.ToString("F2") + "%");
                Console.WriteLine("----------------------------------");
            }



        }
    }
}
