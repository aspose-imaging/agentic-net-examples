// HOW-TO: Crop Specific Region From EMF to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output\cropped.png";

            // Verify input file exists
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
                // Cast to EmfImage
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not an EMF image.");
                    return;
                }

                // Define the crop rectangle (left, top, width, height)
                Rectangle cropArea = new Rectangle(100, 50, 200, 150);

                // Perform cropping
                emfImage.Crop(cropArea);

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
 * 1. When you need to extract a logo or diagram from a large EMF vector file and save it as a PNG for web display.
 * 2. When generating thumbnails of specific sections of engineering drawings stored in EMF format for inclusion in reports.
 * 3. When automating the removal of unwanted margins from EMF charts before embedding them into a PowerPoint presentation.
 * 4. When processing batch EMF files to isolate and export particular data regions as high‑resolution PNG assets.
 * 5. When creating a custom preview of a selected area of a vector map stored as EMF for a GIS application.
 */
