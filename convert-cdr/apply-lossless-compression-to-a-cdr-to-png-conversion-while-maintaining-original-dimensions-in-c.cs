using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

public class Program
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

            // Load CDR image and convert to PNG with lossless compression
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Optional: cache data for performance
                cdr.CacheData();

                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9, // Maximum lossless compression
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.White,
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

/*
 * Real-World Use Cases:
 * 1. When a graphic designer needs to archive CorelDRAW (CDR) artwork as PNG files for web publishing while keeping the original size and using lossless compression to avoid quality loss.
 * 2. When an e‑learning platform automatically converts user‑uploaded CDR illustrations to PNG thumbnails for course material without altering dimensions and with maximum PNG compression to reduce storage costs.
 * 3. When a print‑to‑digital workflow requires batch processing of CDR pages into PNG images that retain exact page width and height for accurate layout reproduction in a .NET application.
 * 4. When a document management system must store vector‑based CDR drawings as PNG assets for quick preview, ensuring the conversion uses Aspose.Imaging’s CdrRasterizationOptions to preserve background color and dimensions.
 * 5. When a mobile app backend needs to serve high‑resolution PNG versions of CDR logos on demand, employing C# code that applies lossless compression level 9 to minimize bandwidth while keeping the original image size.
 */