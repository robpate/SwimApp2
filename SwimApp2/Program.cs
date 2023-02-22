using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApp2
{
    internal class Program
    {

        //Global variables
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserve = new List<string>();

        static float fastestTime = 0f;
        static string topSwimmer = "";
        static void OneSwimmer()
        {
            Console.WriteLine("Enter the swimmer's name");

            string swimmerName = Console.ReadLine();

            Console.WriteLine($"Swimmer Name: {swimmerName}");

            int sumTotalTime = 0;

            for (int i = 0; i < 4; i++)
            {
                int minutes, seconds, totalTime;

                Random randomNumber = new Random();

                // Generate random int between 1, 4 incl
                minutes = randomNumber.Next(1, 4);

                // Generate random int between 0, 59 incl
                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer time {i + 1}: {minutes}min {seconds}s\tTotal time in seconds: {totalTime}s");

                sumTotalTime += totalTime;

                Console.WriteLine(sumTotalTime);

                Console.ReadLine();
            }

            float avgTime = (float)sumTotalTime / 4;

            if (avgTime > fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = swimmerName;

            }

            string allocatedTeam = "Reserve";

            Console.WriteLine($"Avg time: {avgTime}s");

            //Assign the swimmer to a team

            if (avgTime <= 160)
            {
                teamA.Add(swimmerName);
                allocatedTeam = "A";
            }
            else if (avgTime <= 210)
            {
                allocatedTeam = "B";
                teamB.Add(swimmerName);
            }
            else
            {
                teamReserve.Add(swimmerName);
                allocatedTeam = "Reserve D:";
            }


            Console.WriteLine(allocatedTeam);

        }

        static string CreateTeamList()
        {
            //Add Team A to team list

            string teamLists = "the teams are: \n\nTeam A\n";

            foreach (string swimmer in teamA)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\n\nwith {teamB.Count} team members\n\nTeam B\n";

            //Add Team B to team list

            foreach (string swimmer in teamB)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\n\nwith {teamB.Count} team members\n\nTeam Reserve\n";

            //Add Team Reserve to team list

            foreach (string swimmer in teamReserve)
            {
                teamLists += swimmer + "\t";
            }
            teamLists += $"\n\nwith {teamReserve.Count} team members\n\n";

            return teamLists;
        }




        static void Main(string[] args)

        {
            
            string flag = "";
            while(!flag.Equals("stop"))
            {
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add another swimmer or type 'stop' to end ");

                flag = Console.ReadLine();
            }
            Console.WriteLine(CreateTeamList());

            Console.WriteLine($"the fastest swimmer was {topSwimmer} with an average time of {fastestTime}");

            Console.ReadLine();
        }
    }
}