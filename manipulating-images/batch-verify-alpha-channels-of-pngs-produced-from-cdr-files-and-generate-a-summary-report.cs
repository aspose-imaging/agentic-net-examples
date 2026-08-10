// HOW-TO: Batch Check PNG Alpha Channels From CDR Files And Create Report In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing PNG files generated from CDR files
        string inputDirectory = @"C:\Images\Input";
        // Hardcoded output report file path
        string outputReportPath = @"C:\Images\Report\AlphaChannelReport.txt";

        try
        {
            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

            // Prepare a StringBuilder for the report
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("FileName,HasAlpha");

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.TopDirectoryOnly);

            foreach (string pngPath in pngFiles)
            {
                // Verify each file exists (defensive, though GetFiles should return existing files)
                if (!File.Exists(pngPath))
                {
                    Console.Error.WriteLine($"File not found: {pngPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(pngPath))
                {
                    // Cast to PngImage to access HasAlpha property
                    PngImage pngImage = (PngImage)image;
                    bool hasAlpha = pngImage.HasAlpha;

                    // Append result to the report
                    string fileName = Path.GetFileName(pngPath);
                    reportBuilder.AppendLine($"{fileName},{hasAlpha}");
                }
            }

            // Write the report to the output file
            File.WriteAllText(outputReportPath, reportBuilder.ToString());
            Console.WriteLine($"Alpha channel verification completed. Report saved to: {outputReportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to confirm that PNGs generated from CorelDRAW (CDR) retain transparency before publishing them on a website.
 * 2. When a QA pipeline must automatically verify the presence of an alpha channel in a batch of exported PNG assets.
 * 3. When you are migrating design assets and need a quick CSV‑style report showing which files contain alpha transparency.
 * 4. When you want to script a compliance check that flags PNGs without an alpha channel for further editing.
 * 5. When generating documentation for a graphics workflow and need to list each PNG’s alpha status for stakeholders.
 */
