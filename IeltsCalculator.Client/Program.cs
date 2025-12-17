using IeltsCalculator.Aplication.Servises;

namespace IeltsCalculator.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IeltsServis service = new IeltsServis();

            Console.WriteLine("==============================================");
            Console.WriteLine("   IELTS SCORE CALCULATOR — Console Version");
            Console.WriteLine("==============================================");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n▶ MENU");
                Console.WriteLine("1. IELTS balini hisoblash");
                Console.WriteLine("2. Oldin hisoblangan natijalarni ko‘rish");
                Console.WriteLine("3. Chiqish");
                Console.Write("Tanlang: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nTalabaning to‘liq ismi: ");
                        string name = Console.ReadLine();

                        double l = service.HisobListening();
                        double r = service.HisobReading();
                        double w = service.HisobWriting();
                        double s = service.HisobSpeaking();

                        double overall = service.HisobOverall(l, r, w, s);
                        service.AddStudent(name, l, r, w, s, overall);
                        break;

                    case "2":
                        service.ShowAllStudents();
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("\nDastur yakunlandi. Omad! 👋");
                        break;

                    default:
                        Console.WriteLine("❗ Noto‘g‘ri tanlov!");
                        break;
                }
            }
        }
    }
}
