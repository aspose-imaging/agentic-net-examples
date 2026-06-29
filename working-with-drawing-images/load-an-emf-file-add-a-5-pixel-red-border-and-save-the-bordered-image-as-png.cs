using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Set the background color to red (will fill the added border area)
                emfImage.BackgroundColor = Color.Red;

                // Define a 5‑pixel border
                int border = 5;

                // Expand the canvas to create the border
                emfImage.ResizeCanvas(new Rectangle(
                    -border,                     // left offset
                    -border,                     // top offset
                    emfImage.Width + 2 * border, // new width
                    emfImage.Height + 2 * border // new height
                ));

                // Save the result as PNG
                emfImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a vector EMF logo into a PNG thumbnail with a consistent 5‑pixel red border for web display.
 * 2. When an application must add a colored frame to legacy EMF diagrams before embedding them in a PDF report.
 * 3. When a batch‑processing tool has to standardize the canvas size of EMF icons by expanding them with a red border and saving as PNG for UI assets.
 * 4. When a Windows service generates red‑bordered PNG previews of EMF drawings for a document management system.
 * 5. When a C# program automates the preparation of EMF charts for email newsletters by adding a red border and converting them to PNG format.
 */