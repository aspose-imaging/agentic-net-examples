using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Input";
            string outputDirectory = @"C:\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all .odg and .otg files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in inputFiles)
            {
                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                if (extension != ".odg" && extension != ".otg")
                    continue; // Skip non‑ODG/OTG files

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image (ODG or OTG)
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG options with appropriate rasterization options
                    SvgOptions svgOptions = new SvgOptions();

                    if (extension == ".odg")
                    {
                        // Use OdgRasterizationOptions for ODG files
                        OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        svgOptions.VectorRasterizationOptions = rasterOptions;
                    }
                    else // .otg
                    {
                        // Use OtgRasterizationOptions for OTG files
                        OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        svgOptions.VectorRasterizationOptions = rasterOptions;
                    }

                    // Save as SVG preserving vectors
                    image.Save(outputPath, svgOptions);
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
 * 1. When a design studio needs to automate the conversion of a large collection of OpenDocument Graphics (.odg) and OpenDocument Template Graphics (.otg) files into scalable SVG files for web publishing, this C# Aspose.Imaging batch conversion code can process the entire folder while preserving vector data.
 * 2. When a corporate intranet requires a nightly job that transforms engineering schematics stored as ODG/OTG into SVG format for inclusion in HTML reports, developers can use this code to iterate through the source directory and generate vector‑accurate SVG assets.
 * 3. When a GIS (Geographic Information System) team wants to migrate legacy map symbols saved as .odg and .otg into SVG symbols for use in modern mapping libraries, the provided C# script automates the bulk conversion while keeping the original vector shapes intact.
 * 4. When an e‑learning platform must convert teacher‑created diagram templates in ODG/OTG into responsive SVG illustrations for interactive lessons, this Aspose.Imaging example enables batch processing of the files with full vector fidelity.
 * 5. When a cloud‑based document management system needs to index and preview vector graphics by converting stored ODG and OTG files to SVG on demand, developers can integrate this code to scan directories, load each image, and output SVG files ready for fast rendering.
 */