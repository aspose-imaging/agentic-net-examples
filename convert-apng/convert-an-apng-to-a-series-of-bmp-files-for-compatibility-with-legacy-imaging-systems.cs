using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input APNG file and output directory
        string inputPath = "input.apng";
        string outputDir = "output_frames";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface to access frames
                if (image is IMultipageImage multipageImage)
                {
                    int frameCount = multipageImage.PageCount;

                    for (int i = 0; i < frameCount; i++)
                    {
                        // Retrieve the current frame as a raster image
                        RasterImage frame = (RasterImage)multipageImage.Pages[i];

                        // Build output BMP file path
                        string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        BmpOptions bmpOptions = new BmpOptions();
                        frame.Save(outputPath, bmpOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image does not support multiple pages.");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}