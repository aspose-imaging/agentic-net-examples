// HOW-TO: Log Start and End Times While Converting EPS to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            foreach (string epsFile in epsFiles)
            {
                if (!File.Exists(epsFile))
                {
                    Console.Error.WriteLine($"File not found: {epsFile}");
                    return;
                }

                Console.WriteLine($"Processing {Path.GetFileName(epsFile)} started at {DateTime.Now}");

                using (EpsImage image = (EpsImage)Image.Load(epsFile))
                {
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(epsFile) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PdfOptions options = new PdfOptions())
                    {
                        image.Save(outputPath, options);
                    }
                }

                Console.WriteLine($"Processing {Path.GetFileName(epsFile)} completed at {DateTime.Now}");
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
 * 1. When you need to batch‑convert a folder of EPS illustrations to PDF and record exactly when each file starts and finishes for audit or performance tracking.
 * 2. When your application must generate a processing log to monitor conversion times of vector graphics for SLA reporting.
 * 3. When you want to ensure that missing EPS files are detected early and the conversion workflow logs timestamps for troubleshooting.
 * 4. When integrating Aspose.Imaging into a C# service that converts customer‑uploaded EPS files to PDF and you need timestamped entries for debugging and billing purposes.
 * 5. When you are building a CI/CD pipeline that validates image conversion speed by logging start and end times for each EPS to PDF conversion step.
 */
