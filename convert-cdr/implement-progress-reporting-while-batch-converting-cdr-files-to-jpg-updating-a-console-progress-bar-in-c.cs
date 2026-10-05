// HOW-TO: Batch Convert CDR Files to JPG with Console Progress Bar in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchCdrToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDirectory = "C:\\InputCdr";
                string outputDirectory = "C:\\OutputJpg";

                Directory.CreateDirectory(outputDirectory);

                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);
                int total = inputFiles.Length;
                if (total == 0)
                {
                    Console.WriteLine("No CDR files found.");
                    return;
                }

                for (int i = 0; i < total; i++)
                {
                    string inputPath = inputFiles[i];
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        JpegOptions options = new JpegOptions();
                        image.Save(outputPath, options);
                    }

                    int percent = (i + 1) * 100 / total;
                    int barSize = 50;
                    int filled = percent * barSize / 100;
                    string bar = new string('#', filled) + new string('-', barSize - filled);
                    Console.Write($"\rProgress: [{bar}] {percent}%");
                }

                Console.WriteLine();
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automate the conversion of a large collection of CorelDRAW (CDR) drawings to JPEG images for web publishing, this code processes the files in bulk and shows conversion progress in the console.
 * 2. When integrating Aspose.Imaging into a build pipeline that generates thumbnails from CDR source files, the progress bar helps monitor the batch job’s status.
 * 3. When a desktop utility must convert user‑uploaded CDR files to JPG while providing real‑time feedback to avoid the appearance of a frozen application.
 * 4. When migrating legacy design assets stored as CDR into a JPEG archive for backup or archival purposes, the script ensures each file is saved and reports completion percentage.
 * 5. When creating a command‑line tool for graphic designers to quickly transform multiple CDR files to JPEG with visual progress, this example demonstrates the required C# implementation.
 */
