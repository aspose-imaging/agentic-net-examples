using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PSD files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.psd");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare the output PNG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image, deskew, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.NormalizeAngle(false, Color.LightGray);

                    using (var pngOptions = new PngOptions())
                    {
                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When a developer needs to automatically straighten scanned PSD artwork batches and export them as PNGs for web publishing.
 * 2. When a photo‑editing pipeline must process a folder of PSD files, correct their rotation using deskew, and generate lightweight PNG thumbnails for a gallery.
 * 3. When an e‑commerce platform requires bulk conversion of product mockups from PSD to PNG while ensuring each image is properly aligned.
 * 4. When a document management system imports PSD scans, removes skew, and stores the cleaned images as PNGs for archival and preview.
 * 5. When a C# automation script has to iterate through a directory, apply raster image normalization, and save the corrected results in PNG format for downstream processing.
 */