using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.psd";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions
                {
                    // Preserve alpha channel if present
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save to a memory stream first to inspect transparency
                using (var memoryStream = new MemoryStream())
                {
                    psdImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the generated PNG from the memory stream
                    using (PngImage pngImage = (PngImage)Image.Load(memoryStream))
                    {
                        // Verify if the PNG has an alpha channel (transparency)
                        bool hasAlpha = pngImage.HasAlpha;
                        Console.WriteLine($"PNG has alpha (transparency): {hasAlpha}");

                        // Ensure output directory exists before final save
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the final PNG to disk
                        // Reuse the same options; the image data is already in pngImage
                        pngImage.Save(outputPath, pngOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}