using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.psd";
        string outputPath = @"C:\temp\output.psd";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Define the rectangle to draw (x, y, width, height)
                Rectangle rect = new Rectangle(50, 50, 200, 150);

                // Draw the rectangle with a black pen of width 2
                graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

                // Save the modified image as PSD
                PsdOptions psdOptions = new PsdOptions();
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add a visual guide or border to a Photoshop (PSD) file, such as marking a region of interest for designers, they can use Aspose.Imaging for .NET to draw a rectangle on the indexed canvas before saving.
 * 2. When automating the creation of printable mock‑ups, a developer can overlay a black‑bordered rectangle on a PSD template to indicate crop marks or safe‑area boundaries using C# Graphics and Pen objects.
 * 3. When building a batch‑processing tool that validates image layouts, a developer may draw a rectangle on each PSD file to highlight alignment errors before exporting the modified files.
 * 4. When generating dynamic PSD assets for a web‑based design editor, a developer can programmatically draw a rectangle to represent a selectable layer or placeholder region using Aspose.Imaging’s PsdOptions.
 * 5. When integrating watermarking or branding into existing PSD files, a developer can draw a rectangular frame around the logo area to ensure consistent placement across multiple assets.
 */