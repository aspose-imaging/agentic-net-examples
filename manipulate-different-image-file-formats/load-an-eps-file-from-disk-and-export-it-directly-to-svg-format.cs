// HOW-TO: Convert EPS File to SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output/output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image and save it as SVG
            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to display a printable EPS logo on a web page, you can convert it to scalable SVG with C#.
 * 2. When a design workflow requires transforming vector EPS artwork into SVG for responsive UI components, this code automates the conversion.
 * 3. When an automated build process must generate SVG assets from EPS source files for cross‑platform compatibility, the snippet provides a simple solution.
 * 4. When a desktop application imports user‑provided EPS diagrams and needs to export them as SVG for further editing in vector editors, this approach handles the conversion.
 * 5. When a cloud service receives EPS files via API and must return lightweight SVG previews to clients, the code demonstrates how to perform the conversion in .NET.
 */
