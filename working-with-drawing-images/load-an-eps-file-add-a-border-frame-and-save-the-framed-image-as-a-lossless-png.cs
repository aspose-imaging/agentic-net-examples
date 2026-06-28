using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output/framed.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Configure PNG save options with rasterization settings to add a border
                var pngOptions = new PngOptions();
                var rasterOptions = new EpsRasterizationOptions
                {
                    BorderX = 10, // horizontal border thickness
                    BorderY = 10, // vertical border thickness
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the framed image as lossless PNG
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
 * 1. When a print‑shop application must convert vector EPS artwork into a web‑ready lossless PNG with a uniform 10‑pixel border for consistent thumbnail display.
 * 2. When an e‑commerce platform needs to generate product preview images from supplier EPS files, adding a safe margin around the graphic before storing them as PNGs for fast loading.
 * 3. When a digital asset management system automates the ingestion of EPS logos, applying a border frame to meet branding guidelines and saving the result as a lossless PNG for archival.
 * 4. When a desktop publishing tool offers users the option to export their EPS designs with a decorative border, using C# and Aspose.Imaging to rasterize and save the output as a high‑quality PNG.
 * 5. When a reporting service creates printable charts in EPS format and must embed them in PDF reports as PNG images with a consistent border to ensure alignment across different viewers.
 */