using System;
using System.IO;

namespace E_Voting_C_Sharp_PF_Project
{
    class Program
    {

        public static string[,] votes = new string[100, 2];  //100 rows and 2 columns(cnic and party number)
        public static string CNIC = null;
        public static string[,] users = new string[100,2];
        static void Main(string[] args)
        {
            StartScreen();
        }

        
        public static void StartScreen()
        {
            int selected = 0;
            Console.WriteLine("\t\tWelcome to E-Voting");
            Console.WriteLine("Select the following options: ");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            selected = Convert.ToInt32(Console.ReadLine());

            if (selected == 1)
            {
                AdminOpen();
            }
            if (selected == 2)
            {
                UserOpen();
            }
        }

        public static void Line()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Console.Write("-");
                }
            }

            Console.WriteLine("\n");
        }

        public static void AdminOpen()
        {
            Console.Write("Enter CNIC: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if(username=="admin" && password == "admin")
            {
                Dashboard();
            }
            else
            {
                Console.WriteLine("Wrong username or password");
                AdminOpen();
            }
        }

        public static void UserOpen()
        {
            int selected = 0;
            Console.WriteLine("Select the following options: ");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Login");
            selected = Convert.ToInt32(Console.ReadLine());

            if (selected == 1)
            {
                SignUp();
            }
            if (selected == 2)
            {
                UserLogin();
            }
        }
    
        
        public static void Dashboard()
        {
            Line();
            Console.Write("Press 1 to view User Votes: ");
            string num = Console.ReadLine();

            if (num == "1")
            {
                ViewVotes();
            }
            else
            {
                Console.WriteLine("---------Please enter Correct Number");
                Dashboard();
            }
        }

        public static void ViewVotes()
        {
            string[] parties = { "","PTI", "PMLN", "PPP", "MQM" };
            Console.WriteLine("\tCNIC \t\t Vote");
            for (int i=0; i < votes.Length; i++)
            {
                if(votes[i, 0] != null)
                {
                    Console.WriteLine("\t" + votes[i, 0] + "\t" + parties[Convert.ToInt32(votes[i, 1])]);
                }
                else
                {
                    break;
                }
                
            }
            StartScreen();
        }

        public static void UserDashobard()
        {
            //Console.WriteLine(CNIC);
            int selected = 0;
            Console.WriteLine("Select the following options: ");
            Console.WriteLine("1. Cast Your Vote");
            Console.WriteLine("2. Logout");
            selected = Convert.ToInt32(Console.ReadLine());

            if (selected == 1)
            {
                Console.WriteLine(CastVote());
                UserDashobard();
            }
            if (selected == 1)
            {
                StartScreen();
            }
        }

        public static void SignUp()
        {
            string password = null, Cpassword=null;
            Console.Write("Enter CNIC: ");
            string cnic = (Console.ReadLine());

            do
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                Console.Write("Enter Confirm Password: ");
                Cpassword = Console.ReadLine();

                if (password == Cpassword)
                {
                    int i = 0;
                    while (users[i,0] != null)
                    {
                        i++;
                    }
                    users[i, 0] = cnic;
                    users[i, 1] = password;


                    Console.WriteLine("DONE!!!-----------------------------------------------------");
                    break;
                }
            } while (password != Cpassword);

            UserOpen();
            
        }
        public static string CastVote()
        {
            //first we'll search if user has already voted or not
            //we'll do linear searching technique
            
            bool flag = false;
            for(int i = 0; i < 100; i++)
            {
                if (votes[i,0] != null && votes[i,1]!=null)
                {
                    if (votes[i,0].CompareTo(CNIC)==0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                return "You have already voted";
            }

            string selected = null;
            Console.WriteLine("Select the One of the parties: ");
            Console.WriteLine("1. PTI");
            Console.WriteLine("2. PMLN");
            Console.WriteLine("3. PPP");
            Console.WriteLine("4. MQM");
            selected = (Console.ReadLine());

            if (Convert.ToInt32(selected) > 4)
            {
                Console.WriteLine("Out of option!! Please select one!");
                CastVote();
            }
            else
            {
                int i = 0;
                while (votes[i, 0] != null)
                {
                    i++;
                }
                votes[i, 0] = CNIC;
                votes[i, 1] = selected;
            }
            return "You have successfully voted!";

        }

        public static void UserLogin()
        {
            Console.Write("Enter CNIC: ");
            string cnic = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            for(int i=0; i < users.Length; i++)
            {
                if(users[i,0]!=null && users[i,1] != null)
                {
                    if (users[i,0].CompareTo(cnic) == 0 && users[i,1].CompareTo(password) == 0)
                    {
                        CNIC = cnic;
                        
                        UserDashobard();
                    }
                    else
                    {
                        Console.WriteLine("Wrong CNIC or password!");
                    }
                }
                
            }
        }


    }
}
