using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}