using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.eps";
            string outputPath = @"C:\Temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Calculate the new height to maintain aspect ratio for a width of 2000 pixels
                int newWidth = 2000;
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                // Resize the image using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a vector EPS logo to a high‑resolution PNG thumbnail of exactly 2000 px width for a web storefront while preserving the original aspect ratio.
 * 2. When an automated build pipeline must generate printable PNG assets from EPS artwork, resizing them to a fixed width to meet a publisher’s layout specifications.
 * 3. When a desktop application imports user‑supplied EPS diagrams and must display them as raster PNG previews at a consistent width for faster UI rendering.
 * 4. When a batch‑processing script has to downscale large EPS files to a manageable size before uploading them to a cloud storage service that only accepts PNG images.
 * 5. When a reporting tool needs to embed EPS charts into PDF reports by first converting them to 2000‑pixel‑wide PNG images to ensure consistent visual quality across devices.
 */