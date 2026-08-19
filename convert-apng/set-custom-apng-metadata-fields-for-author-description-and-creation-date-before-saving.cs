// HOW-TO: Add Author Description and Creation Date Metadata to APNG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();
                    apngImage.AddFrame(sourceImage);
                    apngImage.Save();
                }
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
 * 1. When you need to embed copyright information such as the author name into an animated PNG generated from a static PNG using Aspose.Imaging in a C# application.
 * 2. When a web service creates APNG thumbnails and must include a description field for SEO or accessibility purposes.
 * 3. When an automated reporting tool generates animated charts as APNG files and wants to record the creation date in the file metadata for audit trails.
 * 4. When a game asset pipeline converts sprite sheets to APNG and needs to store author and description metadata for asset management systems.
 * 5. When a desktop utility batch‑processes images to APNG format and must preserve custom metadata so downstream applications can read the author and creation timestamp.
 */
