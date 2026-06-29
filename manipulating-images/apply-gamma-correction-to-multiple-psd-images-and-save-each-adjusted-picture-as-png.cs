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
            // Hardcoded input and output directories
            string inputFolder = "C:\\InputPsds";
            string outputFolder = "C:\\OutputPngs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all PSD files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.psd");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image, apply gamma correction, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.AdjustGamma(2.2f); // Example gamma value
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When a graphic design studio needs to batch‑convert a collection of Photoshop PSD files to web‑ready PNGs while applying a gamma correction of 2.2 to ensure consistent brightness across browsers.
 * 2. When an e‑commerce platform must automatically generate product thumbnails from layered PSD assets, adjusting gamma to match the site’s color profile before saving them as PNG images.
 * 3. When a digital archiving system processes incoming PSD artwork, applying gamma correction to preserve visual fidelity and storing the results in PNG format for long‑term, lossless storage.
 * 4. When a marketing automation tool needs to prepare a set of PSD‑based promotional banners for email campaigns, correcting gamma and exporting each as a PNG to reduce file size and improve load times.
 * 5. When a game development pipeline converts PSD sprite sheets to PNG textures, using Aspose.Imaging in C# to batch adjust gamma for consistent in‑game lighting and then save the textures for the engine.
 */