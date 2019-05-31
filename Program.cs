using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Comp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in the path to the first image");
            var image_1 = Console.ReadLine();
            Console.WriteLine("Enter in the path to the second image");
            var image_2 = Console.ReadLine();
            if(!file_exists(image_1) || !file_exists(image_2)) 
                Console.WriteLine("One of the files does not exist, please double check");
            else
            {
                Bitmap bitmap_1 = new Bitmap(image_1);
                Bitmap bitmap_2 = new Bitmap(image_2);

                if (!bitmap_1.Width.Equals(bitmap_2.Width))
                    Console.WriteLine("Not Equal - Width not the same.");
                if (!bitmap_1.Height.Equals(bitmap_2.Height))
                    Console.WriteLine("Not Equal - Height not the same.");
                bool mismatch = false;
                for (int i = 0; i < bitmap_1.Width; i++)
                {
                    for (int j = 0; j < bitmap_1.Height; j++)
                    {
                        if (!bitmap_1.GetPixel(i, j).Equals(bitmap_2.GetPixel(i, j)))
                            mismatch = true;
                    }
                }

                if (mismatch is true)
                    Console.WriteLine("Images are not the same");
                else
                    Console.WriteLine("Images are the same");
            }

            Console.WriteLine("Press Enter to finish...");
            Console.ReadLine();
        }

        static bool file_exists(string file)
        {
            if (File.Exists(file))
                return true;
            return false;
        }
    }
}
