// HOW-TO: Save Single-Frame PNG As APNG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the static image and save it as an APNG with default options
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions());
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
 * 1. When you need to convert a regular PNG icon into an APNG file while keeping compatibility with viewers that only support single‑frame APNGs.
 * 2. When a batch process must generate APNG assets from existing PNG resources without adding animation data.
 * 3. When an application exports user‑uploaded PNGs as APNGs to meet a platform’s file‑type requirement while preserving the original static appearance.
 * 4. When you want to ensure that a generated APNG containing only one frame can be opened by older browsers that expect a static image.
 * 5. When automating image pipelines that require saving images using Aspose.Imaging’s ApngOptions to maintain consistent metadata across PNG and APNG formats.
 */
