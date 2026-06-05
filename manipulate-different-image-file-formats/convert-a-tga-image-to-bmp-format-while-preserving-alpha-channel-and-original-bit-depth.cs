using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

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
            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Preserve original bit depth and resolution
                int bitsPerPixel = tgaImage.BitsPerPixel;
                double horizontalResolution = tgaImage.HorizontalResolution;
                double verticalResolution = tgaImage.VerticalResolution;

                // Create a BMP image from the TGA image using the same parameters
                using (BmpImage bmpImage = new BmpImage(
                    tgaImage,
                    (ushort)bitsPerPixel,
                    BitmapCompression.Rgb,
                    horizontalResolution,
                    verticalResolution))
                {
                    // Save the BMP image
                    bmpImage.Save(outputPath);
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
 * 1. When a game developer needs to convert legacy TGA textures with an alpha channel to BMP for a Windows‑only rendering pipeline while preserving the original bit depth.
 * 2. When a GIS application must batch‑process satellite imagery stored as TGA files and save them as BMPs for compatibility with older mapping tools that require BMP input.
 * 3. When an e‑learning platform imports user‑uploaded TGA icons and converts them to BMP to embed in PDF documents without losing transparency information.
 * 4. When a medical imaging system receives TGA scans from a device and needs to store them as BMP files for archival while preserving the exact resolution and bits‑per‑pixel.
 * 5. When a desktop publishing workflow automates the conversion of high‑color‑depth TGA assets to BMP for use in legacy print software that cannot read TGA files.
 */