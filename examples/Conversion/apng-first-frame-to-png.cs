using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input_apng_path> <output_png_path>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Load(inputPath))
        {
            using (Aspose.Imaging.RasterImage firstFrame = (Aspose.Imaging.RasterImage)apng.Pages[0])
            {
                firstFrame.Save(outputPath, new PngOptions());
            }
        }
    }
}