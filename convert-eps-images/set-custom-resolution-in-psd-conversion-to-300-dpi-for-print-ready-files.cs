using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output_300dpi.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options with 300 DPI resolution
                PsdOptions psdOptions = new PsdOptions
                {
                    // Set horizontal and vertical resolution to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as PSD with the specified options
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert a BMP scan of a photograph into a PSD file with a 300 DPI resolution so the file is ready for high‑quality print production.
 * 2. When an e‑commerce platform must generate print‑ready product mockups from user‑uploaded images by saving them as PSD with a fixed 300 DPI resolution.
 * 3. When a digital asset management system automates the creation of PSD master files from legacy bitmap assets, ensuring the output meets the 300 DPI requirement for publishing.
 * 4. When a desktop publishing workflow requires batch processing of BMP files into PSD format with a specific resolution setting to maintain consistent layout dimensions across pages.
 * 5. When a graphic design tool integrates Aspose.Imaging to allow users to export their raster drawings as PSD files at 300 DPI for seamless hand‑off to professional designers.
 */