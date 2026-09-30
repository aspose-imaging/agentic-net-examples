// HOW-TO: Log Start and End Timestamps for DICOM to PNG Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace DicomToPngConverter
{
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

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                ConversionLogger.ConvertDicomToPng(inputPath, outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static class ConversionLogger
    {
        public static void ConvertDicomToPng(string inputPath, string outputPath)
        {
            DateTime start = DateTime.UtcNow;
            Console.WriteLine($"Conversion started at {start:O}");

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }

            DateTime end = DateTime.UtcNow;
            Console.WriteLine($"Conversion ended at {end:O}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit how long each DICOM to PNG conversion takes in a medical imaging pipeline.
 * 2. When you want to record conversion timestamps for compliance reporting in radiology software.
 * 3. When you are troubleshooting performance issues by comparing start and end times of image conversions.
 * 4. When you need a simple console log for batch processing of DICOM files into PNG format.
 * 5. When you integrate DICOM to PNG conversion into a larger C# application and require timestamped logs for monitoring.
 */
