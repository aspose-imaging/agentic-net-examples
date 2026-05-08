using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string epsPath in epsFiles)
            {
                // Validate input file existence
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    continue;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(epsPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure conversion duration
                DateTime startTime = DateTime.Now;

                using (Image image = Image.Load(epsPath))
                {
                    image.Save(outputPath, new PngOptions());
                }

                DateTime endTime = DateTime.Now;
                double durationMs = (endTime - startTime).TotalMilliseconds;

                Console.WriteLine($"{epsPath} converted in {durationMs} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}