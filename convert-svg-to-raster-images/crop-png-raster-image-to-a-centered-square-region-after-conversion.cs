using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_cropped.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine the size of the centered square
                int side = Math.Min(image.Width, image.Height);
                int left = (image.Width - side) / 2;
                int top = (image.Height - side) / 2;

                // Define the cropping rectangle
                Rectangle cropArea = new Rectangle(left, top, side, side);

                // Crop the image to the centered square
                image.Crop(cropArea);

                // Save the cropped image as PNG
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
 * 1. When a web application needs to generate uniformly sized avatar thumbnails from user‑uploaded PNG photos, a developer can use this C# code to crop each image to a centered square before resizing.
 * 2. When an e‑commerce platform must prepare product images for a mobile carousel that requires square PNG icons, the code can automatically trim the larger dimension and keep the central area.
 * 3. When a desktop utility processes scanned documents saved as PNG and needs to extract the central portion for OCR, the developer can employ this cropping routine to isolate the region of interest.
 * 4. When a game developer wants to convert arbitrary PNG textures into square sprites for consistent tile mapping, this snippet provides a quick C# solution to center‑crop the images.
 * 5. When an automated batch job prepares profile pictures for a social network and must ensure all PNG files are square without distortion, the code can be integrated to perform the centered crop before saving.
 */