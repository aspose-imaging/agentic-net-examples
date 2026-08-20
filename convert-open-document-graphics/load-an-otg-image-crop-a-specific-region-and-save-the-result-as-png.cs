// HOW-TO: Crop Central Region of OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OtgImage to access cropping functionality
                OtgImage otgImage = (OtgImage)image;

                // Define the cropping rectangle (central region)
                int cropX = otgImage.Width / 4;
                int cropY = otgImage.Height / 4;
                int cropWidth = otgImage.Width / 2;
                int cropHeight = otgImage.Height / 2;
                Rectangle cropArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Perform cropping
                otgImage.Crop(cropArea);

                // Save the cropped image as PNG
                otgImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to extract a specific portion of an OpenDocument graphic (OTG) for use in a web thumbnail, you can crop and convert it to PNG with Aspose.Imaging.
 * 2. When generating printable assets from a larger OTG diagram, cropping the central area and saving as PNG ensures the output matches required dimensions and format.
 * 3. When integrating legacy OTG files into a modern C# application that only supports PNG, you can programmatically crop the needed region and convert it.
 * 4. When creating a preview of a multi‑page OTG document by extracting a representative section, this code lets you produce a PNG snapshot.
 * 5. When automating batch processing of OTG files to produce uniformly sized PNG icons, cropping each image to a central rectangle standardizes the results.
 */
