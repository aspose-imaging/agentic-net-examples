using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string targetImagePath = @"C:\Images\target.png";
        string[] overlayImagePaths = new string[]
        {
            @"C:\Images\overlay1.png",
            @"C:\Images\overlay2.jpg"
        };
        string outputImagePath = @"C:\Images\result.png";

        // Verify target image exists
        if (!File.Exists(targetImagePath))
        {
            Console.Error.WriteLine($"File not found: {targetImagePath}");
            return;
        }

        // Verify each overlay image exists
        foreach (var overlayPath in overlayImagePaths)
        {
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

        // Load the target image
        using (Image targetImage = Image.Load(targetImagePath))
        {
            // Create a Graphics object for drawing
            using (Graphics graphics = new Graphics(targetImage))
            {
                // Draw each overlay image onto the target
                foreach (var overlayPath in overlayImagePaths)
                {
                    using (Image overlayImage = Image.Load(overlayPath))
                    {
                        // Draw at (0,0) preserving original size
                        graphics.DrawImage(overlayImage, 0, 0);
                    }
                }
            }

            // Save the resulting image (format inferred from file extension)
            targetImage.Save(outputImagePath);
        }
    }
}