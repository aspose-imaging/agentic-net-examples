// HOW-TO: Crop Central 200x200 Region from WebP Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.webp";
        string outputPath = "output/output.webp";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage image = new WebPImage(inputPath))
            {
                // Desired crop size
                int cropWidth = 200;
                int cropHeight = 200;

                // Calculate top-left corner for central crop
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                // Adjust if the image is smaller than the crop size
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (cropWidth > image.Width) cropWidth = image.Width;
                if (cropHeight > image.Height) cropHeight = image.Height;

                // Perform cropping
                image.Crop(new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight));

                // Save with default options
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
 * 1. When you need to generate a thumbnail by extracting the central 200 × 200 pixels from a WebP picture in a .NET application.
 * 2. When you want to standardize profile picture dimensions by cropping the middle of user‑uploaded WebP files before storing them.
 * 3. When you are preparing WebP assets for a responsive web layout and must ensure a consistent square region for UI components.
 * 4. When you need to remove unwanted borders from a WebP image by keeping only the central area in a C# batch‑processing script.
 * 5. When you are creating a preview image for a gallery and require a centered 200 × 200 crop of each WebP file using Aspose.Imaging.
 */
