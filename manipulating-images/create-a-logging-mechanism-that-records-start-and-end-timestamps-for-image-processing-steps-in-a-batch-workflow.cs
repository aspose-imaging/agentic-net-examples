using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Logger
{
    private static readonly string LogFilePath = @"C:\Images\process.log";

    // Writes a message with a timestamp to the log file.
    public static void Log(string message)
    {
        string entry = $"{DateTime.Now:O} - {message}";
        try
        {
            File.AppendAllText(LogFilePath, entry + Environment.NewLine);
        }
        catch
        {
            // If logging fails, fall back to console output.
            Console.Error.WriteLine("Logging failed: " + entry);
        }
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories.
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory.
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Logger.Log($"Start processing: {inputPath}");

                // Load the image.
                using (Image image = Image.Load(inputPath))
                {
                    // Determine output path (convert to JPEG).
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Ensure the output directory exists (unconditional per requirements).
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as JPEG.
                    image.Save(outputPath, new JpegOptions());

                    Logger.Log($"Finished processing: {inputPath}");
                }
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
 * 1. When a developer needs to audit a nightly batch that converts thousands of PNG files to JPEG using Aspose.Imaging for .NET, the logger records start timestamps for each file to verify that every image was processed.
 * 2. When troubleshooting slow image processing performance, the logged timestamps let a developer pinpoint which conversion steps take the most time in a C# batch workflow.
 * 3. When regulatory compliance requires a tamper‑evident record of when image transformations occurred, the logger writes ISO‑8601 timestamps to a central log file for each processed file.
 * 4. When scaling a server‑side image pipeline, the developer can use the log entries to monitor the throughput of the batch job and detect any files that were skipped or failed.
 * 5. When generating operational reports for stakeholders, the timestamped log provides a simple way to calculate total processing duration and success rates for the PNG‑to‑JPEG conversion batch.
 */