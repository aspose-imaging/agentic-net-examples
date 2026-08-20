// HOW-TO: Parallel Convert Multiple WMF Files to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of WMF input files
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.wmf",
                @"C:\Images\sample2.wmf",
                @"C:\Images\sample3.wmf"
            };

            // Parallel conversion to JPEG
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .jpg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image and save as JPEG
                using (Image image = Image.Load(inputPath))
                {
                    // Use default JPEG options; customize if needed
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90 // example quality setting
                    };

                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to speed up batch conversion of legacy WMF graphics to JPEG for a web gallery.
 * 2. When processing a large set of vector drawings on a server and want to generate raster JPEG thumbnails concurrently.
 * 3. When automating migration of old Windows Metafile assets to a modern image format in a multi‑core environment.
 * 4. When integrating image conversion into a CI pipeline that must handle many WMF files quickly.
 * 5. When building a desktop tool that lets users select several WMF files and converts them to JPEG with minimal code.
 */
