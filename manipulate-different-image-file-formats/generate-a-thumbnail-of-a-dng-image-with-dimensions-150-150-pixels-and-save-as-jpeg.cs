using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dng";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)image;

                // Resize to thumbnail dimensions 150x150
                dng.Resize(150, 150);

                // Save as JPEG with default options
                JpegOptions jpegOptions = new JpegOptions();
                dng.Save(outputPath, jpegOptions);
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
 * 1. When building a photo‑gallery web app that must display fast‑loading previews of raw camera files, a developer can use this code to create 150 × 150 JPEG thumbnails from DNG images.
 * 2. When integrating a digital asset management system that stores raw photos, the code helps generate small JPEG previews for quick browsing on mobile devices.
 * 3. When automating batch processing of raw images for an e‑commerce platform, the snippet resizes each DNG to a 150 × 150 thumbnail and saves it as a JPEG for product listings.
 * 4. When developing a desktop photo‑organizer in C# that needs to show a grid of image icons, the code converts high‑resolution DNG files into lightweight JPEG thumbnails.
 * 5. When creating a server‑side API that returns image previews for client applications, this example demonstrates how to load a DNG, resize it to 150 × 150, and output a JPEG using Aspose.Imaging for .NET.
 */