// HOW-TO: Increase TGA Image DPI to 300 and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Change DPI from 72 to 300
                tgaImage.HorizontalResolution = 300;
                tgaImage.VerticalResolution = 300;

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                tgaImage.Save(outputPath, tiffOptions);
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
 * 1. When a game developer needs to export high‑resolution textures from TGA files for print‑ready PDFs, they can raise the DPI to 300 and save as TIFF.
 * 2. When a scientific imaging pipeline receives TGA scans at screen resolution and must provide 300 dpi TIFFs for journal submission, this code automates the conversion.
 * 3. When a legacy asset library contains 72 dpi TGA logos that must meet corporate branding guidelines requiring 300 dpi TIFFs, the snippet updates the resolution and format in one step.
 * 4. When an e‑commerce platform processes product images stored as TGA and needs TIFF files with printer‑quality DPI for catalog printing, the code performs the necessary transformation.
 * 5. When an archival system migrates old TGA artwork to a lossless TIFF format while preserving a higher DPI for future scaling, this example shows how to adjust the resolution before saving.
 */
