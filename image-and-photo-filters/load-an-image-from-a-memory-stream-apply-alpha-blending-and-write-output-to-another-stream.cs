using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string backgroundPath = @"C:\temp\background.png";
        string overlayPath = @"C:\temp\overlay.png";
        string outputPath = @"C:\temp\output.png";

        // Validate input files
        if (!File.Exists(backgroundPath))
        {
            Console.Error.WriteLine($"File not found: {backgroundPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load background image from memory stream
        using (MemoryStream bgStream = new MemoryStream(File.ReadAllBytes(backgroundPath)))
        using (RasterImage backgroundImage = (RasterImage)Image.Load(bgStream))
        // Load overlay image from memory stream
        using (MemoryStream ovStream = new MemoryStream(File.ReadAllBytes(overlayPath)))
        using (RasterImage overlayImage = (RasterImage)Image.Load(ovStream))
        // Prepare output memory stream
        using (MemoryStream outStream = new MemoryStream())
        {
            // Apply alpha blending (50% opacity)
            backgroundImage.Blend(new Point(0, 0), overlayImage, 128);

            // Save blended image to output stream as PNG
            PngOptions pngOptions = new PngOptions();
            backgroundImage.Save(outStream, pngOptions);

            // Write output stream to file
            outStream.Position = 0;
            using (FileStream fileOut = new FileStream(outputPath, FileMode.Create))
            {
                outStream.CopyTo(fileOut);
            }
        }
    }
}