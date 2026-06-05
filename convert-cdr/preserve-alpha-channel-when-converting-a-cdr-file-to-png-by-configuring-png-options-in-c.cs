using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.png";

            string inputDirectory = Path.GetDirectoryName(inputPath);
            string outputDirectory = Path.GetDirectoryName(outputPath);

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
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