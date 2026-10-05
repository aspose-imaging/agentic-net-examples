// HOW-TO: Handle SVG Load Errors and Log Details in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        const string inputPath = "input.svg";
        const string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (Exception loadEx)
            {
                Console.Error.WriteLine($"Error loading SVG: {loadEx}");
                return;
            }

            using (image)
            {
                image.Save(outputPath);
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
 * 1. When converting an SVG diagram to a PNG thumbnail in a batch process, you need to verify the source file exists and capture any loading failures for troubleshooting.
 * 2. When building a web service that receives user‑uploaded SVG files and returns PNG images, you must handle malformed SVG content and log the exception details to diagnose client issues.
 * 3. When automating report generation that reads SVG charts from a shared folder and writes PNG outputs to a separate directory, you need to create the output folder if missing and record errors if the SVG cannot be parsed.
 * 4. When integrating Aspose.Imaging into a desktop application that opens SVG assets, you should catch load exceptions to prevent the app from crashing and provide clear error messages to the user.
 * 5. When migrating legacy SVG assets to PNG for a mobile app, you need robust error handling to identify corrupted files early and log the stack trace for later analysis.
 */
