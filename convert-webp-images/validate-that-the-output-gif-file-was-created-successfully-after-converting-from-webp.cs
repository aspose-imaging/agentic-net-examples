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
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save it as GIF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new GifOptions());
            }

            // Validate that the GIF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"GIF file created successfully: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create GIF file: {outputPath}");
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
 * 1. When a web application needs to convert user‑uploaded WebP avatars to GIF format for compatibility with older browsers that only support GIF.
 * 2. When an automated image processing pipeline must generate GIF previews from WebP assets stored on a Windows server.
 * 3. When a desktop utility needs to batch‑convert product photos from WebP to GIF to embed them in email newsletters that require GIF images.
 * 4. When a content management system validates that a conversion step succeeded by checking the existence of the output GIF after saving with Aspose.Imaging.
 * 5. When a CI/CD build script verifies that image assets are correctly transformed from WebP to GIF before publishing a mobile app’s resource bundle.
 */