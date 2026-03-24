using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Custom blending settings
        Color blendColor = Color.FromArgb(255, 255, 0, 0); // Red color
        byte opacity = 128; // 50% opacity (0-255)

        // Load the source APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Create a temporary overlay image filled with the blend color
            string tempOverlayPath = Path.Combine(Path.GetTempPath(), "overlay.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempOverlayPath));

            PngOptions overlayOptions = new PngOptions
            {
                Source = new FileCreateSource(tempOverlayPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8
            };

            using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, apng.Width, apng.Height))
            {
                // Fill overlay with the selected color and opacity
                for (int y = 0; y < overlay.Height; y++)
                {
                    for (int x = 0; x < overlay.Width; x++)
                    {
                        int argb = (opacity << 24) |
                                   (blendColor.R << 16) |
                                   (blendColor.G << 8) |
                                   blendColor.B;
                        overlay.SetArgb32Pixel(x, y, argb);
                    }
                }

                // Save overlay to ensure pixel data is committed
                overlay.Save();

                // Apply blending to each frame of the APNG
                foreach (ApngFrame frame in apng.Pages)
                {
                    frame.Blend(new Point(0, 0), overlay, opacity);
                }
            }

            // Save the modified APNG to the output path
            apng.Save(outputPath, new ApngOptions());
        }
    }
}