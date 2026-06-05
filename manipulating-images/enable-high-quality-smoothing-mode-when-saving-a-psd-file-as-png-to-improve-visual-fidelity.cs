using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.psd";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with high‑quality smoothing
                PngOptions pngOptions = new PngOptions();

                // Set vector rasterization options to enable anti‑aliasing (high quality smoothing)
                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PNG using the configured options
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
 * 1. When a developer needs to convert layered Photoshop PSD files to PNG for web display while preserving smooth edges and reducing jagged artifacts.
 * 2. When generating thumbnail previews of PSD artwork for a digital asset management system and wants anti‑aliased rendering for better visual fidelity.
 * 3. When exporting PSD designs to PNG for inclusion in mobile apps where high‑resolution screens require smooth vector rasterization.
 * 4. When automating batch conversion of PSD files to PNG for an e‑commerce catalog and must ensure the product images retain crisp, anti‑aliased graphics.
 * 5. When creating PNG assets from PSD logos for print‑ready PDFs and wants to maintain smooth curves during the rasterization process.
 */