using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";
        string reportPath = Path.Combine(outputDirectory, "EpsReport.csv");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

        // Prepare report lines
        List<string> reportLines = new List<string>();
        reportLines.Add("FileName,Width,Height,BoundingBoxX,BoundingBoxY,BoundingBoxWidth,BoundingBoxHeight,PreviewImageCount");

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string inputPath in epsFiles)
        {
            // Verify the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EPS image
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                var bbox = image.BoundingBox; // Rectangle
                int previewCount = image.PreviewImageCount;

                // Add line to report
                string line = $"{Path.GetFileName(inputPath)},{width},{height},{bbox.X},{bbox.Y},{bbox.Width},{bbox.Height},{previewCount}";
                reportLines.Add(line);

                // Output to console
                Console.WriteLine($"Processed {Path.GetFileName(inputPath)}: {width}x{height}, BBox=({bbox.X},{bbox.Y},{bbox.Width},{bbox.Height}), Previews={previewCount}");
            }
        }

        // Write the report to a CSV file
        File.WriteAllLines(reportPath, reportLines);
        Console.WriteLine($"Report generated at: {reportPath}");
    }
}