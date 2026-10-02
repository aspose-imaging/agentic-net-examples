// HOW-TO: Convert PDF With Vector Charts To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
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
 * 1. When you need to display PDF‑generated scientific charts on a web page without losing axis lines or data labels, you can convert the PDF to SVG for scalable, interactive graphics.
 * 2. When building a reporting dashboard that pulls PDF reports and wants to embed the charts as responsive SVG elements, this code automates the conversion in a C# backend.
 * 3. When migrating legacy PDF documentation containing vector diagrams to a modern HTML5 site, converting the files to SVG preserves the quality and enables CSS styling.
 * 4. When creating an e‑learning platform that extracts vector charts from PDF textbooks for interactive manipulation, the conversion to SVG allows zoom‑in without pixelation.
 * 5. When developing a cross‑platform mobile app that needs to render PDF chart assets as lightweight SVGs to reduce bundle size and improve rendering speed, this snippet provides the necessary transformation.
 */
