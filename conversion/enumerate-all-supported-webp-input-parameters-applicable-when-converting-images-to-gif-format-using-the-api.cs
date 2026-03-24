using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access WebP-specific options
            WebPImage webPImage = image as WebPImage;
            if (webPImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a WebP image.");
                return;
            }

            // Retrieve the WebPOptions associated with the image
            WebPOptions webPOptions = webPImage.Options;

            // Enumerate all public instance properties of WebPOptions (input parameters)
            Console.WriteLine("Supported WebP input parameters:");
            PropertyInfo[] properties = typeof(WebPOptions).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {
                // Get current value (if readable) for demonstration
                object value = prop.CanRead ? prop.GetValue(webPOptions) : "N/A";
                Console.WriteLine($"- {prop.Name}: {value ?? "null"}");
            }

            // Prepare GIF save options (default)
            GifOptions gifOptions = new GifOptions();

            // Save the image as GIF
            image.Save(outputPath, gifOptions);
        }

        Console.WriteLine("Conversion completed.");
    }
}