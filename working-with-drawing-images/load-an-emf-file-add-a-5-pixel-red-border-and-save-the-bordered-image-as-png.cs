using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output\\bordered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to MetaImage to modify the canvas
                var metaImage = (Aspose.Imaging.FileFormats.Emf.MetaImage)image;
                int border = 5;

                // Expand canvas by 5 pixels on each side
                metaImage.ResizeCanvas(new Rectangle(-border, -border,
                    metaImage.Width + border * 2, metaImage.Height + border * 2));

                // Draw a red rectangle as the border
                var graphics = EmfRecorderGraphics2D.FromEmfImage((EmfImage)image);
                int innerX = border;
                int innerY = border;
                int innerWidth = metaImage.Width - border * 2;
                int innerHeight = metaImage.Height - border * 2;
                graphics.DrawRectangle(new Pen(Color.Red, border), innerX, innerY, innerWidth, innerHeight);

                // Finalize recording and save as PNG
                using (EmfImage borderedEmf = graphics.EndRecording())
                {
                    var pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert legacy EMF vector graphics into web‑friendly PNGs while adding a visible red border for branding or visual separation.
 * 2. When an application must programmatically enlarge the canvas of an EMF file by a few pixels and draw a colored outline to meet printing margin requirements.
 * 3. When a reporting tool generates EMF charts and the developer wants to automatically embed a 5‑pixel red frame before exporting the images as PNG for email attachments.
 * 4. When a desktop utility processes batch EMF icons, adds a consistent red border for UI consistency, and saves the results as PNG thumbnails.
 * 5. When a C# service integrates Aspose.Imaging to ensure that imported EMF diagrams are highlighted with a red border and stored in PNG format for downstream analytics pipelines.
 */