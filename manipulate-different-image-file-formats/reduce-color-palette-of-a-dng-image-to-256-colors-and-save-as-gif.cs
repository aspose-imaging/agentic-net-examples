using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.dng";
        string outputPath = @"C:\Images\Result\sample.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage (inherits from RasterImage)
                DngImage dngImage = (DngImage)image;
                RasterImage raster = (RasterImage)image;

                // Generate a 256‑color palette from the image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Dither the image to an 8‑bit palette using Floyd‑Steinberg dithering
                dngImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, palette);

                // Save the result as GIF
                dngImage.Save(outputPath, new GifOptions());
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
 * 1. When a photographer needs to generate a small‑size web preview of a high‑resolution DNG raw file, they can reduce the image to a 256‑color palette and save it as a GIF using C# and Aspose.Imaging.
 * 2. When a mobile application must display raw DNG images on devices that only support 8‑bit indexed colors, the code dithers the image and converts it to a GIF with a 256‑color palette.
 * 3. When an e‑commerce platform wants to create lightweight thumbnail animations from raw product photos while minimizing bandwidth, developers can use this snippet to palette‑reduce DNG files and output GIFs.
 * 4. When an archival system requires converting raw DNG scans into a widely supported, small‑file format for quick preview without losing visual fidelity, the code provides the necessary color quantization and GIF saving steps.
 * 5. When a game developer needs to import raw texture assets and convert them into 256‑color GIF sprites for retro‑style graphics, this C# example shows how to dither and export the images with Aspose.Imaging.
 */