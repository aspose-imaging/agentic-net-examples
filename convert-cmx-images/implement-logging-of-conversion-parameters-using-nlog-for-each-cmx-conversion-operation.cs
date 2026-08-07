using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.jpg";
            string outputPath = "Output\\result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit every CMX‑to‑JPEG conversion in a .NET batch service, NLog can log the source file path, target format, DPI and color profile for compliance reporting.
 * 2. When troubleshooting intermittent failures in an Aspose.Imaging pipeline that converts CMX drawings to PNG, logging conversion parameters with NLog helps identify which image dimensions or compression settings caused the error.
 * 3. When building a SaaS platform that offers on‑the‑fly CMX to PDF conversion, developers use NLog to capture user‑provided options such as page size, margin, and compression level for billing and usage analytics.
 * 4. When integrating CMX image conversion into a CI/CD workflow, NLog‑based logs of each conversion operation allow DevOps teams to verify that the correct Aspose.Imaging version and expected conversion flags are applied during automated builds.
 * 5. When implementing a multi‑threaded image processing service that converts CMX files to multiple output formats, developers rely on NLog to serialize conversion parameters per thread to monitor performance and detect race conditions.
 */