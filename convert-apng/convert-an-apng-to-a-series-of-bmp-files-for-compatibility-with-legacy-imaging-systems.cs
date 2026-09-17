// HOW-TO: Convert APNG Animation to Separate BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
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
                        using (Image frame = multipageImage.Pages[i])
                        {
                            string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            frame.Save(outputPath, new BmpOptions());
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image does not contain multiple frames.");
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
 * 1. When you need to display animated PNG frames on a legacy system that only supports BMP files.
 * 2. When you want to extract each frame of an APNG for further processing such as computer‑vision analysis or frame‑by‑frame editing.
 * 3. When you are preparing assets for a game engine that requires individual BMP sprites instead of an animated PNG.
 * 4. When you must archive animation frames in a widely supported, lossless bitmap format for regulatory compliance or long‑term storage.
 * 5. When you need to batch‑convert APNG files to BMP for printing or scanning pipelines that cannot handle animated PNGs.
 */
