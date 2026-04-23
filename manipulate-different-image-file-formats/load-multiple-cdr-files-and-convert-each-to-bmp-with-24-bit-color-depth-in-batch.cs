using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr",
                @"C:\Images\sample3.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Converted";

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output BMP path (same name, .bmp extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Ensure at least one page exists
                    if (cdrImage.Pages.Length == 0)
                    {
                        Console.Error.WriteLine($"No pages found in: {inputPath}");
                        continue;
                    }

                    // Use the first page for conversion
                    using (RasterImage page = (RasterImage)cdrImage.Pages[0])
                    {
                        // Create a 24‑bpp BMP image from the raster page
                        using (BmpImage bmpImage = new BmpImage(page, 24, BitmapCompression.Rgb, 96.0, 96.0))
                        {
                            // Save the BMP file
                            bmpImage.Save(outputPath);
                        }
                    }
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}