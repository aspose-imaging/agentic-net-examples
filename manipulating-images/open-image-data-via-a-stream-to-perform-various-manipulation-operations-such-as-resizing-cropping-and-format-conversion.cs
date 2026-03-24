using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string resizedOutputPath = @"C:\temp\output_resized.png";
        string croppedOutputPath = @"C:\temp\output_cropped.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Prepare PNG save options (used for both resized and cropped images)
        var pngOptions = new PngOptions();

        // ---------- Resize operation ----------
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Ensure the stream contains a loadable image
            if (!Image.CanLoad(inputStream))
            {
                Console.Error.WriteLine($"Cannot load image from stream: {inputPath}");
                return;
            }

            // Load image from stream
            using (Image image = Image.Load(inputStream))
            {
                // Resize to 800x600 using default resampling
                image.Resize(800, 600);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(resizedOutputPath));

                // Save resized image to file via stream
                using (FileStream outStream = File.Open(resizedOutputPath, FileMode.Create))
                {
                    image.Save(outStream, pngOptions);
                }
            }
        }

        // ---------- Crop operation ----------
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Ensure the stream contains a loadable image
            if (!Image.CanLoad(inputStream))
            {
                Console.Error.WriteLine($"Cannot load image from stream: {inputPath}");
                return;
            }

            // Load image from stream
            using (Image image = Image.Load(inputStream))
            {
                // Define central crop rectangle (half width and height)
                var cropRect = new Rectangle(
                    image.Width / 4,
                    image.Height / 4,
                    image.Width / 2,
                    image.Height / 2);

                // Perform cropping
                image.Crop(cropRect);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(croppedOutputPath));

                // Save cropped image to file via stream
                using (FileStream outStream = File.Open(croppedOutputPath, FileMode.Create))
                {
                    image.Save(outStream, pngOptions);
                }
            }
        }
    }
}