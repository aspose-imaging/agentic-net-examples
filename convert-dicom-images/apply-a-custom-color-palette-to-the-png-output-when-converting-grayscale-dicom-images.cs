// HOW-TO: Convert Grayscale DICOM to PNG with Custom Palette in C# (Aspose.Imaging for .NET)
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
                // Optionally ensure the image is a DICOM image
                // var dicomImage = image as DicomImage;
                // if (dicomImage != null) { /* additional processing if needed */ }

                // Prepare PNG options with indexed color and a custom grayscale palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                    CompressionLevel = 9,
                    Progressive = true
                };

                // Save the image as PNG using the custom palette
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
 * 1. When a medical imaging application needs to export DICOM scans as lightweight PNG files while preserving the original grayscale tones using a specific palette.
 * 2. When a radiology workflow requires batch conversion of DICOM images to PNG for web viewing, and the developer wants to control compression and progressive rendering.
 * 3. When integrating Aspose.Imaging into a C# service that generates thumbnail previews of DICOM studies, and a custom 8‑bit grayscale palette is needed for consistent color mapping.
 * 4. When a hospital information system must archive diagnostic images in PNG format with indexed colors to reduce storage size without losing diagnostic detail.
 * 5. When a research project processes DICOM datasets and needs to convert them to PNG for machine‑learning pipelines, ensuring the output uses a known grayscale palette for reproducible results.
 */
