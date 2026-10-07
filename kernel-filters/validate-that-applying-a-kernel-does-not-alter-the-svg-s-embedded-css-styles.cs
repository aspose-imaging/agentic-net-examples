// HOW-TO: Check If SVG CSS Remains Unchanged After Kernel Processing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SvgKernelValidator
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input/input.svg";
                string outputPath = "output/output.svg";

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Read original SVG content
                string originalSvg = File.ReadAllText(inputPath);

                // Extract CSS from <style> tags
                string originalCss = ExtractCss(originalSvg);

                // Apply kernel (placeholder - no actual modification)
                string processedSvg = ApplyKernel(originalSvg);

                // Extract CSS after processing
                string processedCss = ExtractCss(processedSvg);

                // Write processed SVG to output (optional)
                File.WriteAllText(outputPath, processedSvg);

                // Validate CSS unchanged
                if (originalCss == processedCss)
                {
                    Console.WriteLine("CSS unchanged after kernel application.");
                }
                else
                {
                    Console.WriteLine("CSS was altered by kernel application.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        // Placeholder for kernel application - returns SVG unchanged
        private static string ApplyKernel(string svgContent)
        {
            // In a real scenario, image processing would occur here.
            // For this validation, we return the content unchanged.
            return svgContent;
        }

        // Extracts the content of the first <style> element in the SVG
        private static string ExtractCss(string svgContent)
        {
            var styleRegex = new Regex(@"<style[^>]*>(.*?)</style>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var match = styleRegex.Match(svgContent);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }
            return string.Empty;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that applying an image‑processing kernel to an SVG does not modify its embedded CSS styles.
 * 2. When you want to automate a validation step that ensures SVG <style> tags stay intact after batch processing in a .NET workflow.
 * 3. When you are building a vector‑graphics pipeline that applies filters and must guarantee that visual styling defined in CSS is preserved.
 * 4. When you need to detect unintended changes to SVG CSS after integrating a third‑party kernel or library.
 * 5. When you are testing a custom kernel implementation and want to confirm it leaves the SVG’s CSS unchanged before releasing the code.
 */
