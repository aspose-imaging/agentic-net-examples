using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output\cropped.png";

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
                // Cast to EmfImage to access EMF-specific members
                EmfImage emfImage = (EmfImage)image;

                // Define the cropping rectangle (left, top, width, height)
                // Adjust these values as needed for the desired region
                var cropArea = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

                // Perform the crop operation
                emfImage.Crop(cropArea);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the cropped image as PNG
                emfImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
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
 * 1. When a developer needs to extract a specific portion of a vector‑based EMF diagram (such as a logo or chart) and save it as a raster PNG for web display, they can use EmfImage.Crop with a rectangle defined by exact coordinates.
 * 2. When generating printable PDFs that require only a selected area of an existing EMF illustration, the code can crop the region and convert it to PNG before embedding.
 * 3. When automating the creation of thumbnails for a large collection of EMF files, a developer can define a cropping rectangle to focus on the most important part of each image and output consistent PNG thumbnails.
 * 4. When integrating legacy Windows Metafile graphics into a modern C# application that only supports raster formats, cropping the needed region from the EMF and saving it as PNG ensures compatibility.
 * 5. When building a reporting tool that extracts a specific chart area from an EMF chart file to include in a dashboard, the code provides precise region selection via a rectangle and outputs a PNG for the UI.
 */