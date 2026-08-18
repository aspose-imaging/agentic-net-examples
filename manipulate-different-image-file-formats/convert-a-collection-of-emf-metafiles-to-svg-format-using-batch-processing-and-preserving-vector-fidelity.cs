// HOW-TO: Batch Convert EMF Files to SVG with Vector Fidelity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded base folder containing EMF files
            string baseFolder = @"C:\EmfFiles";

            // List of EMF files to convert (add or remove file names as needed)
            string[] emfFiles = new[]
            {
                "sample1.emf",
                "sample2.emf",
                "sample3.emf"
            };

            foreach (string fileName in emfFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(baseFolder, fileName);
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options specific to EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 50,
                        BorderY = 50
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    emfImage.Save(outputPath, saveOptions);
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
 * 1. When you need to migrate a legacy library of Windows Metafile (EMF) diagrams to scalable SVG files for web display without losing vector quality.
 * 2. When an automated build process must convert multiple EMF assets into SVG format as part of a CI pipeline for documentation generation.
 * 3. When a desktop application has to batch‑export user‑created EMF charts to SVG so they can be edited in vector‑graphics editors.
 * 4. When a reporting tool requires converting EMF logos into SVG to embed them in PDF reports that support vector graphics.
 * 5. When a migration script must preserve exact dimensions and colors while turning EMF icons into SVG for a cross‑platform mobile app.
 */
