using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure rasterization options to add a border frame
            var rasterOptions = new EpsRasterizationOptions
            {
                BorderX = 10, // horizontal border thickness in pixels
                BorderY = 10, // vertical border thickness in pixels
                // Keep original aspect ratio; page size will be derived from the EPS content
                PageWidth = 0,
                PageHeight = 0
            };

            // PNG save options using the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Load the EPS image, apply the border, and save as lossless PNG
            using (var image = Image.Load(inputPath))
            {
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
 * 1. When a developer needs to convert vector EPS artwork into a lossless PNG thumbnail with a uniform 10‑pixel border for consistent display in a web gallery.
 * 2. When an e‑commerce platform must generate product preview images from supplier EPS logos, adding a border frame before storing them as PNG files.
 * 3. When a reporting tool has to embed EPS diagrams into PDF reports by first rasterizing them to PNG with a border to maintain visual separation from surrounding text.
 * 4. When a desktop publishing application automates the preparation of print‑ready assets by converting EPS files to PNG with a defined border for preview in a WYSIWYG editor.
 * 5. When a CI/CD pipeline validates design assets by programmatically loading EPS files, applying a border, and saving them as lossless PNGs for visual regression testing.
 */