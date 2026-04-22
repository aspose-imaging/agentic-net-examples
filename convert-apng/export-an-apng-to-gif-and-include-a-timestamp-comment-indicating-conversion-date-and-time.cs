using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Add a timestamp comment if the metadata object supports it
                if (image.Metadata != null)
                {
                    var commentProp = image.Metadata.GetType().GetProperty("Comment");
                    if (commentProp != null && commentProp.CanWrite)
                    {
                        commentProp.SetValue(image.Metadata, $"Converted on {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    }
                }

                // Save the image as GIF
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}