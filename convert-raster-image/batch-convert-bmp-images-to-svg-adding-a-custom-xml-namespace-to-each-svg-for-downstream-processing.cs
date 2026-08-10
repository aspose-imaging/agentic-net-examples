// HOW-TO: Batch Convert BMP Images to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Bmp";
            string outputDir = @"C:\Images\Svg";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG rasterization options (use image size)
                    var vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions,
                        // Keep metadata if needed
                        KeepMetadata = true
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }

                // Add custom XML namespace to the generated SVG
                try
                {
                    XDocument doc = XDocument.Load(outputPath);
                    XElement root = doc.Root;
                    if (root != null && root.Name.LocalName == "svg")
                    {
                        // Define custom namespace URI
                        const string customNsUri = "http://example.com/custom";
                        // Add the namespace declaration if not already present
                        XAttribute existing = root.Attribute("xmlns:custom");
                        if (existing == null)
                        {
                            root.SetAttributeValue("xmlns:custom", customNsUri);
                        }
                        // Save the modified SVG back to disk
                        doc.Save(outputPath);
                    }
                }
                catch (Exception nsEx)
                {
                    // If namespace injection fails, report but continue processing other files
                    Console.Error.WriteLine($"Warning: Could not add custom namespace to {outputPath}: {nsEx.Message}");
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
 * 1. When you need to migrate a legacy collection of BMP files to scalable SVG format for web display using C#.
 * 2. When an automated build process must convert multiple BMP assets into SVG vectors while preserving image dimensions and metadata.
 * 3. When a desktop application has to generate SVG diagrams from user‑uploaded BMP screenshots for further editing in vector tools.
 * 4. When a server‑side service processes incoming BMP uploads and stores them as SVG files to reduce storage size and enable responsive rendering.
 * 5. When a data‑pipeline requires batch conversion of BMP graphics to SVG with consistent page size settings for downstream XML‑based processing.
 */
