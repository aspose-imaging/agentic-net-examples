using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input24.bmp";
        string outputPath = @"C:\temp\output8.bmp";

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
            // Load the source BMP image (24‑bit)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access dithering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering to reduce to 8‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Prepare BMP save options for 8‑bit indexed image
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best matches the image colors
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = BitmapCompression.Rgb
                };

                // Save the dithered image as an 8‑bit BMP
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to reduce the file size of a high‑resolution 24‑bit BMP for legacy Windows applications that only support 8‑bit indexed images, they can use this code to apply Floyd‑Steinberg dithering and save an 8‑bit BMP with an optimized palette.
 * 2. When preparing graphics for embedded systems or low‑memory devices that require BMP files with a maximum of 256 colors, this snippet converts a 24‑bit source to an 8‑bit indexed image while preserving visual quality through dithering.
 * 3. When converting scanned photographs stored as 24‑bit BMPs into a format suitable for printing on monochrome or limited‑color printers, the code generates an 8‑bit BMP with a close‑match palette and Floyd‑Steinberg dithering to maintain detail.
 * 4. When migrating legacy game assets that originally used 8‑bit BMP sprites, developers can use this example to downgrade modern 24‑bit BMP artwork to the required 8‑bit indexed format with proper dithering to avoid banding.
 * 5. When automating a batch process that prepares BMP images for archival in a space‑constrained database, this code programmatically reduces each image to 8‑bit indexed color using Aspose.Imaging’s RasterImage dithering and BmpOptions.
 */