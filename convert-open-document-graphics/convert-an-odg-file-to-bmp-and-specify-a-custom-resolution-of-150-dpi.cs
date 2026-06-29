using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = odgImage.Size,
                    // Optional: set background to white
                    BackgroundColor = Color.White
                };

                // Configure BMP save options and attach rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as BMP (initial save, resolution will be adjusted later)
                odgImage.Save(outputPath, bmpOptions);
            }

            // Load the newly saved BMP to adjust its resolution
            using (Image bmpImage = Image.Load(outputPath))
            {
                var bmp = (BmpImage)bmpImage;
                // Set custom resolution to 150 DPI
                bmp.SetResolution(150.0, 150.0);
                // Overwrite the file with the updated resolution
                bmp.Save(outputPath);
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
 * 1. When a desktop publishing workflow requires converting OpenDocument Graphics (ODG) diagrams into BMP files for legacy Windows applications that only accept raster images, this code provides a straightforward C# solution with Aspose.Imaging.
 * 2. When generating printable assets from ODG drawings and needing a specific print quality of 150 DPI, developers can use this snippet to rasterize and set the resolution before sending the BMP to a printer.
 * 3. When an automated document processing pipeline must batch‑convert ODG charts to BMP thumbnails for a web gallery while ensuring consistent DPI across all images, the example shows how to handle the conversion and resolution in .NET.
 * 4. When integrating a CAD‑to‑bitmap export feature into a C# WinForms tool, this code enables developers to load ODG files, rasterize them with a white background, and save them as BMP with a custom 150 DPI setting for accurate scaling.
 * 5. When a reporting system needs to embed ODG graphics into PDF reports that only support BMP images at a defined resolution, the provided Aspose.Imaging code converts the source file and enforces the 150 DPI requirement programmatically.
 */