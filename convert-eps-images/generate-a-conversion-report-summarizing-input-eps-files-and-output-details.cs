using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            // Prepare a list to hold report lines
            List<string> reportLines = new List<string>();
            reportLines.Add("EPS Conversion Report");
            reportLines.Add($"Generated on: {DateTime.Now}");
            reportLines.Add("");

            foreach (string epsPath in epsFiles)
            {
                // Validate input file existence
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    return;
                }

                // Load EPS image
                using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
                {
                    // Extract metadata
                    int width = epsImage.Width;
                    int height = epsImage.Height;
                    string title = epsImage.Title ?? "N/A";
                    string creator = epsImage.Creator ?? "N/A";

                    // Prepare output PNG path
                    string pngFileName = Path.GetFileNameWithoutExtension(epsPath) + ".png";
                    string pngPath = Path.Combine(outputDirectory, pngFileName);

                    // Ensure output directory for PNG exists
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    // Save PNG preview
                    epsImage.Save(pngPath, new PngOptions());

                    // Add entry to report
                    reportLines.Add($"File: {Path.GetFileName(epsPath)}");
                    reportLines.Add($"  Dimensions: {width}x{height}");
                    reportLines.Add($"  Title: {title}");
                    reportLines.Add($"  Creator: {creator}");
                    reportLines.Add($"  PNG Preview: {pngFileName}");
                    reportLines.Add("");
                }
            }

            // Write report to file
            string reportPath = Path.Combine(outputDirectory, "Report.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                foreach (string line in reportLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Report generated successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}