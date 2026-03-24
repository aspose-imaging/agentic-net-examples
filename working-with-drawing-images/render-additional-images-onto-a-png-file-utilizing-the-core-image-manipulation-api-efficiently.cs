using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string baseImagePath = "input.png";
        string overlayImagePath1 = "overlay1.png";
        string overlayImagePath2 = "overlay2.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(baseImagePath))
        {
            Console.Error.WriteLine($"File not found: {baseImagePath}");
            return;
        }
        if (!File.Exists(overlayImagePath1))
        {
            Console.Error.WriteLine($"File not found: {overlayImagePath1}");
            return;
        }
        if (!File.Exists(overlayImagePath2))
        {
            Console.Error.WriteLine($"File not found: {overlayImagePath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load base image to determine canvas size
        using (Image baseImg = Image.Load(baseImagePath))
        {
            int canvasWidth = baseImg.Width;
            int canvasHeight = baseImg.Height;

            // Prepare PNG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Create canvas bound to the output file
            using (PngImage canvas = (PngImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Draw the base image at (0,0)
                graphics.DrawImage(baseImg, new Point(0, 0));

                // Load and draw first overlay
                using (Image overlay1 = Image.Load(overlayImagePath1))
                {
                    // Example position: top‑right corner
                    int x1 = canvasWidth - overlay1.Width;
                    int y1 = 0;
                    graphics.DrawImage(overlay1, new Point(x1, y1));
                }

                // Load and draw second overlay
                using (Image overlay2 = Image.Load(overlayImagePath2))
                {
                    // Example position: bottom‑left corner
                    int x2 = 0;
                    int y2 = canvasHeight - overlay2.Height;
                    graphics.DrawImage(overlay2, new Point(x2, y2));
                }

                // Save the bound canvas (no path needed)
                canvas.Save();
            }
        }
    }
}