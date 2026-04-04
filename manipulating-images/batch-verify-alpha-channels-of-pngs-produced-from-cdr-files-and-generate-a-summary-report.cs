using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing PNG files generated from CDR files
        string inputFolder = @"C:\Images\FromCdr";
        // Hardcoded output report file path
        string outputReportPath = @"C:\Images\Report\AlphaChannelReport.csv";

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Folder not found: {inputFolder}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

        // Collect report lines
        List<string> reportLines = new List<string>();
        reportLines.Add("FileName,HasAlpha"); // header

        // Process each PNG file in the input folder
        foreach (string filePath in Directory.GetFiles(inputFolder, "*.png"))
        {
            // Verify the file exists before loading
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            try
            {
                using (Image image = Image.Load(filePath))
                {
                    // Cast to PngImage to access HasAlpha property (fallback to RasterImage)
                    bool hasAlpha = false;
                    if (image is PngImage pngImage)
                    {
                        hasAlpha = pngImage.HasAlpha;
                    }
                    else if (image is RasterImage rasterImage)
                    {
                        hasAlpha = rasterImage.HasAlpha;
                    }

                    string fileName = Path.GetFileName(filePath);
                    reportLines.Add($"{fileName},{hasAlpha}");
                }
            }
            catch (Exception ex)
            {
                // Log loading errors but continue processing other files
                Console.Error.WriteLine($"Error processing '{filePath}': {ex.Message}");
            }
        }

        // Write the summary report
        File.WriteAllLines(outputReportPath, reportLines);
        Console.WriteLine($"Alpha channel verification completed. Report saved to: {outputReportPath}");
    }
}