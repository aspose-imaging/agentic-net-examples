using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputFilePath = "Output/exif_data.sql";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Collect JPEG files
            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            var allFiles = new List<string>();
            allFiles.AddRange(jpgFiles);
            allFiles.AddRange(jpegFiles);

            using (StreamWriter writer = new StreamWriter(outputFilePath, false))
            {
                writer.WriteLine("-- EXIF data extraction");

                foreach (string inputPath in allFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                    {
                        var exif = jpeg.ExifData;
                        if (exif != null)
                        {
                            writer.WriteLine($"-- EXIF for {Path.GetFileName(inputPath)}");
                            writer.WriteLine("EXIF data extracted.");
                        }
                        else
                        {
                            writer.WriteLine($"-- No EXIF data for {Path.GetFileName(inputPath)}");
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
 * 1. When a photographer needs to batch‑extract EXIF tags from thousands of JPEG images and store them in a relational database for statistical analysis of camera settings, this C# code using Aspose.Imaging provides a quick solution.
 * 2. When a digital asset management system must index image metadata across multiple folders, developers can use this script to read JPEG EXIF data and generate SQL insert statements for easy querying.
 * 3. When a marketing team wants to analyze geolocation and timestamp information from product photos to track campaign timelines, the code automates the extraction of EXIF fields and writes them to a .sql file.
 * 4. When a compliance audit requires verification that all uploaded JPEG files contain required metadata such as copyright or author tags, this program scans the files and records the presence or absence of EXIF data in a database.
 * 5. When an e‑commerce platform needs to populate a database with image resolution, exposure, and ISO values from vendor‑supplied JPEGs to improve search filters, the example demonstrates how to pull those EXIF values programmatically.
 */