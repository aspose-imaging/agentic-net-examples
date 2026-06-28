using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to specific ODG image type
                OdgImage odgImage = (OdgImage)image;

                // Prepare SVG save options (no compression to keep plain SVG)
                using (SvgOptions options = new SvgOptions())
                {
                    options.Compress = false;
                    odgImage.Save(outputPath, options);
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
 * 1. When a developer must transform LibreOffice ODG drawings into web‑ready SVG vectors and shrink the resulting XML for faster page loads, this C# Aspose.Imaging routine loads the ODG, saves it as SVG, and can be followed by XML minification.
 * 2. When an automated publishing pipeline needs to batch‑convert OpenDocument graphics to compact SVG assets for inclusion in HTML newsletters, the code provides a reliable Image.Load and SvgOptions workflow in .NET.
 * 3. When a document management system requires extracting vector illustrations from ODG files and storing them as size‑optimized SVG files for long‑term archival, this snippet demonstrates the necessary file‑format conversion and directory handling.
 * 4. When a SaaS application offers users the ability to upload ODG sketches and instantly receive a minimized SVG preview for embedding in reports, the example shows how to perform the conversion using Aspose.Imaging in C#.
 * 5. When a developer is building a CI/CD task that validates design assets by converting ODG files to SVG and reducing their XML footprint before committing to a repository, this code outlines the essential steps for loading, saving, and preparing the output.
 */