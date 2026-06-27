using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Watermark;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Attempt background removal for vector images
                if (image is VectorImage vectorImg)
                {
                    // Simple removal without custom settings
                    vectorImg.RemoveBackground();

                    // Save as PNG
                    vectorImg.Save(outputPath, new PngOptions());
                }
                // For raster images, fallback to saving unchanged (or implement watermark removal if needed)
                else if (image is RasterImage rasterImg)
                {
                    // Example placeholder: no mask applied, just save original
                    rasterImg.Save(outputPath, new PngOptions());
                }
                else
                {
                    // Generic save for other image types
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
 * 1. When a developer needs a command‑line utility that accepts a vector logo file (e.g., SVG or EPS), removes its background using Aspose.Imaging’s RemoveBackground method, and saves the result as a transparent PNG for web publishing.
 * 2. When an e‑commerce platform must batch‑process thousands of product illustrations, automatically stripping backgrounds from vector images and outputting PNGs to a designated folder via a C# console app.
 * 3. When a mobile‑first application generates user‑drawn stickers, the tool can be invoked to convert the vector artwork to a PNG with a cleared background, ready for overlay on photos.
 * 4. When a CI/CD pipeline includes a step that validates and converts design assets, the command‑line program can select the appropriate background removal mode and store the PNGs in the build output directory.
 * 5. When a document‑management workflow extracts raster images from scanned PDFs, the utility can fall back to saving the original raster image as a PNG in the target location while preserving image quality.
 */