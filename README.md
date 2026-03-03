This project is a high-speed "What If" program designed 
to predict the winner of the Formula 1 WDC
Instead of just looking at the current standings, 
the simulation runs the entire remaining season 100,000 times 
in a matter of seconds.


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
