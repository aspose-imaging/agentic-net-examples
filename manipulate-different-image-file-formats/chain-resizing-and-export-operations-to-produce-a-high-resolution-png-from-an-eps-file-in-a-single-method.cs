using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\SourceImage.eps";
        string outputPath = @"C:\Images\Result\HighResImage.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image, resize it, and export to PNG in one chain
            using (Image image = Image.Load(inputPath))
            {
                // Resize to a higher resolution (example: 2000x2000) using Mitchell interpolation
                image.Resize(2000, 2000, ResizeType.Mitchell);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must convert a vector EPS logo into a high‑resolution PNG for use on a responsive website, they can load the EPS, resize it to the required pixel dimensions, and save it in one chained operation.
 * 2. When an automated build script generates printable marketing assets from EPS source files, the code can resize the artwork to print‑ready dimensions and export it directly as PNG without intermediate files.
 * 3. When a desktop application needs to preview EPS diagrams as raster images at a specific size, the developer can resize the EPS to the preview resolution and save it as PNG for fast rendering.
 * 4. When a batch‑processing tool processes a folder of EPS illustrations and creates high‑quality PNG thumbnails for a digital asset management system, this single‑method chain handles loading, scaling, and saving efficiently.
 * 5. When a C# service receives user‑uploaded EPS files and must deliver a high‑resolution PNG version for downstream image‑analysis APIs, the code resizes the vector image and exports it in the required format in one step.
 */