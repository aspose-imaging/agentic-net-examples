// HOW-TO: Add Software Metadata to APNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(sourceImage);
                    apng.Save();
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
 * 1. When you need to embed the Aspose.Imaging library version into an APNG file so downstream tools can identify which version generated the animation.
 * 2. When creating animated PNGs from static PNG frames and you want to include a “Software” tag to comply with PNG metadata standards.
 * 3. When generating APNGs in a CI/CD pipeline and must record the build number or library version in the image metadata for audit trails.
 * 4. When delivering APNG assets to clients and want to provide traceability by adding a custom software identifier to the file.
 * 5. When processing large batches of PNGs into APNGs and need to programmatically set the Software metadata field to avoid manual editing.
 */
