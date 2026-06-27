using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(inputDirectory, "*.psd");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.AdjustContrast(30f);
                    PdfOptions pdfOptions = new PdfOptions();
                    raster.Save(outputPath, pdfOptions);
                }
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
 * 1. When a graphic design studio needs to batch‑process client PSD mockups, increase their contrast for better print quality, and archive the results as searchable PDF files using C# and Aspose.Imaging.
 * 2. When an e‑learning platform automatically converts a collection of Photoshop PSD lesson slides into high‑contrast PDF handouts for offline viewing.
 * 3. When a marketing department wants to enhance the visual impact of product PSD assets and generate PDF brochures in one automated run with .NET.
 * 4. When a digital archiving system must normalize contrast across thousands of PSD artwork files before storing them as PDF documents for long‑term preservation.
 * 5. When a web service receives uploaded PSD files, applies a 30‑point contrast boost, and returns the processed images as PDF reports via an ASP.NET API.
 */