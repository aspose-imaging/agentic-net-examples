using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/sample.png";
            string outputPath = "output/sample_grayscale.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputPath))
            {
                // Optional processing: convert to grayscale if it's a PNG image
                if (image is PngImage png)
                {
                    png.Grayscale();
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a web application needs to generate a grayscale thumbnail from a template PNG for user profile pictures.
 * 2. When an e‑commerce platform wants to apply a consistent grayscale watermark to product PNG assets before publishing.
 * 3. When a desktop utility processes batch PNG icons from a templates folder to create a monochrome theme for a UI skin.
 * 4. When a reporting tool converts PNG charts stored in a templates directory to grayscale for printing in black‑and‑white reports.
 * 5. When a mobile app pre‑processes PNG game sprites from a templates folder into grayscale to reduce visual clutter in a night‑mode mode.
 */