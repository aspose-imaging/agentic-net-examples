// HOW-TO: Load EPS File and Convert to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EpsImage to access EPS‑specific properties (optional)
                EpsImage epsImage = image as EpsImage;
                if (epsImage != null)
                {
                    Console.WriteLine($"EPS Creation Date: {epsImage.CreationDate}");
                    Console.WriteLine($"Width: {epsImage.Width}, Height: {epsImage.Height}");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG using default options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to read an EPS vector logo from disk, extract its dimensions and creation date, and generate a raster PNG for web display using C#.
 * 2. When a batch processing tool must verify that an EPS file exists before converting it to a PNG thumbnail for a product catalog.
 * 3. When you want to programmatically convert legacy EPS artwork to PNG while preserving image quality without manually opening design software.
 * 4. When an automated workflow requires loading an EPS file, accessing its metadata, and saving it in a different format for downstream image analysis.
 * 5. When a .NET application must ensure the output folder exists and safely handle errors while converting EPS to PNG with Aspose.Imaging.
 */
