// HOW-TO: Catch Exceptions When Converting PNG To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace SvgConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output/output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    try
                    {
                        image.Save(outputPath, new SvgOptions());
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Failed to save SVG for {outputPath}: {ex.Message}");
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
 * 1. When an automated batch job converts user‑uploaded PNG files to SVG and must log any failures without stopping the whole process.
 * 2. When a web service generates scalable vector graphics from raster images and needs to capture the exact file path and error details for troubleshooting.
 * 3. When a desktop application allows users to export edited PNG pictures as SVG and wants to display a clear error message if the save operation fails.
 * 4. When a CI/CD pipeline validates image assets by converting them to SVG and requires exception handling to prevent pipeline crashes.
 * 5. When a background service monitors a folder, converts new PNG files to SVG using Aspose.Imaging, and records any save errors to a log file for later analysis.
 */
