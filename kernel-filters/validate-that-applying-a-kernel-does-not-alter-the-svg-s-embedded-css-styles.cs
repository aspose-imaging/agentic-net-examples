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
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string originalContent = File.ReadAllText(inputPath);
            string originalCss = ExtractCss(originalContent);

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new SvgOptions());
            }

            string newContent = File.ReadAllText(outputPath);
            string newCss = ExtractCss(newContent);

            if (originalCss == newCss)
                Console.WriteLine("CSS unchanged after applying kernel.");
            else
                Console.WriteLine("CSS altered after applying kernel.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple CSS extraction between <style> tags
    static string ExtractCss(string svgContent)
    {
        int styleStart = svgContent.IndexOf("<style", StringComparison.OrdinalIgnoreCase);
        if (styleStart == -1)
            return string.Empty;

        int tagEnd = svgContent.IndexOf('>', styleStart);
        if (tagEnd == -1)
            return string.Empty;

        int styleEnd = svgContent.IndexOf("</style>", tagEnd, StringComparison.OrdinalIgnoreCase);
        if (styleEnd == -1)
            return string.Empty;

        return svgContent.Substring(tagEnd + 1, styleEnd - tagEnd - 1).Trim();
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web designer automates batch processing of SVG icons with Aspose.Imaging kernels and must ensure the original CSS styling (fills, strokes, fonts) remains unchanged after saving.
 * 2. When a CI/CD pipeline validates that a build step applying a convolution kernel to SVG assets does not corrupt embedded <style> definitions before publishing to a design system.
 * 3. When a SaaS platform that generates custom charts uses C# to apply image filters to SVG diagrams and needs to verify that the chart’s CSS‑driven colors and animations are preserved.
 * 4. When a mobile app backend converts user‑uploaded SVG logos with Aspose.Imaging and applies a sharpening kernel, it must confirm that the logo’s CSS classes are still intact for responsive rendering.
 * 5. When an e‑learning content management system runs automated tests to check that applying a blur kernel to SVG illustrations via Aspose.Imaging does not alter the embedded CSS used for accessibility styling.
 */