// HOW-TO: Convert EMF to Grayscale BMP with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare BMP save options with vector rasterization settings
                var bmpOptions = new BmpOptions();
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                };
                bmpOptions.VectorRasterizationOptions = vectorOptions;

                // Rasterize EMF to BMP in memory
                using (var memoryStream = new MemoryStream())
                {
                    emfImage.Save(memoryStream, bmpOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized BMP image from memory
                    using (Image bmpImage = Image.Load(memoryStream))
                    {
                        // Apply grayscale conversion if supported
                        if (bmpImage is RasterCachedMultipageImage rasterImg)
                        {
                            rasterImg.Grayscale();
                        }

                        // Save the final grayscale BMP to the output path
                        bmpImage.Save(outputPath);
                    }
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
 * 1. When a Windows application needs to display legacy vector graphics as monochrome thumbnails, you can rasterize EMF files to grayscale BMPs using Aspose.Imaging in C#.
 * 2. When preparing print‑ready assets for a black‑and‑white newspaper, converting color EMF logos to grayscale BMPs ensures consistent output without manual editing.
 * 3. When generating memory‑efficient icons for embedded systems, converting EMF drawings to grayscale BMPs reduces file size while preserving shape details.
 * 4. When automating a batch process that archives technical diagrams in a uniform format, you can load each EMF, apply a grayscale filter, and save as BMP with Aspose.Imaging.
 * 5. When integrating a document conversion service that must strip color from vector diagrams before OCR, converting EMF to grayscale BMP provides a suitable input for text recognition engines.
 */
