// HOW-TO: Convert CMX to SVG with Vector Shapes and Text Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.cmx";
            string outputPath = "sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    // Render text as vector shapes to preserve appearance
                    TextAsShapes = true,
                    // Set rasterization options specific to CMX
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = cmxImage.Size
                    }
                };

                // Save the image as SVG
                cmxImage.Save(outputPath, saveOptions);
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
 * 1. When you need to migrate legacy CorelDRAW CMX artwork to scalable SVG for web display while keeping the original text appearance intact.
 * 2. When an automated C# batch job must convert dozens of CMX files to SVG for inclusion in a responsive UI.
 * 3. When preserving the exact vector geometry of technical drawings from CMX is required for high‑quality printing or further editing in vector editors.
 * 4. When generating SVG assets from CMX for use in mobile applications that only support SVG rendering.
 * 5. When integrating CMX‑to‑SVG conversion into a C# backend service that validates, stores, and serves vector graphics in a database.
 */
