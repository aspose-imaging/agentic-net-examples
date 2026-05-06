using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPathHorizontal = "output\\horizontal.bmp";
            string outputPathVertical = "output\\vertical.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathHorizontal));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathVertical));

            using (Aspose.Imaging.Image horiz = Aspose.Imaging.Image.Load(inputPath))
            {
                horiz.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);
                horiz.Save(outputPathHorizontal, new BmpOptions());
            }

            using (Aspose.Imaging.Image vert = Aspose.Imaging.Image.Load(inputPath))
            {
                vert.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipY);
                vert.Save(outputPathVertical, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}