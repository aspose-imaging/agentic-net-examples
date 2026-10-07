// HOW-TO: Convert DICOM Image to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a healthcare application needs to display radiology scans in a web browser, developers can convert DICOM files to PNG for easy rendering.
 * 2. When integrating medical imaging data into a reporting system that only accepts standard image formats, the code enables batch conversion from DICOM to PNG.
 * 3. When a developer wants to create thumbnails of DICOM studies for a PACS viewer, converting to PNG provides fast, lightweight preview images.
 * 4. When exporting diagnostic images for patient portals or mobile apps, the conversion to PNG ensures compatibility across devices.
 * 5. When performing image analysis with libraries that do not support DICOM, converting the files to PNG allows reuse of existing C# image‑processing pipelines.
 */
