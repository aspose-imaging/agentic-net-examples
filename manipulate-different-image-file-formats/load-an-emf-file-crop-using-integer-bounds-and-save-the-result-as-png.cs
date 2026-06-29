using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access vector-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Define crop rectangle (example integer bounds)
                int x = 10;
                int y = 10;
                int width = 200;
                int height = 150;
                Rectangle cropRect = new Rectangle(x, y, width, height);

                // Perform cropping
                emfImage.Crop(cropRect);

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the cropped image as PNG
                emfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract a specific region from a Windows Metafile (EMF) and deliver it as a web‑friendly PNG thumbnail for a document preview page.
 * 2. When an application must convert legacy vector diagrams stored as EMF files into raster PNG assets while trimming away margins to fit a fixed‑size UI component.
 * 3. When a reporting tool generates charts in EMF format and the developer wants to crop the chart area to remove legends before embedding the result in an email as a PNG image.
 * 4. When a batch processing script has to automate the conversion of EMF icons to PNG sprites, cropping each icon to a uniform width and height for use in a mobile app.
 * 5. When a GIS system stores map overlays as EMF files and the developer needs to isolate a particular map section, crop it with integer coordinates, and save it as a PNG for printing or sharing.
 */