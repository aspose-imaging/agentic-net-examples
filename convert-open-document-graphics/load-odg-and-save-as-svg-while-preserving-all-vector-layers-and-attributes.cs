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
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.svg";

            // Verify that the input ODG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options to preserve vector data and metadata
                SvgOptions svgOptions = new SvgOptions
                {
                    KeepMetadata = true,   // retain original metadata
                    Compress = false       // avoid compression to keep vector fidelity
                };

                // Save the image as SVG, preserving all vector layers and attributes
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert an ODG drawing created in LibreOffice into an SVG for web display while preserving all vector layers, metadata, and original attributes.
 * 2. When a developer wants to automate the batch conversion of design assets stored as ODG files into SVG format for inclusion in a mobile app’s scalable graphics library.
 * 3. When a developer must migrate legacy OpenDocument graphics to an SVG‑based reporting system and ensure that every vector element and its properties remain intact.
 * 4. When a developer integrates ODG‑to‑SVG conversion into a CI/CD pipeline to generate high‑fidelity SVG icons from designer files without losing vector data.
 * 5. When a developer builds a C# service that accepts ODG uploads and returns SVG output for downstream image processing or printing workflows.
 */