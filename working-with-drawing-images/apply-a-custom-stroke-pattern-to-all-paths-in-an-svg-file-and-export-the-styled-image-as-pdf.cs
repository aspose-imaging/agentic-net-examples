using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.pdf";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Read original SVG content
            string svgContent = File.ReadAllText(inputPath);

            // Apply a custom dash pattern to all <path> elements
            // This adds stroke-dasharray="5,5" to each path tag
            string pattern = @"(<path\b[^>]*?)>";
            string replacement = "$1 stroke-dasharray=\"5,5\">";
            string modifiedSvg = Regex.Replace(svgContent, pattern, replacement, RegexOptions.IgnoreCase);

            // Save the modified SVG to a temporary file
            string tempSvgPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".svg");
            File.WriteAllText(tempSvgPath, modifiedSvg);

            // Load the modified SVG using Aspose.Imaging
            using (Image image = Image.Load(tempSvgPath))
            {
                // Save the image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempSvgPath))
            {
                File.Delete(tempSvgPath);
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
 * 1. When a developer needs to add a dashed stroke pattern to every vector path in an SVG diagram and then generate a printable PDF report using C# and Aspose.Imaging.
 * 2. When an automation script must batch‑process SVG assets, inject a custom stroke‑dasharray attribute via regular expressions, and output the styled graphics as PDF files for archival.
 * 3. When a web application has to dynamically modify user‑uploaded SVG icons to show a patterned outline and deliver the result as a PDF download without manual editing.
 * 4. When a CI/CD pipeline requires converting design mockups in SVG format to PDF while applying a uniform dash style to all paths for consistent branding.
 * 5. When a desktop utility needs to validate the existence of an SVG file, apply a custom dash pattern to its paths, and export the final image as a high‑resolution PDF using Aspose.Imaging in .NET.
 */