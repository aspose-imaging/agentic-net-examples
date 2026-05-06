using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.jp2";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load JPEG2000 image (buffer size hint can be set via options if needed for saving)
            using (Jpeg2000Image image = new Jpeg2000Image(inputPath))
            {
                Console.WriteLine($"Width: {image.Width} px");
                Console.WriteLine($"Height: {image.Height} px");
                Console.WriteLine($"Horizontal Resolution: {image.HorizontalResolution} DPI");
                Console.WriteLine($"Vertical Resolution: {image.VerticalResolution} DPI");

                // Save as PNG (demonstrates usage of output path handling)
                PngOptions pngOptions = new PngOptions();
                pngOptions.BufferSizeHint = 10 * 1024 * 1024; // 10 MB buffer for saving
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}