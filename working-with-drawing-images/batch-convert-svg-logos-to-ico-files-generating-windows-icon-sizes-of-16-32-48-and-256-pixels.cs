// HOW-TO: Batch Convert SVG Logos To Multi‑Size ICO Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            int[] sizes = new int[] { 16, 32, 48, 256 };

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string baseName = Path.GetFileNameWithoutExtension(inputPath);

                foreach (int size in sizes)
                {
                    string outputPath = Path.Combine(outputDirectory, $"{baseName}_{size}.ico");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                    {
                        image.Resize(size, size);
                        using (IcoOptions icoOptions = new IcoOptions())
                        {
                            image.Save(outputPath, icoOptions);
                        }
                    }
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
 * 1. When you need to generate Windows application icons from vector SVG logos for different display resolutions.
 * 2. When you have a folder of SVG assets and must automatically create 16‑, 32‑, 48‑, and 256‑pixel ICO files for a software installer.
 * 3. When you want to integrate icon generation into a build pipeline so that each SVG brand image is saved as a set of Windows‑compatible icons.
 * 4. When you are preparing a set of favicon icons for a desktop shortcut and require batch processing without manual resizing.
 * 5. When you need to programmatically convert and resize SVG graphics to ICO format for a .NET desktop application’s UI resources.
 */
