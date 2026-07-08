using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options for 24bpp format
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Image processing can be done here

                // Save the image to the specified output path
                image.Save();
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
 * 1. When a developer needs to generate a blank 24‑bit BMP canvas for drawing vector graphics such as logos or diagrams before saving it to disk.
 * 2. When an application must programmatically create a high‑color‑depth image to overlay text or shapes on a transparent background and then export it as a BMP file.
 * 3. When a batch‑processing tool requires a consistent 500 × 500 pixel image in 24bpp format to serve as a template for watermarking multiple input PNG files.
 * 4. When a server‑side service has to produce a rasterized preview of vector content for legacy systems that only accept 24‑bit BMP images.
 * 5. When a developer wants to ensure the output directory exists and safely write a newly created BMP image with Aspose.Imaging’s Image.Create method for further image manipulation.
 */