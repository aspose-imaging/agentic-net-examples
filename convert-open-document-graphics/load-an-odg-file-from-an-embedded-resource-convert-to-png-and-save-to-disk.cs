// HOW-TO: Convert Embedded ODG Resource To PNG File In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "MyNamespace.Resources.sample.odg";
            string outputPath = "output/sample.png";

            // Verify input file exists (embedded resource check)
            // For embedded resources, we need to get the stream; if not found, treat as missing file
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = assembly.GetManifestResourceStream(inputPath))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load ODG image from the resource stream
                using (Image image = Image.Load(resourceStream))
                {
                    // Cast to OdgImage (optional, not required for saving as PNG)
                    // OdgImage odgImage = (OdgImage)image;

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to display or share an OpenDocument graphic from a .NET assembly by extracting the embedded ODG and converting it to a widely supported PNG image.
 * 2. When generating thumbnails for ODG diagrams stored as resources in a desktop or web application, and you require a PNG output for UI rendering.
 * 3. When automating a build process that bundles ODG assets inside a DLL and you must export them as PNG files for documentation or packaging.
 * 4. When creating a cross‑platform report that includes vector drawings from an ODG file, and you need to rasterize them to PNG on the server side using Aspose.Imaging.
 * 5. When implementing a plugin that reads ODG icons embedded in a library and saves them as PNG files for use in external tools or user‑customizable themes.
 */
