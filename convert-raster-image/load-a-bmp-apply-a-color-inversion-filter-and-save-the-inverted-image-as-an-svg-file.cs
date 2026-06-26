using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new SvgOptions();
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
 * 1. When a developer needs to convert legacy BMP assets into scalable SVG icons with a high‑contrast, color‑inverted look for modern UI themes.
 * 2. When an application must generate printable line‑art diagrams from scanned BMP drawings by inverting colors and exporting them as SVG for lossless scaling.
 * 3. When a web service processes user‑uploaded BMP photos, applies a negative filter for artistic effect, and returns the result as an SVG file for responsive web display.
 * 4. When a batch‑processing tool automates the transformation of BMP screenshots into inverted‑color SVG graphics for inclusion in documentation or presentations.
 * 5. When a C# program integrates Aspose.Imaging to read BMP files, apply a color inversion filter, and save the output as SVG to support vector‑based image pipelines in a CI/CD workflow.
 */