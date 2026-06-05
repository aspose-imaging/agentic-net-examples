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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.eps";
            string outputPath = @"C:\temp\sample_grayscale.png";

            // Verify that the input file exists
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
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert vector EPS artwork into a lightweight grayscale PNG for inclusion in print‑ready PDFs that only support monochrome images.
 * 2. When an e‑commerce platform must generate low‑color‑depth product thumbnails from EPS logos to reduce bandwidth while preserving visual fidelity in grayscale.
 * 3. When a scientific reporting tool requires converting EPS plots into grayscale PNGs to meet journal submission guidelines that mandate monochrome images.
 * 4. When a mobile app processes user‑uploaded EPS files and needs to store them as grayscale PNGs to meet storage constraints and simplify rendering on low‑power devices.
 * 5. When an archival system digitizes legacy EPS documents and stores them as grayscale PNGs to ensure consistent viewing across browsers that lack native EPS support.
 */