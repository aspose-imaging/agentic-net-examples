using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output_resized.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to half of the original dimensions
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight);

                // Save the resized image as BMP
                image.Save(outputPath);
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
 * 1. When a developer needs to generate a smaller BMP thumbnail from a high‑resolution BMP file for a legacy Windows desktop application, they can use this C# Aspose.Imaging code to resize the image to half its original width and height.
 * 2. When an IoT device only supports low‑resolution BMP graphics, a developer can employ this snippet to downscale the source BMP to half size before uploading it to the device.
 * 3. When a content management system must store BMP images with reduced storage cost, a developer can run this code to automatically resize each uploaded BMP to 50 % of its dimensions.
 * 4. When preparing BMP screenshots for email attachments where size limits apply, a developer can use this example to shrink the images by half while preserving the BMP format.
 * 5. When converting scanned BMP documents to a smaller version for faster preview in a web portal, a developer can apply this C# routine to resize the raster image to half its original dimensions.
 */