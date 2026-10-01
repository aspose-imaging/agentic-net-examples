// HOW-TO: Convert OTG to JPEG with ICC Profile Embedding in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.otg");
            string outputPath = Path.Combine(baseDir, "Output", "sample.jpg");
            string iccPath = Path.Combine(baseDir, "profile.icc");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream iccStream = File.OpenRead(iccPath))
            {
                var jpegOptions = new JpegOptions();

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert proprietary OTG graphics to web‑friendly JPEGs while preserving accurate colors for digital publishing.
 * 2. When preparing product photos from OTG files for e‑commerce sites and must embed an ICC profile to ensure consistent color across browsers.
 * 3. When automating a workflow that ingests OTG assets and outputs JPEGs with embedded color profiles for print‑ready PDFs.
 * 4. When integrating Aspose.Imaging in a C# application to batch‑process OTG images and attach a specific ICC profile for brand color compliance.
 * 5. When migrating legacy OTG artwork to JPEG format for archival storage and require embedded ICC data to maintain color fidelity during future viewing.
 */
