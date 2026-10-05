// HOW-TO: Batch Convert BMP Images To Lossless WebP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchConvertBmpToWebp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "C:\\InputImages";
                string outputDirectory = "C:\\OutputImages";

                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string inputPath in bmpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        WebPOptions options = new WebPOptions
                        {
                            Lossless = true
                        };
                        image.Save(outputPath, options);
                    }
                }
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
 * 1. When you need to shrink a legacy collection of BMP graphics for faster web delivery without losing visual quality.
 * 2. When an automated build process must convert newly generated BMP screenshots into WebP files for storage optimization.
 * 3. When a desktop application has to prepare user‑uploaded BMP pictures for a cloud service that only accepts WebP format.
 * 4. When migrating a digital asset library, you want to batch‑process BMP files into lossless WebP to reduce disk space while preserving exact colors.
 * 5. When creating a nightly batch job that converts any BMP files placed in a folder into WebP for a content‑management workflow.
 */
