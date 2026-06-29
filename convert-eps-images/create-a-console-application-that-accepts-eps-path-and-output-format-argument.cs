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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image (fully qualified type to avoid extra using)
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Set PNG options with rasterization settings for EPS
                var options = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                // Save the image in the desired format
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
 * 1. When a developer must batch‑convert EPS artwork files to PNG thumbnails for a web gallery, this console app can read the EPS path and output a rasterized PNG using Aspose.Imaging.
 * 2. When an automated build pipeline needs to validate that a supplied EPS design exists and then generate a PNG preview for documentation, the code checks the file, creates the output folder, and saves the image.
 * 3. When a Windows service processes user‑uploaded EPS logos and stores them as PNGs for email signatures, the program’s file‑existence guard and rasterization options ensure reliable conversion.
 * 4. When a desktop utility must allow a non‑technical user to specify an EPS source and desired image format (e.g., PNG) via command‑line arguments, this C# example demonstrates the necessary loading and saving steps.
 * 5. When a CI/CD script requires a quick C# tool to transform vector EPS assets into raster PNGs for inclusion in a mobile app’s asset bundle, the code provides the end‑to‑end conversion workflow.
 */