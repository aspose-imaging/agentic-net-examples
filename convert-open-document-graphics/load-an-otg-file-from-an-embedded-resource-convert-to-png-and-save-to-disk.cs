using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.otg");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "sample.png");

            // Extract embedded OTG resource to a temporary file
            // Resource name must match the actual embedded resource (e.g., "MyNamespace.Resources.sample.otg")
            using (Stream resourceStream = Assembly.GetExecutingAssembly()
                                                    .GetManifestResourceStream("MyNamespace.Resources.sample.otg"))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine("Embedded resource not found: sample.otg");
                    return;
                }

                using (FileStream fileStream = new FileStream(inputPath, FileMode.Create, FileAccess.Write))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                var pngOptions = new PngOptions();
                var otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                // Save as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to embed an OTG vector graphic in a .NET assembly and generate a PNG preview at runtime for display in a Windows Forms or WPF application.
 * 2. When a build pipeline must convert bundled OTG icons into PNG assets for inclusion in a cross‑platform mobile app without requiring external tools.
 * 3. When a server‑side service reads an OTG diagram from an embedded resource, rasterizes it to PNG, and stores the result on disk for caching or email attachment generation.
 * 4. When a documentation generator extracts OTG schematics packaged as resources, converts them to PNG, and saves them alongside HTML files for searchable web help.
 * 5. When a plugin for a CMS loads an OTG logo from its own resources, transforms it to a PNG thumbnail, and writes the file to the site’s media folder for SEO‑friendly image indexing.
 */