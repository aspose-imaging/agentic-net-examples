using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"c:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Enable anti-aliasing for smoother edges
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Save the image (output is already bound to the file)
                image.Save();
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
 * 1. When generating a PNG thumbnail for a web gallery, a developer can use this code to create a 500×500 canvas and enable anti‑aliasing so the thumbnail’s edges appear smooth on browsers.
 * 2. When producing printable marketing flyers in C#, initializing Graphics on a newly created image and setting SmoothingMode to AntiAlias ensures vector shapes and text render with high‑quality edges before saving as PNG.
 * 3. When building a custom charting component that draws lines and curves on the fly, developers can use this snippet to create an image buffer, apply anti‑aliasing, and export the result to a file for reporting tools.
 * 4. When automating the generation of QR codes or barcodes with additional decorative graphics, the code provides a clean image surface with anti‑aliased rendering to avoid jagged borders in the final PNG.
 * 5. When developing a game asset pipeline that programmatically draws sprites or icons, initializing Graphics with SmoothingMode.AntiAlias guarantees that the rendered shapes look crisp when the PNG files are loaded into the game engine.
 */