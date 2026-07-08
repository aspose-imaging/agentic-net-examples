using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.bmp";

        // Input file existence check
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
                // Prepare rasterization options for vector to raster conversion
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                };

                // Configure BMP save options with lossy size reduction
                var bmpOptions = new BmpOptions
                {
                    // Reduce color depth to 8 bits per pixel (palettized)
                    BitsPerPixel = 8,
                    // Use a close palette to preserve visual quality
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette((RasterImage)emfImage, 256),
                    // Optional: apply RLE-8 compression (if supported)
                    Compression = BitmapCompression.Rle8,
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized BMP with the configured options
                emfImage.Save(outputPath, bmpOptions);
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
 * 1. When a Windows desktop application must convert vector EMF logos into small‑size BMP icons for legacy UI components, this code can rasterize the EMF and apply 8‑bit palette plus RLE compression to meet size constraints.
 * 2. When generating printable reports that embed BMP images derived from EMF charts, developers can use this snippet to shrink the BMP file size while preserving visual fidelity for faster PDF generation.
 * 3. When a batch‑processing service needs to store thousands of EMF‑based diagrams as BMP thumbnails on a low‑capacity server, the code provides a C# way to reduce each BMP to 8‑bit color depth with a close palette.
 * 4. When migrating an old document management system that only accepts BMP files, developers can employ this example to convert incoming EMF files and apply lossy compression to stay within upload size limits.
 * 5. When creating a game asset pipeline that requires BMP textures generated from vector EMF assets, this code lets developers rasterize the vectors and compress the BMP using RLE‑8 to lower memory usage on constrained devices.
 */