using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using IeltsCalculator.Infrastucture.Data;
using IletsCalculator.Domain.Models;

namespace IeltsCalculator.Aplication.Servises
{
    public class IeltsServis
    {
        public DbContext dbContext { get; set; }
        public IeltsServis()
        {
            this.dbContext = new DbContext();
        }
        private int index = 0;

        public void AddStudent(string fullName, double listening, double writing, double speaking, double reading, double overall)
        {
            if (index >= dbContext.Ieltses.Length)
            {
                Console.WriteLine("Xotira to‘ldi! Yangi talaba qo‘shib bo‘lmaydi.");
                return;
            }

            var newIelts = new Ielts
            {
                fullName = fullName,
                listening = listening,
                writing = writing,
                speaking = speaking,
                reading = reading,
                overall = overall
            };

            dbContext.Ieltses[index] = newIelts;
            index++;
        }


        public double HisobOverall(double l, double r, double w, double s)
        {
            double overall = (l + r + w + s) / 4.0;
            double Overall = Math.Round(overall * 2) / 2;

            if (Overall == 9) Console.WriteLine("Overall: 9 - Expert");
            else if (Overall == 8.5) Console.WriteLine("Overall: 8.5 - Very Good");
            else if (Overall == 8) Console.WriteLine("Overall: 8 - Very Good");
            else if (Overall == 7.5) Console.WriteLine("Overall: 7.5 - Good");
            else if (Overall == 7) Console.WriteLine("Overall: 7 - Good");
            else if (Overall == 6.5) Console.WriteLine("Overall: 6.5 - Competent");
            else if (Overall == 6) Console.WriteLine("Overall: 6 - Competent");
            else if (Overall == 5.5) Console.WriteLine("Overall: 5.5 - Modest");
            else if (Overall == 5) Console.WriteLine("Overall: 5 - Modest");
            else
            {
                Console.WriteLine($"Overall: {Overall} - Siz o'zingizni ustingizda qayta ishlashingiz kerak yana anchaaa afsus :( ");
            }

                return Overall;
        }


        public double HisobSpeaking()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Juddayam yaxshi endi Speakinga o'tamiz . Undan qancha bal oldingiz ? : ");
            double javobs = Convert.ToDouble( Console.ReadLine());
            if(javobs < 0 || javobs > 9)
            {
                Console.WriteLine("Siz xato qiymat kirityapsiz !!!!! Iltimos qaytadan urinib ko'ring : ");
                HisobSpeaking();
            }
            return javobs;
        }

        public double HisobWriting()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Endi Writing band ga o'tamiz :) Qanday bal oldingiz ?  Siz olgan balingiz  0 <= Balingiz <= 9  oraliqda bo'lishi kerak !!!! : ");

            double javobw = Convert.ToDouble(Console.ReadLine());

            if(javobw < 0 || javobw > 9)
            {
                Console.WriteLine("Siz xato qiymat kirityapsiz !!!!! Iltimos qaytadan urinib ko'ring : ");
                HisobWriting();
            }

            return javobw;
        }

        public double HisobReading()
        {
            
            Console.WriteLine("==============================================");
            Console.WriteLine("Yaxshi endi Readinga o'tamiz 40 tadan nechtasiga to'g'ri javop berdingiz ? : ");

            string javobr = Console.ReadLine();
            int javob1r = Convert.ToInt32(javobr);

            double summ2r = 0;

            if (0 <= javob1r && javob1r <= 40)
            {
                double summr = javob1r * (9.0 / 40);
                int summ1r = (int)summr;

                if ((summr - summ1r) >= 0.75)
                    summ2r = Math.Ceiling(summr);
                else if ((summr - summ1r) <= 0.25)
                    summ2r = Math.Floor(summr);
                else
                    summ2r = summ1r + 0.5;
            }
            else
            {
                Console.WriteLine("Siz xato qiymat kirityapsiz !!!!!");
                HisobReading();
            }
            


            return summ2r;
        }


        public double HisobListening()
        {
            
            Console.WriteLine("Birinchi bo'lib Listening band ni xisoblaymiz : ");
            Console.WriteLine("Siz Listeningdan 40 tadan nechtasiga javop berdingiz ?");
            string javob = Console.ReadLine();
            int javob1 = Convert.ToInt32(javob);

            double summ2l = 0;

            if (0 <= javob1 && javob1 <= 40)
            {
                double summl = javob1 * (9.0 / 40);
                int summ1l = (int)summl;

                if ((summl - summ1l) >= 0.75)
                    summ2l = Math.Ceiling(summl);
                else if ((summl - summ1l) <= 0.25)
                    summ2l = Math.Floor(summl);
                else
                    summ2l = summ1l + 0.5;
            }
            else
            {
                Console.WriteLine("Siz xato qiymat kirityapsiz !!!!!");
                HisobListening();
            }

            return summ2l;
        }

        public void IeltsProcess()
        {
            Console.WriteLine("Judda yaxshi Xurmatli mijoz! O'ylaymizki yaxshi topshirib chiqgansiz :)");
            Console.Write("Keling olgan natijangizni xisoblaymiz . Boshlaymizmi ? ha / yo'q : ");
            string user1 = Console.ReadLine();

            Console.WriteLine("=======================================================================");

            if (user1 == "ha")
            {
                Console.WriteLine("Juda ajjoyib o'ylaymizki natijangiz yuqori chiqadi :) ");
                Console.WriteLine("Qani unda kettik !!!!!! ");

                Console.WriteLine("========================================================================");

                double listening = HisobListening();
                double reading = HisobReading();
                double writing = HisobWriting();
                double speaking = HisobSpeaking();

                Console.WriteLine("====================================================");
                Console.WriteLine("Ho'sh xurmatli mijoz biz sizning Overall balingizni xisoblayapmiz .......");
                Console.Write("Xosh Natijangizni ko'rishga tayyormisiz :) ....... ");
                string natija = Console.ReadLine();

                HisobOverall(listening, reading, writing, speaking);
            }
            else
            {
                Console.WriteLine("Agar qancha ball olganingizni hisoblamoqchi bo'lsangiz men doim tayyorman");
            }
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("\n=========== SAQLANGAN IELTS NATIJALARI ===========");

            bool bor = false;

            for (int i = 0; i < dbContext.Ieltses.Length; i++)
            {
                var s = dbContext.Ieltses[i];
                if (s != null)
                {
                    bor = true;
                    Console.WriteLine($@"
                    Talaba #{i + 1}
                    Ism      : {s.fullName}
                    Listening: {s.listening}
                    Reading  : {s.reading}
                    Writing  : {s.writing}
                    Speaking : {s.speaking}
                    OVERALL  : {s.overall}
----------------------------------------------");
                }
            }

            if (!bor)
                Console.WriteLine("Hali hech qanday ma'lumot yo‘q!");
        }

    }
}
