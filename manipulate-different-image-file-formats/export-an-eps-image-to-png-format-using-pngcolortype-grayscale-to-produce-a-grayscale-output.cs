using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\sample.eps";
            string outputPath = "C:\\Images\\sample_grayscale.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Set PNG options to produce a grayscale image
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert vector EPS artwork into a lightweight grayscale PNG for inclusion in a print‑ready PDF brochure.
 * 2. When an e‑commerce platform must generate low‑color‑depth product thumbnails from EPS logos to reduce bandwidth while preserving visual fidelity.
 * 3. When a document management system archives engineering diagrams by saving EPS files as grayscale PNGs to ensure consistent viewing across devices.
 * 4. When a scientific reporting tool transforms EPS plots into grayscale PNG images for embedding in LaTeX papers where color is not allowed.
 * 5. When a legacy web application requires batch processing of EPS files into grayscale PNGs using C# and Aspose.Imaging to support monochrome display screens.
 */