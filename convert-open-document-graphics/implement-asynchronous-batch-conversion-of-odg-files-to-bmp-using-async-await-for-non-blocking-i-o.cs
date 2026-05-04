using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputOdg";
            string outputDir = @"C:\OutputBmp";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputDir);

            // Get all ODG files in the input directory
            string[] odgFiles = Directory.GetFiles(inputDir, "*.odg");

            // Process each file asynchronously
            Task[] conversionTasks = new Task[odgFiles.Length];
            for (int i = 0; i < odgFiles.Length; i++)
            {
                conversionTasks[i] = ConvertOdgToBmpAsync(odgFiles[i], outputDir);
            }

            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task ConvertOdgToBmpAsync(string inputPath, string outputRoot)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Determine output BMP path
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
        string outputPath = Path.Combine(outputRoot, fileNameWithoutExt + ".bmp");

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and save as BMP on a background thread
        await Task.Run(() =>
        {
            using (Image odgImage = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                odgImage.Save(outputPath, bmpOptions);
            }
        });
    }
}