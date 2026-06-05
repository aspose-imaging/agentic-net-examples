using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options to match the source size
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure BMP save options with lossy DXT1 compression and reduced color depth
                var bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Dxt1,
                    BitsPerPixel = 8,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as a compressed BMP
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
 * 1. When a Windows desktop application must convert vector EMF icons into small‑size BMP thumbnails for fast UI loading, this code can rasterize the EMF and apply DXT1 compression with 8‑bit color depth.
 * 2. When a legacy reporting system only accepts BMP files but the source graphics are stored as EMF, developers can use this snippet to generate compressed BMPs that meet size constraints without manual image editing.
 * 3. When a game asset pipeline needs to embed UI elements as BMP textures while minimizing memory usage, the code provides a C# way to rasterize EMF drawings and save them with lossy DXT1 compression.
 * 4. When an automated batch job processes thousands of EMF diagrams for archival on low‑bandwidth storage, this example shows how to shrink each file by converting to an 8‑bpp BMP with built‑in compression.
 * 5. When a document conversion service must deliver BMP previews of EMF charts to mobile clients, the code enables developers to produce lightweight BMP previews directly in .NET using Aspose.Imaging.
 */