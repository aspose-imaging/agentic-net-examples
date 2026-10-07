// HOW-TO: Add Software Metadata to APNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.png";
        string outputPath = "Output\\output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(source);
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
 * 1. When you need to embed the library version into an APNG file so downstream tools can identify which software generated the animation.
 * 2. When converting a PNG sequence to an animated APNG and want to include a “Software” tag for compliance with image metadata standards.
 * 3. When generating APNGs on a server and must provide traceability by recording the Aspose.Imaging version in the file’s metadata.
 * 4. When creating animated graphics for a web application and need to ensure the “Software” field is set for debugging or analytics purposes.
 * 5. When automating image processing pipelines and want each output APNG to carry metadata that indicates the processing library used.
 */
