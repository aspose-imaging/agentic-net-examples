using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Cache data to avoid repeated loading
                cdr.CacheData();

                // Configure PNG options with vector rasterization to preserve transparency
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                        // No background color set to keep transparency
                    }
                };

                // Save the CDR as PNG
                cdr.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}