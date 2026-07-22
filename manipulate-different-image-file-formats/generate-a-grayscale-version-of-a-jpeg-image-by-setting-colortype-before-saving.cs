using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_grayscale.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with grayscale color mode
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: set other typical options
                    BitsPerChannel = 8,
                    Quality = 100,
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Save the image as grayscale JPEG
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
 * 1. When a developer needs to convert color JPEG photos to grayscale for printing or archival purposes while preserving JPEG compression settings.
 * 2. When building a web service that receives user‑uploaded color images and must store them as smaller, grayscale JPEGs to reduce bandwidth.
 * 3. When generating thumbnails for a medical imaging application where grayscale representation is required for consistency with DICOM standards.
 * 4. When creating batch processing scripts that automatically convert product catalog images to grayscale to meet a brand’s visual guidelines.
 * 5. When implementing a C# desktop utility that prepares images for OCR engines that perform better on single‑channel (grayscale) JPEG files.
 */