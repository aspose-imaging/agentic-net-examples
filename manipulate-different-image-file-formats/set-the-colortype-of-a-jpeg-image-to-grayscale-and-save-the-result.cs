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
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\sample.grayscale.jpg";

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

            // Configure JPEG save options with Grayscale color mode
            JpegOptions saveOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Grayscale
            };

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as JPEG using the configured options
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
 * 1. When a developer needs to convert a high‑resolution BMP scan of a document into a smaller grayscale JPEG for faster web loading and reduced storage.
 * 2. When an application must generate printable black‑and‑white thumbnails from color images to meet PDF/A compliance requirements.
 * 3. When a photo‑processing service wants to strip color information from user‑uploaded pictures to create uniform grayscale assets for a gallery.
 * 4. When a batch‑processing script has to prepare medical imaging files in JPEG format with Grayscale color mode for compatibility with legacy diagnostic software.
 * 5. When a C# desktop tool must ensure that archived screenshots are saved as grayscale JPEGs to minimize file size while preserving visual detail.
 */