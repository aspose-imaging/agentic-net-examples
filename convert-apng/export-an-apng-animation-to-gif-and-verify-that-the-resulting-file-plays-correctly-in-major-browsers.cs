// HOW-TO: Convert APNG Animation to GIF and Test Browser Compatibility in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output/output.gif";

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

            // Load the APNG animation
            using (Image image = Image.Load(inputPath))
            {
                // Save as GIF animation
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }

            // The resulting GIF can be opened in major browsers to verify playback.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display an animated PNG on browsers that only support GIF, you can convert the APNG to a GIF using Aspose.Imaging in C#.
 * 2. When preparing marketing assets for email newsletters that require GIF format, you can transform APNG animations to GIFs programmatically.
 * 3. When migrating legacy web content that uses APNG to a modern site with limited GIF support, the code automates the conversion and ensures the animation plays correctly.
 * 4. When building an automated pipeline that validates image compatibility across Chrome, Firefox, and Safari, you can generate a GIF from an APNG and open it in each browser to confirm playback.
 * 5. When creating a desktop utility that batch‑processes user‑uploaded APNG files into GIFs for social media sharing, this snippet shows the core conversion and directory handling logic.
 */
