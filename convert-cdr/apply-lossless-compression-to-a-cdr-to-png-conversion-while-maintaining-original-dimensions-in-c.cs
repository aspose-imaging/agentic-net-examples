using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                CompressionLevel = 9
            };

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };

                cdr.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}