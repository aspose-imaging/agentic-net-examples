using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Rotate the image by 45 degrees
                epsImage.Rotate(45f);

                // Save the rotated image as JPEG
                var jpegOptions = new JpegOptions();
                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert a vector EPS logo into a raster JPEG thumbnail while rotating it 45 degrees for a web gallery.
 * 2. When an automated build script must generate rotated preview images from EPS artwork for a print‑to‑digital workflow using C# and Aspose.Imaging.
 * 3. When a desktop application has to display a rotated version of a technical diagram stored as EPS by converting it to JPEG for faster rendering.
 * 4. When a batch processing tool processes incoming EPS files from designers, applies a 45‑degree rotation to align them, and saves them as JPEGs for email attachments.
 * 5. When a content management system imports EPS illustrations, rotates them to match layout requirements, and stores them as JPEGs for browser compatibility.
 */