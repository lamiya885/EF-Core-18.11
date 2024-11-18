using _17._11_TASK.Contexts;
using _17._11_TASK.Models;

namespace _17._11_TASK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            List<Products> products = new List<Products>();
            List<Baskets> baskets = new List<Baskets>();

            bool f = true;
            bool f1= true;
            bool f2= true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Xos gelmisiniz!");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
              Login:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Secim edin:");
                Console.WriteLine("0.EXIT");
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");
            string opertation=Console.ReadLine();

                Console.Clear();
                switch (opertation)
                { 


                  case "0":
                        f = true; 
                        break;
                    case "1":
                        Console.WriteLine("....................................................................................");
                        Console.WriteLine("Enter your name :");
                        Console.WriteLine(".................................................................................................");
                       string name= Console.ReadLine();
                        Console.WriteLine(".................................................................................................");

                        Console.WriteLine("Enter your surname :");
                        Console.WriteLine(".................................................................................................");

                        string surname = Console.ReadLine();
                        Console.WriteLine(".................................................................................................");

                        Console.WriteLine("Enter your Username :");
                        Console.WriteLine(".................................................................................................");

                        string username = Console.ReadLine();
                        Console.WriteLine(".................................................................................................");

                        Console.WriteLine("Enter your Password :");
                        Console.WriteLine(".................................................................................................");

                        string password = Console.ReadLine();
                        users.Add(new Users()
                        {
                            Name = name,
                            Surname = surname,
                            Username=username,
                            Password=password
                        });
                        using (AppDBContext context=new AppDBContext())
                        {
                            context.Users.AddRange(users);
                            context.SaveChanges();

                        }
                        Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Registration compleded successfully");
                        Console.Clear();
                        goto Login;
                           
                        break;

                        case "2":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Enter your Username :");
                        string usernameLog = Console.ReadLine();
                        Console.WriteLine("Enter your Password :");
                        string passwordLog = Console.ReadLine();

             using (AppDBContext context = new AppDBContext())
             {
         var user = context.Users.Where(x => x.Username == usernameLog && x.Password == passwordLog);

                  user.ToList();
          if (user.Any())
        {
                                do
                                {
                                    Console.ForegroundColor=ConsoleColor.DarkCyan;
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("0.EXIT");
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("1.Products");
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("2.Basket");
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("3.Log out");
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                    string operation1 =Console.ReadLine();
                     switch(operation1)



                    {
                                        case "0":
                                            f1 = true ;
                                        break;

                                        case "1":
                                            reset:
                                            Console.ForegroundColor= ConsoleColor.DarkCyan;
                                            Console.BackgroundColor=ConsoleColor.White ;
                                            Console.WriteLine("Istediyiniz mehsulun ID-ini daxil edin:");
                                            bool k= int.TryParse(Console.ReadLine(),out int IdLog);
                                            if (k=false)
                                            {
                                                Console.BackgroundColor= ConsoleColor.Red;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Beep();
                                                Console.WriteLine("make right coice");
                                                goto reset;
                                            }
                                            using (AppDBContext context1 = new AppDBContext())
                                            {
                                                var data = context1.Products.Find(IdLog);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine($"Id:{data.Id},Name:{data.Name},Price:{data.Price}");
                                             
                                            }
                                        break;
                                       case "2":
                                            Console.WriteLine("Istediyiniz mehsulun ID-ini daxil edin:");

                                            using (AppDBContext context2 =new AppDBContext())
                                            {

                                                    back:
                                                bool l = int.TryParse(Console.ReadLine(), out int IdSign);
                                                if (l = false)
                                                {
                                                    Console.Beep();
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("make right coice");
                                                    goto back;
                                                }

                                              


                                                var data1 = context2.Baskets.Find(IdSign); 

                                                


                                                  

                                                Console.WriteLine($"Id:{data1.Id},UserID:{data1.UserID},ProductID:{data1.ProductID}");
                                                if (data1 != null)
                                                {
                                                 do
                                                 {

                                                        Console.WriteLine("Do you want to remove basket?");
                                                        Console.WriteLine("1.YES");
                                                        Console.WriteLine("2.NO");
                                                        string operation2 = Console.ReadLine();
                                                  switch(operation2)
                                                  {
                                                     case "1":
                                                      context2.Baskets.Remove(data1);
                                                      break;

                                                     case"2":
                                                        f2 = true ;
                                                      break;
                                                          default:
                                                          Console.Beep();
                                                          Console.BackgroundColor=ConsoleColor.Red;
                                                          Console.ForegroundColor=ConsoleColor.White ;
                                                          Console.WriteLine("Make  the right choice");
                                                          break;
                                                  }



                                                 } while (!f2);
                                                context2.SaveChanges();
                                                }
                                            }

                                       break;

                                            case "3":
                                             f= false ;
                                            Console.Clear();
                                                break;
                                          
                                            default:
                                            Console.Beep();
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Make  the right choice");
                                            break;
                     } 

                                } while (!f1);

          }
          else
          {
                                Console.Beep();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Username or Password is incorect.Please try logging in again");
          }
                                                   
             }
                        break;

                        default:
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Make  the right choice");
                        break ;




                 }
            } while (!f);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Good bye!!!");
        }
    }
}
