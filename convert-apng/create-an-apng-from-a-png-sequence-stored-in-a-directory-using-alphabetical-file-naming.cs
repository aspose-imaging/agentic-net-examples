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
        try
        {
            // Hardcoded input directory and output file path
            string inputDirectory = @"C:\Images\Input";
            string outputPath = @"C:\Images\Output\animation.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get PNG files in alphabetical order
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png")
                                         .OrderBy(f => f, StringComparer.Ordinal)
                                         .ToArray();

            if (pngFiles.Length == 0)
            {
                Console.Error.WriteLine("No PNG files found in the input directory.");
                return;
            }

            // Verify each input file exists
            foreach (string filePath in pngFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Load the first image to obtain dimensions
            using (RasterImage firstImage = (RasterImage)Image.Load(pngFiles[0]))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Set up APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame duration in ms
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (string filePath in pngFiles)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(filePath))
                        {
                            apngImage.AddFrame(frame);
                        }
                    }

                    // Save the APNG (output path already defined in options)
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}