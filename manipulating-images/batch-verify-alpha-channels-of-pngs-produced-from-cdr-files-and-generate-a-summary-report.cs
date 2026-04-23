using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing PNG files generated from CDR files
        string inputFolder = @"C:\Images\CDR_PNGs";
        // Hardcoded output report file path
        string outputReport = @"C:\Images\AlphaReport.txt";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReport));

            // Prepare a StringBuilder for the summary report
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("FileName,HasAlpha");

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);

            foreach (string pngPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(pngPath))
                {
                    Console.Error.WriteLine($"File not found: {pngPath}");
                    return;
                }

                // Load the PNG image
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

            // Write the summary report to the output file
            File.WriteAllText(outputReport, reportBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}