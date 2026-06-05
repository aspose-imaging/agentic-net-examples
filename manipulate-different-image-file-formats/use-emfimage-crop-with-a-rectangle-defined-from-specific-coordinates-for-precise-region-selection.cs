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
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_cropped.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Define the cropping rectangle (left, top, width, height)
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

                // Perform the crop
                emfImage.Crop(cropArea);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the cropped image as PNG
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
 * 1. When a developer needs to extract a specific portion of a vector‑based EMF diagram—such as a logo or chart area—and save it as a raster PNG for web display, they can use EmfImage.Crop with a rectangle defined by exact coordinates.
 * 2. When generating thumbnails of selected regions from large EMF technical drawings, the code lets you crop the required area and output a lightweight PNG file for quick preview.
 * 3. When automating the preparation of printable assets, a developer can isolate a defined rectangle of an EMF illustration (e.g., a badge or signature) and convert it to PNG to embed in PDF reports.
 * 4. When cleaning up scanned EMF files that contain unwanted margins, the Crop method with precise coordinates removes excess space before the image is saved in a lossless PNG format.
 * 5. When integrating EMF graphics into a C# desktop application that only supports raster images, the code enables you to select a region of interest and convert it to a PNG that can be displayed in standard UI controls.
 */