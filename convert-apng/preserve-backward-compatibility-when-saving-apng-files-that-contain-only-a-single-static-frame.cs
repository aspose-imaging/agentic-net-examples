// HOW-TO: Save Single-Frame APNG While Preserving Backward Compatibility In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.apng";
            string outputPath = "Output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new ApngOptions();
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
 * 1. When a web application needs to serve an APNG that contains only one static image but must remain compatible with older browsers that do not support animated PNGs.
 * 2. When a batch conversion tool processes user‑uploaded PNGs and must re‑save single‑frame APNGs without losing the original file format.
 * 3. When generating thumbnails for a gallery and the source APNG has a single frame, ensuring the saved file can be opened by legacy image viewers.
 * 4. When migrating assets from a legacy system to a new .NET service and you need to preserve the APNG container even though the animation consists of just one frame.
 * 5. When creating a CI pipeline that validates image assets and re‑saves single‑frame APNGs to guarantee they remain valid APNG files for downstream processes.
 */
