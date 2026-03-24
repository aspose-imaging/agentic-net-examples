using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing source images
        string inputDirectory = @"C:\Images\Input";
        // Hardcoded output file path for the animated image
        string outputPath = @"C:\Images\Output\animation.png";

        // Verify that the input directory exists and contains files
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Directory not found: {inputDirectory}");
            return;
        }

        // Get all image files in the directory, ordered alphabetically to preserve frame order
        string[] imageFiles = Directory.GetFiles(inputDirectory)
                                       .OrderBy(f => f)
                                       .ToArray();

        if (imageFiles.Length == 0)
        {
            Console.Error.WriteLine($"No image files found in: {inputDirectory}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain width and height
        string firstFile = imageFiles[0];
        if (!File.Exists(firstFile))
        {
            Console.Error.WriteLine($"File not found: {firstFile}");
            return;
        }

        using (RasterImage firstImage = (RasterImage)Image.Load(firstFile))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image with the dimensions of the first frame
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, firstImage.Width, firstImage.Height))
            {
                // Remove the default single frame that exists after creation
                apngImage.RemoveAllFrames();

                // Add the first frame
                apngImage.AddFrame(firstImage);

                // Add remaining frames preserving order
                for (int i = 1; i < imageFiles.Length; i++)
                {
                    string filePath = imageFiles[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        // Append the frame; it will use the default frame time set in options
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the animated image to the specified output path
                apngImage.Save();
            }
        }
    }
}