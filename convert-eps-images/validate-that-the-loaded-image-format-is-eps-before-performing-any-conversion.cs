// HOW-TO: Convert EPS to Grayscale PNG and SVG with Format Validation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "input.eps";
        string outputPngPath = Path.Combine("output", "output.png");
        string outputSvgPath = Path.Combine("output", "output.svg");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (!(image is EpsImage))
                {
                    Console.Error.WriteLine("Loaded image is not EPS format.");
                    return;
                }

                // Save as PNG with Grayscale palette
                Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };
                image.Save(outputPngPath, pngOptions);

                // Save as SVG
                Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));
                var svgOptions = new SvgOptions();
                image.Save(outputSvgPath, svgOptions);
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
 * 1. When you need to ensure an uploaded file is a genuine EPS before converting it to a grayscale PNG for printing pipelines.
 * 2. When a web service must transform vector EPS artwork into scalable SVG files for responsive web display while confirming the source format.
 * 3. When automating batch processing of design assets, you want to validate each EPS and generate both a low‑color PNG preview and an SVG version for cataloging.
 * 4. When integrating Aspose.Imaging into a C# application that receives unknown image types, you can check for EPS and safely export to PNG and SVG without runtime errors.
 * 5. When creating a document conversion tool that requires format safety checks, this code guarantees only EPS files are processed before saving them as grayscale PNG thumbnails and editable SVG graphics.
 */
