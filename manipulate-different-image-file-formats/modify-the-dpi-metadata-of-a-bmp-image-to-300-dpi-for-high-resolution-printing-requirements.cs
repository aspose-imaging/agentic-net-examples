using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_300dpi.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access SetResolution
                BmpImage bmpImage = (BmpImage)image;

                // Set horizontal and vertical DPI to 300
                bmpImage.SetResolution(300.0, 300.0);

                // Save the modified image
                bmpImage.Save(outputPath);
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
 * 1. When preparing BMP graphics for a high‑resolution brochure, a developer can use this code to set the image DPI to 300 so the printed output matches the design specifications.
 * 2. When converting scanned engineering drawings stored as BMP files into print‑ready assets, the code updates the DPI metadata to 300 DPI to ensure accurate scaling on large‑format printers.
 * 3. When integrating a C# application with a workflow that generates BMP logos for product packaging, the developer applies this snippet to enforce a 300 DPI resolution required by the packaging vendor.
 * 4. When migrating legacy BMP assets from a low‑resolution archive to a modern publishing system, the code is used to adjust the DPI to 300, enabling crisp reproduction on high‑quality print media.
 * 5. When building an automated batch‑processing tool that prepares BMP images for laser‑cutting or CNC machining, the developer employs this example to set both horizontal and vertical DPI to 300, guaranteeing precise dimensional output.
 */