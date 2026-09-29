// HOW-TO: Resize CorelDRAW CDR to 1024x768 JPG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1024, 768, ResizeType.LanczosResample);
                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to convert a CorelDRAW design to a web‑ready JPEG with a fixed 1024×768 resolution.
 * 2. When generating thumbnail previews of CDR files for a gallery or catalog where the images must be exactly 1024×768 pixels.
 * 3. When automating batch processing of CDR assets to produce standardized JPEGs for email newsletters or social media posts.
 * 4. When integrating CorelDRAW files into a .NET application that requires JPEG images of a specific size for PDF generation or reporting.
 * 5. When optimizing storage by resizing large CDR drawings to a smaller 1024×768 JPEG before uploading to a cloud server.
 */
