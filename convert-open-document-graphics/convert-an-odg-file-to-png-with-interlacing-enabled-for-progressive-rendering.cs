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
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG saving options with interlacing (progressive)
                PngOptions pngOptions = new PngOptions
                {
                    Progressive = true
                };

                // Save the image as PNG with the specified options
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to display OpenDocument graphics on a website and wants faster progressive loading, they can convert ODG to interlaced PNG using C# and Aspose.Imaging.
 * 2. When an e‑learning platform stores diagram assets as ODG files but requires PNG thumbnails that load gradually for better user experience, this code provides the conversion.
 * 3. When a mobile app downloads large ODG illustrations and must show a preview while the full image loads, the interlaced PNG output enables progressive rendering.
 * 4. When an automated build pipeline generates documentation PDFs and needs to embed ODG diagrams as web‑friendly PNGs with progressive loading for faster page rendering, the code can be used.
 * 5. When a content management system migrates legacy ODG artwork to a modern image format and wants to improve page load times by using interlaced PNGs, this snippet performs the conversion.
 */