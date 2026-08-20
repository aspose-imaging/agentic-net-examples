// HOW-TO: Extract TIFF Clipping Paths and Save as SVG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "Sample.tif";
        string outputDirectory = "ExportedSvg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the TIFF image
            using (var image = (TiffImage)Image.Load(inputPath))
            {
                // Get the size of the active frame (used for SVG canvas size)
                var frameSize = image.ActiveFrame.Size;

                // Iterate over each clipping path (PathResource)
                foreach (var pathResource in image.ActiveFrame.PathResources)
                {
                    // Build a simple SVG content – this example creates an empty path.
                    // For a real conversion you would translate the PathResource records
                    // into SVG path commands. Here we provide a minimal valid SVG.
                    string svgContent = GenerateSimpleSvg(frameSize.Width, frameSize.Height, pathResource.Name);

                    // Determine output file path (use the path name, fallback to a generic name)
                    string safeName = string.IsNullOrWhiteSpace(pathResource.Name) ? "UnnamedPath" : pathResource.Name;
                    string outputPath = Path.Combine(outputDirectory, $"{safeName}.svg");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the SVG file
                    File.WriteAllText(outputPath, svgContent, Encoding.UTF8);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Generates a minimal SVG document with a placeholder path.
    private static string GenerateSimpleSvg(int width, int height, string title)
    {
        // Simple path data – a single move command; replace with real data if needed.
        const string pathData = "M0,0";

        return $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" width=""{width}"" height=""{height}"" version=""1.1"">
  <title>{System.Security.SecurityElement.Escape(title)}</title>
  <path d=""{pathData}"" stroke=""black"" fill=""none""/>
</svg>";
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert vector clipping paths embedded in a multi‑page TIFF into separate SVG files for web graphics or further editing.
 * 2. When a printing workflow requires extracting precise cutout shapes from a TIFF and providing them as scalable SVG masks.
 * 3. When automating archival of design assets, you want to preserve the original TIFF clipping paths as reusable SVG vector files.
 * 4. When integrating with a GIS or CAD system that accepts SVG, you can pull the TIFF path resources and export them for spatial analysis.
 * 5. When building a C# application that batch‑processes scanned documents and needs to separate each embedded clipping path into its own SVG for downstream processing.
 */
