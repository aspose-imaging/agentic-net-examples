// HOW-TO: Batch Convert SVG Files to APNG Animations in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".apng");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, new PngOptions());
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            ApngOptions apngOptions = new ApngOptions
                            {
                                Source = new FileCreateSource(outputPath, false)
                            };

                            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                            {
                                apng.RemoveAllFrames();
                                apng.AddFrame(raster);
                                apng.Save();
                            }
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
 * 1. When you need to generate animated PNGs from a collection of vector icons for a web UI, you can batch‑process the SVG assets into APNG files using C# and Aspose.Imaging.
 * 2. When an application must export user‑drawn SVG diagrams as lightweight animations for email newsletters, this code converts each SVG to an APNG with a default frame delay automatically.
 * 3. When a game development pipeline requires converting SVG sprites into APNG sequences for in‑game animations, the script processes all files in a folder without manual intervention.
 * 4. When a CI/CD build step has to transform design‑team SVG assets into APNG assets for mobile apps, the batch conversion ensures consistent frame timing across all images.
 * 5. When a reporting tool needs to embed animated graphics generated from SVG charts, this code creates individual APNG files from the source SVGs in one go.
 */
