using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with Grayscale color type
                var saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: use an 8‑bit grayscale palette to reduce size
                    Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Save the image as a grayscale JPEG
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
 * 1. When a web application needs to generate lightweight thumbnail previews for product photos by converting color JPEGs to 8‑bit grayscale to reduce bandwidth.
 * 2. When a medical imaging system must store scanned X‑ray images as grayscale JPEGs to comply with DICOM‑like requirements while using C# and Aspose.Imaging.
 * 3. When an archival tool processes legacy color photographs and saves them as grayscale JPEGs to preserve visual detail while minimizing file size.
 * 4. When a batch‑processing script converts color scanned documents into grayscale JPEGs for OCR preprocessing in a .NET workflow.
 * 5. When a mobile app backend generates grayscale JPEG avatars from user‑uploaded color images to maintain a consistent visual style across the platform.
 */