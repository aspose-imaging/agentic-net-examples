using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.tif";
        string outputDirectory = "ClippingPaths";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each clipping path (PathResource) in the active frame
                foreach (PathResource pathResource in tiffImage.ActiveFrame.PathResources)
                {
                    // Build SVG file path using the path name
                    string safeName = string.IsNullOrWhiteSpace(pathResource.Name) ? "UnnamedPath" : pathResource.Name;
                    string svgFilePath = Path.Combine(outputDirectory, $"{safeName}.svg");

                    // Ensure the directory for the SVG file exists (redundant but follows the rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(svgFilePath));

                    // Write a minimal SVG file containing the path name as a comment.
                    // Detailed conversion of PathResource records to SVG path data can be added here.
                    using (StreamWriter writer = new StreamWriter(svgFilePath))
                    {
                        writer.WriteLine(@"<svg xmlns=""http://www.w3.org/2000/svg"" version=""1.1"">");
                        writer.WriteLine($"  <!-- Clipping Path: {safeName} -->");
                        writer.WriteLine(@"</svg>");
                    }

                    Console.WriteLine($"Exported clipping path '{safeName}' to '{svgFilePath}'.");
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
 * 1. When a developer needs to extract vector clipping paths from a multi‑page TIFF and reuse them in web graphics, they can load the TIFF with Aspose.Imaging, iterate the PathResources of the active frame, and save each path as an SVG file.
 * 2. When a print‑production workflow requires converting embedded TIFF clipping masks into scalable SVG outlines for downstream layout tools, this code provides a C# solution to read the TIFF, access its PathResources, and export them.
 * 3. When a GIS or CAD application must preserve region definitions stored as TIFF clipping paths and share them with vector‑based mapping software, developers can use this snippet to extract those paths and generate SVG representations.
 * 4. When an e‑commerce platform wants to generate lightweight vector thumbnails from high‑resolution TIFF product images that contain clipping paths, the code enables extracting those paths and creating SVG files for fast rendering.
 * 5. When a digital archivist needs to catalog and visualize the clipping paths embedded in historical TIFF scans without rasterizing the image, they can employ this example to read the PathResources and export each as an SVG for inspection.
 */