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
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "output.bmp";

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
                // Configure BMP save options for 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8
                };

                // Try to obtain a raster image to generate an optimal palette
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    // Generate a close 8‑bit palette based on the raster content
                    bmpOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);
                }
                else
                {
                    // Fallback to a standard 8‑bit grayscale palette
                    bmpOptions.Palette = ColorPaletteHelper.Create8BitGrayscale(false);
                }

                // Save the image as BMP using the configured options
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
 * 1. When a developer needs to convert OpenDocument Graphics (ODG) drawings to BMP files for legacy Windows applications while keeping the file size low by using an 8‑bit palette.
 * 2. When a C# program must generate thumbnail previews of ODG diagrams for a web portal and wants to store them as compact 8‑bit BMP images.
 * 3. When an automated batch‑processing pipeline has to archive ODG assets as BMP with a reduced color depth to meet storage constraints.
 * 4. When integrating Aspose.Imaging in a document management system that requires converting user‑uploaded ODG files to BMP for compatibility with third‑party reporting tools.
 * 5. When a developer wants to ensure an ODG image is saved as a BMP with an optimal 256‑color palette to preserve visual fidelity while minimizing bandwidth for mobile devices.
 */