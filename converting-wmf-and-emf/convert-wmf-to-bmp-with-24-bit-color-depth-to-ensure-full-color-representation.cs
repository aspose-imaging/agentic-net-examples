// HOW-TO: Convert WMF File to 24‑Bit BMP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for WMF rendering
                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure BMP save options with 24‑bit color depth
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as BMP
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
 * 1. When you need to display legacy WMF vector graphics in a Windows application that only supports bitmap images, you can rasterize them to a 24‑bit BMP for full‑color fidelity.
 * 2. When preparing print‑ready assets, converting WMF logos to BMP ensures the image retains its colors and can be imported into publishing software that requires bitmap formats.
 * 3. When migrating a document archive from vector to raster formats, this code lets you batch‑convert WMF files to BMP while preserving true color depth.
 * 4. When generating thumbnails for a web gallery that stores images as BMP, you can first convert WMF icons to 24‑bit BMP to maintain visual quality.
 * 5. When integrating third‑party WMF graphics into a C# reporting tool that only accepts BMP, the conversion guarantees accurate color representation without loss.
 */
