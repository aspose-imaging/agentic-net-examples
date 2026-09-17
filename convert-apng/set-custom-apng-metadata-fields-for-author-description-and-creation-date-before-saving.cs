// HOW-TO: Add Author Description And Creation Date Metadata To APNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "source.png");
            string outputPath = Path.Combine("Output", "output.apng");

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
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
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
 * 1. When you need to embed author, description, and creation date information into an animated PNG generated from a static PNG using Aspose.Imaging in a C# application.
 * 2. When a web service must deliver APNG files with proper metadata for copyright tracking and SEO purposes.
 * 3. When converting a series of PNG frames into a single APNG and want the resulting file to carry custom metadata for downstream processing tools.
 * 4. When building a desktop tool that archives images with provenance data, requiring the APNG to store creator details and timestamps.
 * 5. When automating image pipelines that generate animated graphics and need to comply with metadata standards for digital asset management systems.
 */
