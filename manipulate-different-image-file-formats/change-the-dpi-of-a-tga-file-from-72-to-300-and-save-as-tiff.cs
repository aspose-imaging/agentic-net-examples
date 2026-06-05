using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tga";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Tga.TgaImage image = (Aspose.Imaging.FileFormats.Tga.TgaImage)Image.Load(inputPath))
            {
                // Set DPI to 300
                image.HorizontalResolution = 300;
                image.VerticalResolution = 300;

                // Save as TIFF with default options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a game developer needs to convert legacy TGA textures with low 72 DPI into high‑resolution 300 DPI TIFF files for print‑ready asset pipelines.
 * 2. When an e‑learning platform must upscale scanned TGA diagrams to 300 DPI TIFFs so that they meet publishing standards for textbooks.
 * 3. When a GIS analyst receives TGA satellite overlays at screen resolution and must re‑tag them to 300 DPI TIFFs before importing into mapping software that requires physical measurement accuracy.
 * 4. When a medical imaging system exports TGA scans from legacy equipment and a developer must adjust the DPI to 300 and store them as TIFF for compliance with DICOM archival guidelines.
 * 5. When a digital archiving service processes user‑uploaded TGA artwork and needs to standardize the resolution to 300 DPI TIFFs for consistent printing and long‑term storage.
 */