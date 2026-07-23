using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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

        try
        {
            // Load the original GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure lossy GIF options
                var saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80,
                    // Improves visual quality by correcting the palette
                    DoPaletteCorrection = true
                };

                // Save the image with lossy compression
                image.Save(outputPath, saveOptions);
                Console.WriteLine($"Compressed GIF saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to reduce the bandwidth of animated GIFs for faster page loads, they can use this C# code with Aspose.Imaging to apply lossy compression and halve the file size.
 * 2. When an email marketing system must attach animated GIFs without exceeding attachment limits, the code can compress the GIF using the MaxDiff setting and palette correction to stay within size constraints.
 * 3. When a mobile app that displays user‑generated GIF stickers must conserve device storage, developers can run this routine to shrink each GIF by about fifty percent before saving it locally.
 * 4. When a content management platform automatically optimizes uploaded media, the code can be integrated to lossy‑compress GIFs on the server side using Aspose.Imaging’s GifOptions.
 * 5. When a social media scheduler needs to upload animated GIFs to platforms that impose strict file‑size limits, this C# snippet provides a quick way to compress the images while preserving visual quality.
 */