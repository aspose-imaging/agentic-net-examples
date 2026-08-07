using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CMX image
            using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Set custom background color for transparent regions
                cmx.BackgroundColor = Aspose.Imaging.Color.White; // Change to desired color

                // Configure JPEG options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100
                };

                // Save as JPEG
                cmx.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to JPEG for web publishing while ensuring transparent areas are filled with a specific background color to prevent visual artifacts.
 * 2. When an automated image processing pipeline must batch‑process CMX drawings and output high‑quality JPEGs with a white (or any chosen) background for consistent appearance across browsers.
 * 3. When integrating a document management system that stores CMX assets, and the application must generate preview thumbnails in JPEG format with a defined background to avoid empty or black corners.
 * 4. When migrating a legacy design archive to a modern format, and the migration tool must replace CMX transparency with a solid color during conversion to JPEG to maintain brand colors.
 * 5. When building a C# desktop utility that allows users to select a CMX file and export it as a JPEG with a custom background, ensuring the resulting image meets print‑ready quality standards.
 */