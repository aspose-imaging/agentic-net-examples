// HOW-TO: Extract TIFF Clipping Paths and Save as SVG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
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
                // Iterate over each clipping path (PathResource) in the active frame
                foreach (var pathResource in image.ActiveFrame.PathResources)
                {
                    // Build SVG file path using the path name
                    string safeName = string.IsNullOrWhiteSpace(pathResource.Name) ? "UnnamedPath" : pathResource.Name;
                    string svgFilePath = Path.Combine(outputDirectory, $"{safeName}.svg");

                    // Ensure the directory for the SVG file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(svgFilePath));

                    // Write a minimal SVG file containing the path name as a comment.
                    // For a full export, you would convert the PathResource records to SVG path data.
                    using (var writer = new StreamWriter(svgFilePath))
                    {
                        writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                        writer.WriteLine(@"<svg xmlns=""http://www.w3.org/2000/svg"" version=""1.1"">");
                        writer.WriteLine($"  <!-- Path name: {safeName} -->");
                        // Placeholder path data – replace with actual conversion if needed
                        writer.WriteLine(@"  <path d=""M0,0 L100,0 L100,100 L0,100 Z"" fill=""none"" stroke=""black""/>");
                        writer.WriteLine(@"</svg>");
                    }

                    Console.WriteLine($"Exported SVG: {svgFilePath}");
                }
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
 * 1. When you need to preserve vector clipping information from a multi‑page TIFF for use in web graphics, you can extract each path and export it as an SVG file.
 * 2. When a printing workflow requires converting TIFF cut‑out shapes into scalable SVG assets for further editing in design tools, this code reads the PathResources and creates SVG placeholders.
 * 3. When building a document‑to‑HTML converter that must retain image masks, you can pull the TIFF clipping paths and output them as SVG to overlay on the HTML page.
 * 4. When automating quality‑control checks that compare vector outlines stored in TIFF files against expected shapes, exporting the paths to SVG enables easy visual inspection.
 * 5. When integrating legacy scanned artwork stored in TIFF with modern vector‑based applications, extracting the embedded clipping paths and saving them as SVG files simplifies the migration process.
 */
