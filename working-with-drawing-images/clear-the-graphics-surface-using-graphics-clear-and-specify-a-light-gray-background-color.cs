using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create a PNG options instance
            PngOptions pngOptions = new PngOptions();

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set the source of the options to the stream
                pngOptions.Source = new StreamSource(stream);

                // Create a new image with desired dimensions
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for the image
                    Graphics graphics = new Graphics(image);

                    // Clear the graphics surface with a light gray background
                    graphics.Clear(Aspose.Imaging.Color.LightGray);

                    // Save all changes to the image (stream is already linked)
                    image.Save();
                }
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
 * 1. When generating a placeholder PNG thumbnail for a product catalog, a developer can use Graphics.Clear with Aspose.Imaging.Color.LightGray to create a uniform light‑gray background before adding overlay text or icons.
 * 2. When programmatically creating a blank canvas for a report‑to‑PDF conversion pipeline, clearing the graphics surface to light gray ensures a consistent background for subsequently drawn charts using Aspose.Imaging in C#.
 * 3. When resetting an image buffer in a C# web service that dynamically produces PNG charts, Graphics.Clear with a light‑gray color prevents visual artifacts by providing a clean background for each rendering pass.
 * 4. When building a batch image preprocessing tool that outputs 500×500 PNG files, using Graphics.Clear to fill the canvas with light gray establishes a neutral starting point for further watermarking or annotation.
 * 5. When writing a unit test for graphics rendering code, verifying that Graphics.Clear correctly fills a PNG stream with Aspose.Imaging.Color.LightGray confirms the method’s behavior in a controlled C# environment.
 */