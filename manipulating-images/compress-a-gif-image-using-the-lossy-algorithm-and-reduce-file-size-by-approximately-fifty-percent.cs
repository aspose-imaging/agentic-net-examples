using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80,
                    // Optional: enable palette correction for better quality
                    DoPaletteCorrection = true
                };

                // Save the image with lossy compression
                image.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Lossy GIF saved successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to reduce the bandwidth of animated GIFs for faster page loads, they can use this C# code with Aspose.Imaging to apply lossy compression and halve the file size.
 * 2. When an e‑commerce platform wants to store product animation previews in a limited database space, the code can compress GIFs using the MaxDiff setting to achieve approximately 50 % size reduction.
 * 3. When a mobile app generates user‑uploaded GIF stickers and must stay under a size quota, developers can call this routine to perform lossy GIF compression in .NET before sending the file to the server.
 * 4. When a digital marketing agency automates the preparation of email campaign assets, they can use the sample to shrink large GIF banners while preserving visual quality with palette correction.
 * 5. When a content management system needs to batch‑process legacy GIF files for archival, the code provides a straightforward C# solution to compress each image using Aspose.Imaging’s GifOptions.
 */