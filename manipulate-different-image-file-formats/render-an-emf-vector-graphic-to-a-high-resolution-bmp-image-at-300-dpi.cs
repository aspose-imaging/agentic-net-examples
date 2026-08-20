// HOW-TO: Render EMF to High Resolution BMP at 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with 300 DPI resolution
                BmpOptions bmpOptions = new BmpOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Set vector rasterization options to control rendering
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };
                bmpOptions.VectorRasterizationOptions = vectorOptions;

                // Save the rendered bitmap
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert a Windows Metafile (EMF) into a printable BMP file with 300 dpi resolution for high‑quality reports.
 * 2. When generating thumbnails or preview images of vector diagrams for a desktop application that only supports bitmap formats.
 * 3. When preparing EMF graphics for archival storage in a lossless BMP format while preserving exact dimensions and DPI.
 * 4. When integrating Aspose.Imaging into a C# service that rasterizes vector logos into high‑resolution bitmaps for branding on marketing materials.
 * 5. When automating batch processing of EMF assets to BMP for compatibility with legacy systems that require fixed‑resolution bitmap inputs.
 */
