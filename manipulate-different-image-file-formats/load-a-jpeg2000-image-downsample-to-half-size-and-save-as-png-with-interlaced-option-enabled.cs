using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jp2";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG2000 image
            using (Jpeg2000Image jpeg2000Image = (Jpeg2000Image)Image.Load(inputPath))
            {
                // Calculate half size
                int newWidth = jpeg2000Image.Width / 2;
                int newHeight = jpeg2000Image.Height / 2;

                // Downsample to half size using nearest neighbour resampling
                jpeg2000Image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Configure PNG options
                PngOptions pngOptions = new PngOptions();

                // Save the result as PNG
                jpeg2000Image.Save(outputPath, pngOptions);
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
 * 1. When a web application must convert high‑resolution JPEG2000 photos to smaller, progressive PNG files for faster page loads, a developer can use this code to downsample the image by 50 % and enable PNG interlacing.
 * 2. When an archival system needs to preserve original JPEG2000 scans but provide thumbnail previews in a widely supported format, this snippet loads the JP2, halves its dimensions, and saves an interlaced PNG for quick preview rendering.
 * 3. When a mobile app requires low‑memory image assets, a developer can employ the example to read a JPEG2000 source, resize it to half size using nearest‑neighbour resampling, and output an interlaced PNG that streams smoothly on limited bandwidth.
 * 4. When a digital publishing workflow must transform large JP2 artwork into web‑ready PNG images with progressive display, the code demonstrates how to load, resize, and save the image with PNG interlacing enabled.
 * 5. When a batch‑processing script needs to automate conversion of satellite JPEG2000 imagery into smaller, interlaced PNG tiles for GIS applications, this C# example provides the necessary steps to resize and save the images efficiently.
 */