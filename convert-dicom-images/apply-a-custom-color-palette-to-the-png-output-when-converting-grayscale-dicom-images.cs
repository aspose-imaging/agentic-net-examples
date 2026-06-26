using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.dcm";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for palette operations
                RasterImage raster = (RasterImage)image;

                // Create a custom 8‑bit grayscale palette
                var customPalette = ColorPaletteHelper.Create8BitGrayscale(false);

                // Configure PNG save options with indexed color and the custom palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = customPalette,
                    CompressionLevel = 9,
                    Progressive = true
                };

                // Save as PNG using the specified options
                image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application must export grayscale DICOM scans as small, web‑friendly PNG files with a specific 8‑bit grayscale palette for consistent display across browsers.
 * 2. When a radiology research tool needs to batch‑convert DICOM images to indexed‑color PNGs to reduce file size while preserving the exact grayscale mapping defined by a custom palette.
 * 3. When a hospital PACS integration requires converting DICOM images to PNG for inclusion in patient reports, ensuring the PNG uses the same grayscale tones as the original scan.
 * 4. When a diagnostic AI pipeline extracts DICOM slices and saves them as PNGs with a predefined palette so that downstream image‑processing libraries can rely on a known color index.
 * 5. When a legacy system that only supports indexed PNG images must display grayscale DICOM data, and the developer uses Aspose.Imaging to apply a custom palette during conversion.
 */