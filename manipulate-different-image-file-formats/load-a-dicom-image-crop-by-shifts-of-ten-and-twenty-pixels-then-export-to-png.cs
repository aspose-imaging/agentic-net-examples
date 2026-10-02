// HOW-TO: Crop DICOM Image by Pixel Offsets and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                // Crop by shifts: left=10, right=20, top=10, bottom=20
                image.Crop(10, 20, 10, 20);

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to extract a specific region from a DICOM scan and store it as a lightweight PNG for web display.
 * 2. When a radiology workflow requires batch processing to remove border artifacts from DICOM files before archiving them as PNG thumbnails.
 * 3. When a developer wants to convert DICOM images to PNG after trimming unwanted margins to reduce file size for mobile devices.
 * 4. When integrating a C# service that prepares patient scans by cropping fixed pixel offsets and delivering them in PNG format to a reporting system.
 * 5. When building a diagnostic tool that reads DICOM files, crops a region of interest, and saves the result as PNG for further analysis in non‑medical software.
 */
