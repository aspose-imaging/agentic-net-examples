using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input folder and file list
            string inputFolder = @"C:\EmfFiles";
            string[] files = new string[]
            {
                "image1.emf",
                "image2.emf",
                "image3.emf"
            };

            foreach (var fileName in files)
            {
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.ChangeExtension(inputPath, ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Set up SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
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
 * 1. When a developer needs to migrate a legacy collection of Windows Metafile (EMF) graphics to web‑friendly Scalable Vector Graphics (SVG) for responsive UI rendering.
 * 2. When an automated build pipeline must convert multiple EMF icons into SVG files while preserving vector fidelity for high‑resolution displays.
 * 3. When a document management system requires batch processing of EMF diagrams into SVG to enable searchable, scalable vector content in browsers.
 * 4. When a reporting tool generates charts as EMF files and the developer wants to export them as SVG for inclusion in HTML reports without loss of quality.
 * 5. When a GIS application stores map symbols as EMF and needs to bulk convert them to SVG for cross‑platform visualization in web maps.
 */