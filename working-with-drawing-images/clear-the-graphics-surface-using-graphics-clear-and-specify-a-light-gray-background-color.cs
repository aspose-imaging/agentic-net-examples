using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a 500x500 image bound to the stream
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for the image
                    Graphics graphics = new Graphics(image);

                    // Clear the surface with a light gray background
                    graphics.Clear(Color.LightGray);

                    // Save the image (stream is already bound)
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
 * 1. When generating a placeholder PNG thumbnail for a web gallery and you need a uniform light‑gray canvas before adding dynamic content.
 * 2. When creating a printable report page as a PNG image where the background must be cleared to a neutral light gray to match corporate branding.
 * 3. When initializing a blank canvas for a diagram editor in a C# WinForms application, using Aspose.Imaging to ensure the surface starts with a consistent light‑gray background.
 * 4. When automating the production of email signature images and you want to reset the graphics surface to a light gray base before overlaying text and logos.
 * 5. When developing a batch process that generates PNG assets for a mobile app and you need to clear each 500×500 image to a light gray color to avoid artifacts from previous frames.
 */