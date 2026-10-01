// HOW-TO: Batch Convert ODG and OTG Files to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchConvert
{
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

                // Get all ODG and OTG files in the input directory
                string[] odgFiles = Directory.GetFiles(inputDirectory, "*.odg", SearchOption.TopDirectoryOnly);
                string[] otgFiles = Directory.GetFiles(inputDirectory, "*.otg", SearchOption.TopDirectoryOnly);

                string[] allFiles = new string[odgFiles.Length + otgFiles.Length];
                odgFiles.CopyTo(allFiles, 0);
                otgFiles.CopyTo(allFiles, odgFiles.Length);

                foreach (string inputPath in allFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path with .svg extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the image and save as SVG
                    using (Image image = Image.Load(inputPath))
                    {
                        SvgOptions options = new SvgOptions();
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a library of OpenDocument graphics (ODG) and OpenType glyph (OTG) files to scalable SVG for web display.
 * 2. When an automated build or CI pipeline must generate SVG assets from design files stored in a shared folder.
 * 3. When a reporting or documentation tool requires vector images in SVG format but the source assets are provided as ODG or OTG.
 * 4. When you want to preserve vector quality while converting multiple OpenDocument drawings to a format supported by modern browsers.
 * 5. When a desktop application needs to batch process user‑uploaded ODG/OTG files and store the results as SVG for further editing.
 */
