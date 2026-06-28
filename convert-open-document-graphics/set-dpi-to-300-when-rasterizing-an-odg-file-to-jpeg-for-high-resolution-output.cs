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
            // Input and output file paths (relative)
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with 300 DPI
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    }
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer uses Aspose.Imaging for .NET to create 300 DPI JPEG thumbnails from ODG files for high‑resolution print catalogs.
 * 2. When an e‑commerce application must convert user‑uploaded ODG logos to 300 DPI JPEG images using C# and Aspose.Imaging before generating product labels.
 * 3. When a document management system needs to rasterize vector ODG diagrams into 300 DPI JPEGs for embedding in PDFs via Aspose.Imaging.
 * 4. When a reporting service has to export ODG charts as high‑quality 300 DPI JPEGs for PowerPoint slides using C# code.
 * 5. When a web API provides on‑the‑fly conversion of ODG files to 300 DPI JPEGs for high‑resolution web galleries with Aspose.Imaging.
 */