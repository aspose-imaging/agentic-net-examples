using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"\\NetworkShare\Images\output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (network share)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set GIF save options (default options can be used)
                var gifOptions = new GifOptions();

                // Save the image as GIF to the network share path
                image.Save(outputPath, gifOptions);
            }

            Console.WriteLine("Image successfully converted and saved to network share.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically convert PNG assets to GIF format and store the results on a centralized file server for web publishing pipelines.
 * 2. When an enterprise application must generate static GIF thumbnails from user‑uploaded PNG images and save them to a network share accessed by multiple services.
 * 3. When a scheduled C# service processes a batch of product images, converts them to GIF for email marketing, and writes the files to a remote SMB share for the marketing team.
 * 4. When a Windows desktop utility must ensure that converted GIF files are placed in a shared folder so that other machines on the LAN can retrieve them without additional copying.
 * 5. When a CI/CD build step includes image format conversion using Aspose.Imaging and the output GIF must be deposited on a network share for downstream QA validation.
 */