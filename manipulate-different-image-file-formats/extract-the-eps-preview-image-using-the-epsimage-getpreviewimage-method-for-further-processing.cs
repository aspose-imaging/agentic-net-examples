// HOW-TO: Extract EPS Preview Image to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

namespace EpsPreviewExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "preview.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
                {
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        preview.Save(outputPath);
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
 * 1. When you need to generate a thumbnail PNG of an EPS file for a web gallery or product catalog.
 * 2. When you want to display a low‑resolution preview of a vector logo in a desktop application without rendering the full EPS.
 * 3. When you must batch‑process EPS files to extract their embedded previews before converting them to other raster formats.
 * 4. When you are building a document management system that shows a quick PNG preview of uploaded EPS artwork.
 * 5. When you need to verify that an EPS file contains a preview image by saving it as PNG for further analysis.
 */
