using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image, resize it, and export to high‑resolution PNG
            using (Image image = Image.Load(inputPath))
            {
                // Desired high‑resolution dimensions
                int targetWidth = 2000;
                int targetHeight = 2000;

                // Resize using a high‑quality interpolation method
                image.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);

                // Save as PNG with default options
                var pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert a vector EPS logo into a high‑resolution PNG thumbnail for a web‑site’s product catalog, they can use this code to resize and export in one step.
 * 2. When an automated build pipeline must generate print‑ready PNG assets from EPS source files for marketing materials, the method provides a simple C# solution with Aspose.Imaging.
 * 3. When a desktop application requires on‑the‑fly conversion of user‑uploaded EPS diagrams into 2000×2000 PNG images for preview in a UI, this code handles loading, Lanczos resizing, and saving.
 * 4. When a batch‑processing script needs to ensure all EPS files in a folder are converted to high‑resolution PNGs with consistent dimensions before uploading to a digital asset management system, the example demonstrates the necessary steps.
 * 5. When a cloud‑based microservice must accept an EPS file via API, resize it to a specific pixel size, and return a PNG response, the code illustrates the core image‑processing workflow using Aspose.Imaging for .NET.
 */