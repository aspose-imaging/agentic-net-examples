using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\background.png";
        string outputPath = @"C:\Images\blended_output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load background image as RasterImage
        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            // Create overlay image with same dimensions
            Source overlaySource = new FileCreateSource(outputPath, false);
            PngOptions overlayOptions = new PngOptions() { Source = overlaySource };
            using (PngImage overlay = (PngImage)Image.Create(overlayOptions, background.Width, background.Height))
            {
                // Fill overlay with solid color (e.g., semi‑transparent red)
                Aspose.Imaging.Color fillColor = Aspose.Imaging.Color.FromArgb(255, 255, 0, 0); // opaque red
                int argb = fillColor.ToArgb();
                int[] pixels = Enumerable.Repeat(argb, overlay.Width * overlay.Height).ToArray();
                overlay.SaveArgb32Pixels(new Rectangle(0, 0, overlay.Width, overlay.Height), pixels);

                // Blend overlay onto background with specified opacity (e.g., 128 out of 255)
                byte opacity = 128;
                background.Blend(new Point(0, 0), overlay, opacity);
            }

            // Save blended image
            background.Save();
        }
    }
}