// HOW-TO: Stream Large Multi‑Page CMX to PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        using (Image page = multipageImage.Pages[i])
                        {
                            string pageOutputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));
                            var pngOptions = new PngOptions();
                            page.Save(pageOutputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "output.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When a desktop application must convert a multi‑page CorelDRAW CMX file into separate PNG pages without loading the entire document into memory.
 * 2. When a server‑side service processes uploaded CMX drawings and needs to generate low‑memory PNG previews for each page on the fly.
 * 3. When an automated batch job converts thousands of large CMX files into PNG assets while keeping RAM consumption low.
 * 4. When a mobile or IoT device receives a CMX document and must render each page as a PNG image using limited resources.
 * 5. When a document management system archives CMX files by extracting each page as a PNG thumbnail without risking out‑of‑memory errors.
 */
