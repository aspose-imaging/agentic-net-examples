using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string inputPngPath = "Input/sample.png";
        string iccProfilePath = "Input/profile.icc";
        string outputJp2Path = "Output/output.jp2";

        // Validate input PNG
        if (!File.Exists(inputPngPath))
        {
            Console.Error.WriteLine($"File not found: {inputPngPath}");
            return;
        }

        // Validate ICC profile
        if (!File.Exists(iccProfilePath))
        {
            Console.Error.WriteLine($"File not found: {iccProfilePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputJp2Path));

        // Load PNG image
        using (PngImage pngImage = (PngImage)Image.Load(inputPngPath))
        {
            // Load ICC profile stream (placeholder - actual embedding not shown)
            using (FileStream iccStream = File.OpenRead(iccProfilePath))
            {
                // Create JPEG2000 options (no direct ICC profile property available)
                Jpeg2000Options jp2Options = new Jpeg2000Options();
                // Example: set irreversible compression (optional)
                jp2Options.Irreversible = true;

                // Create JPEG2000 image with same dimensions as PNG
                using (Jpeg2000Image jp2Image = new Jpeg2000Image(pngImage.Width, pngImage.Height, jp2Options))
                {
                    // Draw PNG onto JPEG2000 canvas
                    Graphics graphics = new Graphics(jp2Image);
                    graphics.DrawImage(pngImage, 0, 0);

                    // Save JPEG2000 image
                    jp2Image.Save(outputJp2Path);
                }
            }
        }

        // Reload saved JPEG2000 image to confirm it was saved correctly
        if (!File.Exists(outputJp2Path))
        {
            Console.Error.WriteLine($"File not found: {outputJp2Path}");
            return;
        }

        using (Jpeg2000Image loadedJp2 = new Jpeg2000Image(outputJp2Path))
        {
            // Placeholder for ICC profile verification logic
            // Actual ICC profile retrieval would depend on API support
            Console.WriteLine("JPEG2000 image loaded successfully. ICC profile verification not implemented.");
        }
    }
}