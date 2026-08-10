// HOW-TO: Add a 5 Pixel Red Border to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Load existing EMF records into a graphics object
                EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                // Draw a 5‑pixel red border around the image
                graphics.DrawRectangle(new Pen(Color.Red, 5), 0, 0, emfImage.Width, emfImage.Height);

                // Finalize the recording to obtain a new EMF image with the border
                using (EmfImage borderedEmf = graphics.EndRecording())
                {
                    // Save the result as PNG
                    PngOptions pngOptions = new PngOptions();
                    borderedEmf.Save(outputPath, pngOptions);
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
 * 1. When you need to highlight the edges of a vector graphic (EMF) before converting it to a raster format for web display.
 * 2. When generating printable assets where a colored border is required around the original EMF artwork and the final output must be a PNG.
 * 3. When automating a batch process that adds a consistent red frame to legacy EMF icons before embedding them in a C# application UI.
 * 4. When preparing EMF diagrams for inclusion in documentation and you want a visible border to separate them from surrounding text after saving as PNG.
 * 5. When creating thumbnails of EMF files with a decorative border to improve visual distinction in a gallery view.
 */
