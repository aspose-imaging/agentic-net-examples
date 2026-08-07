using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to MetaImage to access canvas operations
                var metaImage = (MetaImage)image;

                // Set the background color that will fill the added border area
                metaImage.BackgroundColor = Color.Red;

                // Define border thickness (5 pixels)
                int border = 5;

                // Expand the canvas to create a uniform border around the original image
                metaImage.ResizeCanvas(new Rectangle(
                    -border,                     // left offset
                    -border,                     // top offset
                    metaImage.Width + border * 2, // new width
                    metaImage.Height + border * 2 // new height
                ));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the result as PNG
                metaImage.Save(outputPath, new PngOptions());
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
 * 1. When a Windows desktop application needs to convert vector‑based EMF icons into PNG thumbnails with a consistent 5‑pixel red outline for UI branding.
 * 2. When a reporting tool generates charts as EMF files and must add a red border before embedding them in PDFs or web pages as PNG images.
 * 3. When a batch‑processing script has to prepare EMF logos for an e‑commerce site, adding a 5‑pixel red frame to meet visual guidelines and saving them as PNG for faster loading.
 * 4. When a legacy CAD system exports drawings in EMF format and a developer wants to highlight the drawing edges with a red border before displaying the result in a WPF viewer as PNG.
 * 5. When an automated email service attaches product diagrams originally stored as EMF, and the developer needs to add a red border for emphasis and convert them to PNG to ensure compatibility with all email clients.
 */