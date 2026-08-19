// HOW-TO: Generate EPS Image Summary Report With Width Height Bounding Box In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string reportPath = Path.Combine(outputDirectory, "Report.txt");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            // Prepare report lines
            List<string> reportLines = new List<string>();
            reportLines.Add("FileName,Width,Height,BoundingBox,PreviewCount");

            foreach (string filePath in epsFiles)
            {
                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the EPS image
                using (Image image = Image.Load(filePath))
                {
                    var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
                    if (epsImage == null)
                    {
                        Console.Error.WriteLine($"Not an EPS image: {filePath}");
                        continue;
                    }

                    // Extract required details
                    string fileName = Path.GetFileName(filePath);
                    int width = epsImage.Width;
                    int height = epsImage.Height;
                    string boundingBox = epsImage.BoundingBox.ToString();
                    int previewCount = epsImage.PreviewImageCount;

                    // Add a line to the report
                    reportLines.Add($"{fileName},{width},{height},{boundingBox},{previewCount}");
                }
            }

            // Write the report to the output file
            File.WriteAllLines(reportPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process a folder of EPS files and create a CSV‑style report of each image’s dimensions and bounding box for quality‑control purposes.
 * 2. When an automated workflow must verify the number of preview images embedded in EPS documents before publishing them to a print‑ready catalog.
 * 3. When a migration script has to log EPS file metadata such as width, height, and bounding box to compare against a target format’s specifications.
 * 4. When a desktop application wants to display a summary table of all EPS assets in a project directory for quick inventory management.
 * 5. When a CI/CD pipeline requires generating a text report of EPS image properties to ensure assets meet predefined size constraints.
 */
