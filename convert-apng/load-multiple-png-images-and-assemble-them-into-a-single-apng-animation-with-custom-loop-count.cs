using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = { "Input\\image1.png", "Input\\image2.png", "Input\\image3.png" };
        string outputPath = "Output\\animation.apng";

        try
        {
            // Validate each input file
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas size
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Create APNG options with custom loop count
                Source source = new FileCreateSource(outputPath, false);
                ApngOptions options = new ApngOptions
                {
                    Source = source,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 3 // custom loop count
                };

                // Create the APNG canvas
                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    // Remove the default frame that exists upon creation
                    apng.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (var inputPath in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(inputPath))
                        {
                            // Resize if dimensions differ from canvas
                            if (frame.Width != width || frame.Height != height)
                            {
                                frame.Resize(width, height, ResizeType.NearestNeighbourResample);
                            }
                            apng.AddFrame(frame);
                        }
                    }

                    // Save the assembled APNG
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}