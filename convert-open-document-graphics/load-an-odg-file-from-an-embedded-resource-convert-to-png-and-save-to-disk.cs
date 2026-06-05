using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Define file paths
            string inputPath = Path.Combine(inputDirectory, "sample.odg");
            string outputPath = Path.Combine(outputDirectory, "sample.png");

            // Write embedded ODG resource to input file if it does not exist
            if (!File.Exists(inputPath))
            {
                var assembly = Assembly.GetExecutingAssembly();
                // Adjust the resource name to match the actual embedded resource
                using (Stream resourceStream = assembly.GetManifestResourceStream("Resources.sample.odg"))
                {
                    if (resourceStream == null)
                    {
                        Console.Error.WriteLine("Embedded resource not found.");
                        return;
                    }
                    using (FileStream fileStream = new FileStream(inputPath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
            }

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load ODG image and convert to PNG
            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}