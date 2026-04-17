using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare GIF save options
            var gifOptions = new GifOptions();

            // Add a timestamp comment indicating conversion date and time
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Assuming GifOptions supports a Comment property
            gifOptions.Comment = $"Converted on {timestamp}";

            // Save as GIF
            image.Save(outputPath, gifOptions);
        }
    }
}