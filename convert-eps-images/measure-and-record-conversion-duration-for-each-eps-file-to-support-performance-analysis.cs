using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "InputEps";
            string outputFolder = "OutputPng";

            // Validate input directory
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch sw = Stopwatch.StartNew();

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }

                sw.Stop();

                Console.WriteLine($"{fileNameWithoutExt}: {sw.ElapsedMilliseconds} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}