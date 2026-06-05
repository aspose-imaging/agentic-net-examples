using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (var cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
            {
                // Configure PNG options with vector rasterization to keep transparency
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent
                    }
                };

                // Save as PNG
                cdr.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}