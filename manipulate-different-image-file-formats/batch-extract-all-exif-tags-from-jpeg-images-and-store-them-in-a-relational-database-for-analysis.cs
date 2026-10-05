// HOW-TO: Batch Extract JPEG EXIF Tags to CSV Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputFile = "Output/exif_data.csv";

            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToList();

            using (var writer = new StreamWriter(outputFile, false))
            {
                writer.WriteLine("FilePath,TagName,TagValue");

                foreach (var filePath in jpegFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (var image = (JpegImage)Image.Load(filePath))
                    {
                        var exif = image.ExifData;
                        if (exif == null) continue;

                        var exifType = exif.GetType();
                        var properties = exifType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                        foreach (var prop in properties)
                        {
                            var value = prop.GetValue(exif);
                            if (value != null)
                            {
                                string valStr = value.ToString().Replace("\"", "\"\"");
                                writer.WriteLine($"{filePath},{prop.Name},\"{valStr}\"");
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
 * 1. When a photographer wants to analyze camera settings across a large photo shoot, they can run this code to pull all EXIF metadata from JPEG files into a CSV for spreadsheet analysis.
 * 2. When a digital asset management system needs to index image properties for search and filtering, the script extracts EXIF tags from each JPEG and stores them in a relational‑database‑friendly CSV.
 * 3. When a compliance audit requires verification of image capture dates and GPS locations, developers can use this routine to batch export those EXIF fields from JPEGs for reporting.
 * 4. When a machine‑learning pipeline needs labeled image metadata as features, the code quickly gathers EXIF information from a folder of JPEGs into a structured CSV for model training.
 * 5. When a web application must display photo metadata to end‑users without loading each image, the batch extraction creates a ready‑to‑query CSV that can be imported into a database for fast lookup.
 */
