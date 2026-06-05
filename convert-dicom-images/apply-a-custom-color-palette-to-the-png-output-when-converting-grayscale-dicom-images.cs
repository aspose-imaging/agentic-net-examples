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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.dcm";
        string outputPath = @"C:\Images\output.png";

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

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // If the image is a DICOM image, convert it to grayscale
                if (image is DicomImage dicomImage)
                {
                    dicomImage.Grayscale();
                }

                // Prepare PNG save options with a custom grayscale palette
                var pngOptions = new PngOptions
                {
                    // Use indexed color so the palette is applied
                    ColorType = PngColorType.IndexedColor,
                    // Optional: enable progressive encoding and maximum compression
                    Progressive = true,
                    CompressionLevel = 9,
                    // Apply a custom 8‑bit grayscale palette
                    Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Save the image as PNG with the specified options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}