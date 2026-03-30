using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Save the SVG unchanged (no rasterization) to the output path
            // This demonstrates that processing does not modify the SVG content
            svgImage.Save(outputPath, new SvgOptions());
        }

        // Read original and saved SVG contents
        string originalSvg = File.ReadAllText(inputPath);
        string savedSvg = File.ReadAllText(outputPath);

        // Extract CSS inside <style> tags using a simple regex (non‑greedy)
        string ExtractCss(string svgContent)
        {
            var match = Regex.Match(svgContent, @"<style[^>]*>(.*?)</style>", RegexOptions.Singleline);
            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }

        string originalCss = ExtractCss(originalSvg);
        string savedCss = ExtractCss(savedSvg);

        // Validate that the CSS styles are identical
        if (originalCss == savedCss)
        {
            Console.WriteLine("Validation succeeded: Embedded CSS styles are unchanged.");
        }
        else
        {
            Console.Error.WriteLine("Validation failed: Embedded CSS styles have been altered.");
        }
    }
}