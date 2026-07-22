using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output\\output_cropped.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image, crop, and save
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Define the cropping rectangle (x, y, width, height)
                Rectangle cropRect = new Rectangle(50, 50, 200, 150);
                emfImage.Crop(cropRect);
                emfImage.Save(outputPath);
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
 * 1. When a developer needs to extract a specific portion of a vector‑based EMF diagram, such as a logo or chart, they can load the EMF with Aspose.Imaging for .NET, define a Rectangle with exact coordinates, and use Crop to isolate that region.
 * 2. When generating printable reports that contain large EMF graphics, a developer can crop out only the relevant area to reduce file size and improve rendering performance.
 * 3. When integrating legacy Windows Metafile (EMF) assets into a modern web application, a developer can programmatically select a region using a Rectangle and save the cropped result for display as a smaller image.
 * 4. When automating the preparation of EMF icons for a UI toolkit, a developer can use EmfImage.Crop with precise coordinates to isolate each icon from a composite EMF file.
 * 5. When performing batch processing of scanned engineering drawings stored as EMF files, a developer can crop out individual sections, such as a specific component view, by specifying the region in C# and saving the output for further analysis.
 */