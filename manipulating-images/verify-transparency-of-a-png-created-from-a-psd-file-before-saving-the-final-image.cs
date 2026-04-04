using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.psd";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image psdImage = Image.Load(inputPath))
        {
            // Prepare PNG options preserving alpha channel
            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save PSD to a memory stream as PNG
            using (MemoryStream ms = new MemoryStream())
            {
                psdImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream position for reading

                // Load the PNG from the memory stream
                using (PngImage pngImage = new PngImage(ms))
                {
                    // Verify transparency
                    bool hasAlpha = pngImage.HasAlpha;
                    Console.WriteLine($"PNG has alpha channel: {hasAlpha}");

                    // Save the final PNG to disk
                    pngImage.Save(outputPath);
                }
            }
        }
    }
}