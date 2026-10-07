// HOW-TO: Convert CDR to JPG with Error Handling in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a desktop application needs to batch‑convert CorelDRAW (.cdr) files to JPEG images while safely handling missing files and runtime errors.
 * 2. When an automated build pipeline must generate preview thumbnails (JPG) from design assets stored as CDR files and log any conversion failures.
 * 3. When a web service receives user‑uploaded CDR files and must return a JPEG version, ensuring the output folder exists and exceptions are captured.
 * 4. When migrating legacy graphics archives, developers can use this code to read each CDR, save it as a JPG, and record errors without stopping the whole process.
 * 5. When integrating Aspose.Imaging into a C# utility that processes image formats, the try‑catch pattern helps diagnose issues such as unsupported CDR features or I/O problems.
 */
