using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of ODG files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg",
                @"C:\Images\sample3.odg"
            };

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path (same folder, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PNG save options with rasterization settings
                    var pngOptions = new PngOptions();
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a large collection of OpenDocument Graphics (ODG) drawings to PNG thumbnails for a web gallery, they can use this parallel C# code to speed up processing.
 * 2. When an automated document‑management system must generate PNG previews of newly uploaded ODG files on a Windows server, the Task Parallel Library loop enables concurrent conversion.
 * 3. When a desktop application has to rasterize multiple ODG diagrams into high‑resolution PNG assets for printing, this code provides fast, multi‑core execution.
 * 4. When a cloud‑based image‑processing pipeline processes user‑submitted ODG files and stores PNG versions in the same directory, the parallel conversion reduces overall latency.
 * 5. When a CI/CD build step validates that all ODG resources in a project are correctly rendered as PNGs before packaging, the parallel approach ensures the checks complete quickly.
 */