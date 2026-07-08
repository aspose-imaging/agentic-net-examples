using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to clean up scanned legacy BMP documents, reduce noise with a median filter, standardize them to 300 × 300 pixels, and deliver them as lightweight SVG files for web publishing.
 * 2. When an automation script must convert a large collection of BMP icons from an old Windows application into scalable SVG graphics while smoothing jagged edges and ensuring a uniform 300 × 300 size for modern UI design.
 * 3. When a GIS team wants to preprocess BMP satellite tiles by removing speckle noise, resizing them to a consistent 300 × 300 resolution, and exporting them as SVG vectors for overlay in mapping applications.
 * 4. When an e‑learning platform requires batch transformation of BMP diagrams into SVG format, applying a median filter to improve readability and resizing them to 300 × 300 pixels to fit responsive course layouts.
 * 5. When a developer builds a CI/CD pipeline that automatically sanitizes BMP assets, applies a median filter to eliminate artifacts, resizes them to 300 × 300, and converts them to SVG for inclusion in cross‑platform documentation.
 */