using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output\sample.jpg";

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
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size // preserve aspect ratio
                };

                // Configure JPEG save options with desired quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90, // quality between 1 and 100
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) illustration to a JPEG thumbnail for web preview while preserving the original aspect ratio and setting a specific compression quality.
 * 2. When an application must batch‑process ODG files from a folder and generate high‑quality JPEG assets for inclusion in a product catalog or marketing brochure.
 * 3. When a C# service receives user‑uploaded ODG diagrams and must store them as JPEG images with a white background to ensure consistent rendering across browsers.
 * 4. When a document management system requires on‑the‑fly rasterization of vector ODG pages into JPEG files with configurable quality for faster download and preview.
 * 5. When a developer integrates Aspose.Imaging into a Windows desktop tool to export ODG drawings as JPEGs with custom rasterization options such as background color and page size.
 */