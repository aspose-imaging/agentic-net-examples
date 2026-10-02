// HOW-TO: Convert Multiple WMF Files to JPEG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WmfToJpegParallel
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "input";
                string outputDirectory = "output";

                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.wmf");

                Parallel.ForEach(inputFiles, inputPath =>
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                    }
                });
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
 * 1. When you need to batch‑convert a folder of legacy WMF drawings to JPEG thumbnails quickly for a web gallery.
 * 2. When a desktop application must generate JPEG previews of vector charts stored as WMF files without blocking the UI thread.
 * 3. When a server‑side service processes large numbers of WMF assets and wants to speed up conversion by using parallel execution.
 * 4. When an automated build pipeline has to transform WMF icons into JPEGs for inclusion in documentation or reports.
 * 5. When a migration script has to replace WMF images with JPEG equivalents while preserving file names and directory structure.
 */
