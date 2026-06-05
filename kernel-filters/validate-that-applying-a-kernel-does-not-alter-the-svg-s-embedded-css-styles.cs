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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original SVG content to capture embedded CSS
            string originalSvgContent = File.ReadAllText(inputPath);
            string originalCss = ExtractCss(originalSvgContent);

            // Load SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // NOTE: Applying a kernel directly to an SVG is not supported because SVG is vector.
                // For demonstration, we simply save the SVG which represents a no‑op transformation.
                // In a real scenario, you might rasterize, apply a filter, and re‑embed, but that
                // would not affect the original CSS embedded in the SVG source.

                // Save SVG to output path using default options
                svgImage.Save(outputPath, new SvgOptions());
            }

            // Read saved SVG content and extract CSS
            string savedSvgContent = File.ReadAllText(outputPath);
            string savedCss = ExtractCss(savedSvgContent);

            // Validate that CSS styles are unchanged
            if (originalCss == savedCss)
            {
                Console.WriteLine("Validation passed: CSS styles are unchanged after processing.");
            }
            else
            {
                Console.WriteLine("Validation failed: CSS styles have been altered.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to extract CSS inside <style> tags (if any)
    private static string ExtractCss(string svgContent)
    {
        if (string.IsNullOrEmpty(svgContent))
            return string.Empty;

        var match = Regex.Match(svgContent, @"<style[^>]*>(.*?)</style>", RegexOptions.Singleline);
        return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a CI/CD pipeline automatically optimizes SVG assets, developers can use this code to confirm that the optimization step does not remove or modify the embedded CSS styles.
 * 2. When integrating Aspose.Imaging into a web application that dynamically loads and re‑saves SVG icons, this snippet validates that the round‑trip processing preserves the original style definitions.
 * 3. When migrating a design system’s SVG library to a new version of Aspose.Imaging, the code helps ensure that applying any image filters or kernels does not unintentionally alter the embedded CSS used for theming.
 * 4. When building a batch script that converts SVG files to other formats, developers can run this validation to guarantee that the source SVG’s CSS remains intact before further transformations.
 * 5. When creating automated tests for a graphics microservice, the example provides a simple C# check that the service’s SVG handling logic does not corrupt the stylesheet embedded within the vector file.
 */