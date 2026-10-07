// HOW-TO: Convert EMF to SVG with Arial Font Replacement in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.emf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FontSettings.DefaultFontName = "Arial";

            using (Image emfImage = Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions();
                emfImage.Save(outputPath, svgOptions);
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
 * 1. When you need to embed vector graphics from legacy EMF files into a web page that only supports SVG, and you want all text to use Arial for consistent styling.
 * 2. When migrating a Windows desktop application's icons from EMF to scalable SVG format while ensuring the default font matches corporate branding.
 * 3. When generating printable reports that include EMF diagrams but the output must be an SVG file with a specific font for accessibility compliance.
 * 4. When automating a batch conversion of EMF assets to SVG for a cross‑platform mobile app, and you must enforce Arial as the fallback font.
 * 5. When updating a design pipeline that receives EMF drawings from third‑party tools and you need to standardize the font to Arial before converting them to SVG for further editing.
 */
