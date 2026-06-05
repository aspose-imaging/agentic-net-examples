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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.lossy.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF save options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for noticeable size reduction while preserving quality
                    MaxDiff = 80
                };

                // Save the image with lossy compression
                image.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to reduce the bandwidth of animated GIF banners for faster page loads, they can use this C# code with Aspose.Imaging to apply lossy compression and halve the file size.
 * 2. When an email marketing specialist wants to attach a smaller GIF animation to newsletters without noticeably degrading visual quality, they can run this script to generate a compressed .lossy.gif.
 * 3. When a mobile app developer must meet strict app bundle size limits, they can employ the code to shrink GIF assets by approximately 50 % before packaging the app.
 * 4. When a content management system (CMS) integrates automatic image optimization, this snippet can be called to compress user‑uploaded GIFs on the server side using Aspose.Imaging’s MaxDiff setting.
 * 5. When a game developer needs to preload animated sprites while minimizing memory usage, they can use this example to create a lossy GIF version that loads faster and consumes less RAM.
 */