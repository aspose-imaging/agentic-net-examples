using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options to use grayscale color type
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };

                // Save the image as a grayscale PNG
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
 * 1. When a printing service needs to convert vector EPS artwork to a lightweight grayscale PNG for web preview without color data.
 * 2. When an e‑learning platform wants to generate consistent black‑and‑white thumbnails from EPS diagrams for faster loading.
 * 3. When a document management system must archive EPS files as grayscale PNGs to reduce storage while preserving visual fidelity.
 * 4. When a mobile app processes EPS logos and saves them as grayscale PNGs to meet a monochrome UI theme requirement.
 * 5. When a batch‑processing script converts EPS technical drawings to grayscale PNGs for inclusion in PDF reports that only support grayscale images.
 */