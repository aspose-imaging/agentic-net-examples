// HOW-TO: Convert JPEG to Grayscale Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\sample_grayscale.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions();
                options.ColorType = JpegCompressionColorMode.Grayscale;
                image.Save(outputPath, options);
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
 * 1. When you need to generate a black‑and‑white version of a color JPEG for printing or archival purposes.
 * 2. When a web application must reduce file size by converting user‑uploaded photos to grayscale before storage.
 * 3. When a medical imaging system requires grayscale JPEGs to comply with DICOM display standards.
 * 4. When creating thumbnails for a gallery that should appear in grayscale to match a design theme.
 * 5. When preprocessing images for machine‑learning models that expect single‑channel grayscale input.
 */
